using WypozyczalniaSamochodow.Models.Cars;

namespace WypozyczalniaSamochodow.Services
{
    public interface ICarService
    {
        public List<CarModel> GetCars();
        public CarModel GetCar(int id);
        public void AddCar(string car, string model, string engine, string bodyType, int productionYear);
        public void DeleteCar(int id);
        public void UpdateCar(int id, string car, string model, string engine, string bodyType, int productionYear);
    }
}
