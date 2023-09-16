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

        public UarkService()
        {
            _usersRepository = new UsersRepository(QueryRepository.Default);
            _applyFileRepository = new ApplyFileRepository(QueryRepository.Default);
            _orgsRepository = new OrgsRepository(QueryRepository.Default);
            _sysLogRepository = new SysLogRepository(QueryRepository.Default);
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
                    if (userData?.Status == "Pending Approval")
                    {
                        loginModal.ErrorMessage = "This account has not been approve yet.";
                        return loginModal;
                    }
                    else
                    {
                        userData.CopyPropertiesTo(loginModal);
                        HttpContext.Current.Session["UserName"] = loginModal.Name;

                        return loginModal;
                    }
                }
                else
                {
                    loginModal.ErrorMessage = "Password is incorrect.";
                    return loginModal;
                }
            }
        }

        public LoginModal CreateMember(LoginModal loginModal)
        {
            var usersList = _usersRepository.GetList(new { account = loginModal.Account });
            if (usersList.Any())
            {
                loginModal.ErrorMessage = "this account is already been added!";
                return loginModal;
            }
            else
            {
                var users = new Users();
                loginModal.CopyPropertiesTo(users);
                _usersRepository.Insert(users);
                var sysLog = new SysLog();
                sysLog.Account = loginModal.Account;
                sysLog.IpAddress = HttpContext.Current.Request.UserHostAddress;
                sysLog.LoginDateTime = null;
                _sysLogRepository.Insert(sysLog);
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
    }
}