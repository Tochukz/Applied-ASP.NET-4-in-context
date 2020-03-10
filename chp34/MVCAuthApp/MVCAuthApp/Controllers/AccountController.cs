using System.Web.Security;
using System.Web.Mvc;
using MVCAuthApp.Models.Views;

namespace MVCAuthApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel loginView = new LoginViewModel();
            return View(loginView);
           
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel creds, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /* FormsAuthetication.Authenticate is obsolete. Use Memebership.ValidateUser instead */
                if (FormsAuthentication.Authenticate(creds.Username, creds.Password))
                {
                    FormsAuthentication.SetAuthCookie(creds.Username, false); // The second paramater must be true if you want the cookie to persist between sessions
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
                
            }
         
            return View(creds);
        }
    }
}