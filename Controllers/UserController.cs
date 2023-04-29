using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.BAL;
using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Controllers
{
    public class UserController : Controller
    {
       private readonly IUserRepository userRepository;
      
        public UserController(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }


        public IActionResult Index()
        {           
          var userVMs=  userRepository.GetAllUsers();
            return View(userVMs);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            UserRegistrationViewModel UserVM = new UserRegistrationViewModel();
           
            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCatgories();

            //return View("~/Views/Test/Index.cshtml");
            return View("UserRegistration", UserVM);
            
        }

        [HttpPost]
        public IActionResult Registration(UserRegistrationViewModel userVM)
        {
            

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
                return RedirectToAction("Index");

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


        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }






        [HttpGet]
        public IActionResult Update(int id)
        {

          var userVM=  userRepository.GetSingleUser(id);
            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCatgories();

            return View(userVM);

        }

        [HttpPost]
        public IActionResult Update(UserUpdateViewModel userUVM)
        {
            if(ModelState.IsValid == true)
            {
                userRepository.UpdateUser(userUVM);
                return RedirectToAction("Index");
            }


            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCatgories();
            return View(userUVM);
        }
    }
}
