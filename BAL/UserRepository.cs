using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.BAL
{
    public class UserRepository
    {
        public List<Gender> GetAllGenders()
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();
            var genders = db.Genders.ToList();
            return genders;
        }


        public void CreateNewUser(UserRegistrationViewModel userVM)
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();


            User user = new User();
            user.Email = userVM.Email;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.GenderId = userVM.GenderId;
            user.Password = userVM.Password;
            user.MobileNumber = userVM.MobileNumber;
            user.AdharNumber = userVM.AdharNumber;
            user.Category = userVM.Category;
            user.TermsConditions = userVM.TermsConditions;

            db.Users.Add(user);
            db.SaveChanges();

        }

        public List<Category> GetAllCatgories()
        {


            List<Category> categories = new List<Category>();

            Category category1 = new Category();
            category1.Id = 1;
            category1.Name = "General";

            Category category2 = new Category();
            category2.Id = 2;
            category2.Name = "OBC";

            Category category3 = new Category();
            category3.Id = 3;
            category3.Name = "Other";

            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);


            return categories;


        }


        public List<UserRegistrationViewModel> GetAllUsers()
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();
            List<User> users = db.Users.ToList();

            List<UserRegistrationViewModel> userRegistrationViewModels = new List<UserRegistrationViewModel>();

            foreach (var user in users)
            {
                UserRegistrationViewModel userVM = new UserRegistrationViewModel();
                userVM.Id = user.Id;
                userVM.Email= user.Email;
                userVM.FirstName = user.FirstName;
                userVM.LastName = user.LastName;
                //userVM.GenderId = user.Gender;
                userVM.Category= user.Category;
                userVM.MobileNumber = user.MobileNumber;

                userRegistrationViewModels.Add(userVM);

            }


             




            return userRegistrationViewModels;

        }
    }
}
