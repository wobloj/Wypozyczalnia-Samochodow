using Microsoft.AspNetCore.Mvc;
using WypozyczalniaSamochodow.Models.Rentals;
using WypozyczalniaSamochodow.Services;
using WypozyczalniaSamochodow.Services.Rentals;
using WypozyczalniaSamochodow.Services.Users;

namespace WypozyczalniaSamochodow.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ILogger<RentalsController> _logger;
        private readonly IRentalService _rentalService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;

        public RentalsController(ILogger<RentalsController> logger, IRentalService rentalService, ICarService carService, IUserService userService)
        {
            _logger = logger;
            _rentalService = rentalService;
            _carService = carService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };
            return View(model);
        }

        public IActionResult AddRent()
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddRent(int carId, int userId)
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            if (ModelState.IsValid)
            {
                _rentalService.AddRental(carId, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult ChangeReturnState(int id, bool isReturned)
        {
            _rentalService.ChangeReturnState(id, isReturned);
            return RedirectToAction("Index");
        }

        public IActionResult EditRent(int id, int carId, int userId, DateTime rentDate)
        {
            var model = new RentalViewModel()
            {
                Id = id,
                CarId = carId,
                UserId = userId,
                RentDate = rentDate,
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisRent(int id, int carId, int userId, DateTime rentDate)
        {
            var model = new RentalViewModel()
            {
                Id = id,
                CarId = carId,
                UserId = userId,
                RentDate = rentDate,
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            if (ModelState.IsValid)
            {
                _rentalService.EditRental(id,carId,userId,rentDate);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
