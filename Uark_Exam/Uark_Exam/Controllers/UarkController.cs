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
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateMember(LoginModal loginModal)
        {
            
            return View();
        }
        
        
       
    }
}