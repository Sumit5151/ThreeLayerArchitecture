﻿using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.Utility;

namespace ThreeLayerArchitecture.BAL
{
    public class UserRepositorySQLDB : IUserRepository
    {
        private readonly SecondMvcappDbContext db;
        public UserRepositorySQLDB(SecondMvcappDbContext _db)
        {
            this.db = _db;
        }


        public List<Gender> GetAllGenders()
        {
            var genders = db.Genders.ToList();
            return genders;
        }

        public void CreateNewUser(UserRegistrationViewModel userVM)
        {
            //User user = new User(userVM);
            UserUpdateViewModel userUpdateViewModel = null;
            User user = new User();
            user.ConvertUserVMToUserDTO(userVM, userUpdateViewModel);

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
            var user = GetUser(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }


        public User GetUser(int id)
        {
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }



        public UserUpdateViewModel GetSingleUser(int id)
        {
            //var user =   db.Users.FirstOrDefault(user => user.Id == id); //never
            //var user =   db.Users.SingleOrDefault(user => user.Id == id);//multiple records throws exception 

            //var user = db.Users.Single(user => user.GenderId == 2);        //multilple throws //0 records throws exception
            //var user =   db.Users.First(user => user.Id == id); //0 records throws exception



            
            User user = db.Users.Find(id);
            UserUpdateViewModel userUpdateViewModel = null;
            if (user != null)
            {
                userUpdateViewModel = new UserUpdateViewModel(user);
            }

            return userUpdateViewModel;

        }

        public void UpdateUser(UserUpdateViewModel userUVM)
        {
          var user =  db.Users.Find(userUVM.Id);
            if(user != null)
            {



                //user.FirstName = userUVM.FirstName;
                //user.LastName = userUVM.LastName;
                //user.MobileNumber = userUVM.MobileNumber;
                //user.AdharNumber = userUVM.AdharNumber;
                //user.GenderId = userUVM.GenderId;
                //user.Category = userUVM.Category;
                //UserRegistrationViewModel userRegistrationViewModel = null;
                //user.ConvertUserVMToUserDTO(userRegistrationViewModel, userUVM);


                user.ConvertUserVMToUserDTOForUpdateUser(userUVM);


                db.Users.Update(user);
                db.SaveChanges();
            }

         
        }



       public  bool IsEmailPresentInDB(string email)
        {           

            bool isEmailIdPresentInDB = db.Users.Any(x => x.Email == email);

            return isEmailIdPresentInDB;


        }
    }
}
