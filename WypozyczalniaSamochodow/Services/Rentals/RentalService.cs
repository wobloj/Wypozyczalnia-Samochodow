using WypozyczalniaSamochodow.Context;
using WypozyczalniaSamochodow.Models.Rentals;

namespace WypozyczalniaSamochodow.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly CarRentalDbContext _context;

        public RentalService(CarRentalDbContext context) {
            _context = context;
        }
        
        public List<RentalModel> GetRentals()
        {
            return _context.Rentals.ToList();
        }

        public RentalModel GetRental(int id)
        {
            var rent = _context.Rentals.SingleOrDefault(r => r.Id == id);
            return rent ?? new RentalModel();
        }

        public void AddRental(int carId, int userId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (car != null && user != null)
            {
                _context.Rentals.Add(new RentalModel
                {
                    CarId = carId,
                    UserId = userId,
                    RentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(14),
                    IsReturned = false
                });
                _context.SaveChanges();
            }
        }

        public void EditRental(int id, int carId, int userId, DateTime RentDate)
        {
            var rent = _context.Rentals.FirstOrDefault(r => r.Id == id);
            if (rent != null) 
            {
                rent.CarId = carId;
                rent.UserId = userId;
                rent.RentDate = RentDate;
                rent.ReturnDate = RentDate.AddDays(14);
            }
        }

        public void DeleteRental(int id)
        {
            var rent = _context.Rentals.FirstOrDefault(r => r.Id == id);
            if (rent != null) 
            {
                _context.Remove(rent);
                _context.SaveChanges();
            }
        }

        public void ChangeReturnState(int id, bool isReturned)
        {
            var rent = _context.Rentals.FirstOrDefault(x => x.Id == id);
            if (rent.IsReturned)
            {
                rent.IsReturned = !isReturned;
            }
            else
            {
                rent.IsReturned = !isReturned;
            }
            _context.SaveChanges();
        }
    }     
}
