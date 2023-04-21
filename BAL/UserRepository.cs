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
    }
}
