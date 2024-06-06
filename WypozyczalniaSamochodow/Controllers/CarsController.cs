using Microsoft.AspNetCore.Mvc;
using WypozyczalniaSamochodow.Models.Cars;
using WypozyczalniaSamochodow.Services;

namespace WypozyczalniaSamochodow.Controllers
{
    public class CarsController : Controller
    {
        public readonly ILogger<CarsController> _logger;
        private readonly ICarService _carService;

        public CarsController(ILogger<CarsController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var model = new CarViewModel()
            {
                Cars = _carService.GetCars(),
            };
            return View(model);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(string car, string model, string engine, string bodyType, int productionYear)
        {
            if (ModelState.IsValid) {
                _carService.AddCar(car, model, engine, bodyType, productionYear);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditCar(string car, string model, string engine, string bodyType, int productionYear)
        {
            var carModel = new EditCarViewModel()
            {
                Car = car,
                Model = model,
                Engine = engine,
                BodyType = bodyType,
                ProductionYear = productionYear,
            };

            return View(carModel);
        }

        [HttpPost]
        public IActionResult EditThisCar(int id, string car, string model, string engine, string bodyType, int productionYear)
        {
            if (ModelState.IsValid)
            {
                _carService.UpdateCar(id, car, model, engine, bodyType, productionYear);
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult RemoveCar(int Id)
        {
            _carService.DeleteCar(Id);
            return RedirectToAction("Index");
        }
    }
}
