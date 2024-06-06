using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WypozyczalniaSamochodow.Models.Cars
{
    public class CarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wymagane pole")]
        [MaxLength(50, ErrorMessage ="Maksymalna długość wynosi 50 znaków")]
        public string Car { get; set; }

        [Required(ErrorMessage = "Wymagane pole")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość wynosi 50 znaków")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Wymagane pole")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość wynosi 50 znaków")]
        public string Engine { get; set; }

        [Required(ErrorMessage = "Wymagane pole")]
        [MaxLength(50, ErrorMessage = "Maksymalna długość wynosi 50 znaków")]
        public string BodyType { get; set; }

        [Required(ErrorMessage = "Wymagane pole")]
        [Range(1000, 3000)]
        public int ProductionYear { get; set; }
    }
}
