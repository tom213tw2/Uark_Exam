using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Comman.Data.Dapper;
using Uark_Exam.Interface;
using Uark_Exam.Repository;
using Uark_Exam.Repository.Madal.DB;
using Uark_Exam.Repository.Repository;
using Uark_Exam.ViewModal;

namespace Uark_Exam.Service
{
    public class UarkService : IUarkService
    {
        private UsersRepository _usersRepository;
        private ApplyFileRepository _applyFileRepository;
        private OrgsRepository _orgsRepository;
        private SysLogRepository _sysLogRepository;
        private vUsersRepository _vUsersRepository;

        public UarkService()
        {
            _usersRepository = new UsersRepository(QueryRepository.Default);
            _applyFileRepository = new ApplyFileRepository(QueryRepository.Default);
            _orgsRepository = new OrgsRepository(QueryRepository.Default);
            _sysLogRepository = new SysLogRepository(QueryRepository.Default);
            _vUsersRepository = new vUsersRepository(QueryRepository.Default);
        }

        public LoginModal ValidateUser(LoginModal loginModal)
        {
            var usersList = _usersRepository.GetList(new { account = loginModal.Account })
                .ToList();
            if (usersList.Count == 0)
            {
                loginModal.ErrorMessage = "Account not exist.";
                return loginModal;
            }
            else
            {
                var userData = usersList.FirstOrDefault();
                if (userData?.Password == loginModal.Password)
                {
                    switch (userData?.Status)
                    {
                        case "Pending Approval":
                            loginModal.ErrorMessage = "This account has not been approve yet.";
                            return loginModal;
                        case "Approved":
                            loginModal.ErrorMessage =
                                "This account has been approved,please open email link to active.";
                            break;
                        default:
                            HttpContext.Current.Session["UserName"] = userData.Name;
                            UpdateSyslog(userData);
                            return loginModal;
                    }
                }
                else
                {
                    loginModal.ErrorMessage = "Password is incorrect.";
                    return loginModal;
                }
            }

            return loginModal;
        }

        private void UpdateSyslog(Users userData)
        {
            var sysLogList = _sysLogRepository.GetList(new { account = userData.Account }).ToList();
            if (sysLogList.Any())
            {
                var sysLog = sysLogList.FirstOrDefault();
                sysLog.LoginDateTime = DateTime.Now;
                sysLog.IpAddress = HttpContext.Current.Request.UserHostAddress;
                _sysLogRepository.Update(sysLog);
            }
            else
            {
                var sysLog = new SysLog();
                sysLog.Account = userData.Account;
                sysLog.IpAddress = HttpContext.Current.Request.UserHostAddress;
                sysLog.LoginDateTime = DateTime.Now;
                _sysLogRepository.Insert(sysLog);
            }
        }

        public LoginModal CreateMember(LoginModal loginModal)
        {
            var usersList=_usersRepository.GetList("where account=@account or name=@name", new { account = loginModal.Account ,name=loginModal.Name});
           if (usersList.Any())
            {
                var user = usersList.FirstOrDefault();
                if (user.Account == loginModal.Account)
                {
                    loginModal.ErrorMessage = "this account is already been added!";
                   
                }
                else if (user.Name == loginModal.Name)
                {
                    loginModal.ErrorMessage = "this name is already been added!";
                }
                return loginModal;
               
            }
            else
            {
                var users = new Users();
                loginModal.CopyPropertiesTo(users);
                _usersRepository.Insert(users);
                UpdateSyslog(users);
                return loginModal;
            }
        }

        public List<OrgModal> GetOrgList()
        {
            var orgList = _orgsRepository.GetList().ToList();
            var orgModalList = new List<OrgModal>();
            foreach (var org in orgList)
            {
                var orgModal = new OrgModal();
                org.CopyPropertiesTo(orgModal);
                orgModalList.Add(orgModal);
            }

            return orgModalList;
        }

        public OrgModal CreateOrg(OrgModal orgModal)
        {
            var orgList = _orgsRepository.GetList(new { org_no = orgModal.OrgNo }).ToList();
            if (orgList.Any())
            {
                orgModal.ErrorMessage = "this OrgNo is already been added!";
                return orgModal;
            }
            else
            {
                var org = new Orgs();
                orgModal.CopyPropertiesTo(org);
                _orgsRepository.Insert(org);
                return orgModal;
            }
        }

        public List<UsersListModal> GetUsersList()
        {
            var usersList = _vUsersRepository.GetList().ToList();
            var usersModalList = new List<UsersListModal>();
            foreach (var users in usersList)
            {
                var usersModal = new UsersListModal();
                users.CopyPropertiesTo(usersModal);
                usersModalList.Add(usersModal);
            }

            return usersModalList;
        }

        //need to refactor
        public bool ApproveUser(Guid id)
        {
            var usersList = _usersRepository.GetList(new { id = id }).ToList();
            if (!usersList.Any()) return false;
            var user = usersList.FirstOrDefault();
            user.Status = "Approved";
            user.UpdatedDateTime = DateTime.Now;
            _usersRepository.Update(user);
            return true;
        }
    }
}