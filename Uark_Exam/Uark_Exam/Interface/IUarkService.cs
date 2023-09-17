using System;
using System.Collections.Generic;
using Uark_Exam.ViewModal;

namespace Uark_Exam.Interface
{
    public interface IUarkService
    {
        LoginModal ValidateUser(LoginModal loginModal);
        List<OrgModal> GetOrgList();
        OrgModal CreateOrg(OrgModal orgModal);
        LoginModal CreateMember(LoginModal loginModal);
        List<UsersListModal> GetUsersList();
        bool ApproveUser(Guid id);
        LoginModal ActiveUser(Guid id);
    }
}