using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Utility
{
    public static class ExtensionMetodDemo
    {

        public static void ConvertUserVMToUserDTO(this User user, UserRegistrationViewModel userVM)
        {            
            user.Email = userVM.Email;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.GenderId = userVM.GenderId;
            user.Password = userVM.Password;
            user.MobileNumber = userVM.MobileNumber;
            user.AdharNumber = userVM.AdharNumber;
            user.Category = userVM.Category;
            user.TermsConditions = userVM.TermsConditions;
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

    }
}
