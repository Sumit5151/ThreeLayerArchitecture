using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.BAL
{
    public class UserRepositoryOracleDB : IUserRepository
    {
        public void CreateNewUser(UserRegistrationViewModel userVM)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCatgories()
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetAllGenders()
        {
            throw new NotImplementedException();
        }

        public List<UserRegistrationViewModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserUpdateViewModel GetSingleUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsEmailPresentInDB(string email)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserUpdateViewModel userUVM)
        {
            throw new NotImplementedException();
        }
    }
}
