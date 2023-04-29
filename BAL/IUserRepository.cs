using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.BAL
{
    public interface IUserRepository
    {
         List<Gender> GetAllGenders();
         void CreateNewUser(UserRegistrationViewModel userVM);
         List<Category> GetAllCatgories();
         List<UserRegistrationViewModel> GetAllUsers();
         void DeleteUser(int id);
         User GetUser(int id);
        UserUpdateViewModel GetSingleUser(int id);
        void UpdateUser(UserUpdateViewModel userUVM);

    }
}
