using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;
using ViewModels;

namespace ThreeLayerArchitecture.Utility
{
    public static class ExtensionMetodDemo
    {

        public static void ConvertUserVMToUserDTO(this User user, UserRegistrationViewModel userVM,
                                                                     UserUpdateViewModel userUVM)
        {            
                   

            if(userUVM  == null)
            {
                user.Email = userVM.Email;
                user.Password = userVM.Password;
                user.TermsConditions = userVM.TermsConditions;
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;
                user.GenderId = userVM.GenderId;
                user.MobileNumber = userVM.MobileNumber;
                user.AdharNumber = userVM.AdharNumber;
                user.Category = userVM.Category;
            }
            else
            {
                user.FirstName = userUVM.FirstName;
                user.LastName = userUVM.LastName;
                user.GenderId = userUVM.GenderId;
                user.MobileNumber = userUVM.MobileNumber;
                user.AdharNumber = userUVM.AdharNumber;
                user.Category = userUVM.Category;
            }


        }

        public static void ConvertUserDTOToUserVM(this UserRegistrationViewModel userVM, User user)
        {
            userVM.Id = user.Id;
            userVM.Email = user.Email;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;
            userVM.GenderId = user.GenderId;
            userVM.GenderName = user.Gender.Text;
            userVM.Category = user.Category;
            userVM.MobileNumber = user.MobileNumber;
            userVM.AdharNumber = user.AdharNumber;
        }



        public static void ConvertUserVMToUserDTOForUpdateUser(this User user, UserUpdateViewModel userUVM)
        {
            user.FirstName = userUVM.FirstName;
            user.LastName = userUVM.LastName;
            user.GenderId = userUVM.GenderId;
            user.MobileNumber = userUVM.MobileNumber;
            user.AdharNumber = userUVM.AdharNumber;
            user.Category = userUVM.Category;
        }

    }
}
