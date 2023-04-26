using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.Utility;

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
            //User user = new User(userVM);

            User user = new User();
            user.ConvertUserVMToUserDTO(userVM);
            


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

            //List<User> usersPrevious = db.Users.ToList();

            List<User> users = db.Users.Include(user => user.Gender).ToList();

            List<UserRegistrationViewModel> userRegistrationViewModels = new List<UserRegistrationViewModel>();

            foreach (var user in users)
            {
                //UserRegistrationViewModel userVM = new UserRegistrationViewModel(user);
                UserRegistrationViewModel userVM = new UserRegistrationViewModel();
                userVM.ConvertUserDTOToUserVM(user);

                userRegistrationViewModels.Add(userVM);
            }

            return userRegistrationViewModels;

        }


        public void DeleteUser(int id)
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();

            var user = GetUser(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }


        public User GetUser(int id)
        {
            SecondMvcappDbContext db = new SecondMvcappDbContext();
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }



        




    }
}
