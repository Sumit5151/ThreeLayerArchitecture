using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.BAL;
using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserRepository userRepository = new UserRepository();
          var userVMs=  userRepository.GetAllUsers();

            return View(userVMs);
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

            if(userVM.TermsConditions == false)
            {
                ModelState.AddModelError("TermsConditions", "Please accept terms and condition");
            }
            if (userVM.Category == null)
            {
                ModelState.AddModelError("Category", "Please select category");
            }



            if (ModelState.IsValid == true)
            {
                userRepository.CreateNewUser(userVM);
            }


           
            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCatgories();
            return View("UserRegistration",userVM);
        }


        public IActionResult IsEmailIdValid(string Email)
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();

            var isEmailIdPresentInDB = db.Users.Any(u => u.Email == Email);
            if (isEmailIdPresentInDB == true)
            {
                return Json("The Email id is present in the database please choose another email id");
            }
            else
            {
                return Json(true);
            }



        }
    }
}
