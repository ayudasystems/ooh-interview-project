using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _dataContext;

        public BookingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _dataContext.Bookings;
        }

        public void AddBooking(Booking booking)
        {
            _dataContext.Bookings.Add(booking);
        }
    }
}