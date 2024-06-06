using WypozyczalniaSamochodow.Models.Users;

namespace WypozyczalniaSamochodow.Services.Users
{
    public interface IUserService
    {
        public List<UserModel> GetUsers();
        public UserModel GetUser(int id);
        public void AddUser(string firstName, string lastName, string email, string phone);
        public void UpdateUser(int id, string firstName, string lastName, string email, string phone);
        public void DeleteUser(int id);
    }
}
