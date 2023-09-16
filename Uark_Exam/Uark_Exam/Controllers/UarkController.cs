using System.Web.Mvc;
using Uark_Exam.Filter;
using Uark_Exam.Interface;
using Uark_Exam.Service;
using Uark_Exam.ViewModal;

namespace Uark_Exam.Controllers
{
    [ControlFilter]
    public class UarkController : Controller
    {
        private readonly IUarkService _uarkService;
        public UarkController()
        {
            _uarkService = new UarkService();
        }
        // GET
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModal());
        }
        [HttpPost]
        public ActionResult Login(LoginModal loginModal)
        {
            _uarkService.ValidateUser(loginModal);
            return loginModal.IsSuccess ? (ActionResult)RedirectToAction("Index", "Home") : View(loginModal);
        }
        
        [HttpGet]
        public ActionResult CreateMember()
        {
            return View(new LoginModal());
        }
        
        [HttpPost]
        public ActionResult CreateMember(LoginModal loginModal)
        {   
            _uarkService.CreateMember(loginModal);
           return loginModal.IsSuccess ? (ActionResult)RedirectToAction("Index", "Home") : View(loginModal);
        }
        
        public ActionResult CreateOrgs()
        {
            return View(new OrgModal());
        }
        [HttpPost]
        public ActionResult CreateOrgs(OrgModal orgModal)
        {
           _uarkService.CreateOrg(orgModal);
           return orgModal.IsSuccess ? (ActionResult)RedirectToAction("OrgsGrid") : View(orgModal);


        }
        
        [HttpGet]
        public ActionResult OrgsGrid()
        {
            var orgList = _uarkService.GetOrgList();
            return View(orgList);
        }

        public JsonResult GetOrdList()
        {
            var orgList = _uarkService.GetOrgList();
            return new JsonResult
            {
                Data =orgList,
                MaxJsonLength = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        
        
       
    }
}