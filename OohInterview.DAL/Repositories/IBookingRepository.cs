using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings();
        void AddBooking(Booking booking);
    }
}