using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public interface IDatabaseCrud
    {
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
		RoomTypeModel GetRoomTypeById(int id);
		List<BookingModel> SearchBookings(string lastName);
    }
}