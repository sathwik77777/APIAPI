using CodingCha.Entities;

namespace CodingCha.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int userid);
        void EditUser(User user);
        void DeleteUser(int userid);
        User ValidateUser(string email, string password);

    }
}
