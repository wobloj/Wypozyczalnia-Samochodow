using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaSamochodow.Models.Users
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Należy podać imię")]
        [StringLength(50, ErrorMessage = "Imie jest za długie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Należy podać nazwisko")]
        [StringLength(50, ErrorMessage = "Nazwisko jest za długie")]
        public string LastName { get; set; }

        [StringLength(128, ErrorMessage = "Email jest za długi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Należy podać numer telefonu")]
        [StringLength(12, ErrorMessage = "Numer telefonu jest za długi")]
        public string Phone { get; set; }
    }
}
