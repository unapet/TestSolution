using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestApplication.Service;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<ViewResult> Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        // Uncomment the below line to enable roles on this action method.
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
