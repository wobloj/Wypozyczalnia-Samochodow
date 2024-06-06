namespace WypozyczalniaSamochodow.Models.Users
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
