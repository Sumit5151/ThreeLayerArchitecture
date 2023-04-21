using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.BAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            UserRegistrationViewModel UserVM = new UserRegistrationViewModel();

            UserRepository userRepository = new UserRepository();
            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCatgories();

            //return View("~/Views/Test/Index.cshtml");
            return View("UserRegistration", UserVM);
            
        }

        [HttpPost]
        public IActionResult Registration(UserRegistrationViewModel userVM)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.CreateNewUser(userVM);



           
            ViewBag.GenderList = userRepository.GetAllGenders();
            return View();
        }
    }
}
