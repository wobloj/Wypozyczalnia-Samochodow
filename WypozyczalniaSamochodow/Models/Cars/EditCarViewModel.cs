using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaSamochodow.Models.Cars
{
    public class EditCarViewModel
    {
        public int Id { get; set; }

        public string Car { get; set; }

        public string Model { get; set; }

        public string Engine { get; set; }

        public string BodyType { get; set; }

        public int ProductionYear { get; set; }

        public List<CarModel> Cars { get; set; }
    }
}
