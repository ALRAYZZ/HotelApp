using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelDesktopApp
{
	/// <summary>
	/// Interaction logic for CheckIn.xaml
	/// </summary>
	public partial class CheckIn : Window
	{
		private readonly IDatabaseCrud _db;
		private BookingModel _booking = null;

		public CheckIn(IDatabaseCrud db)
		{
			InitializeComponent();
			_db = db;
		}
		public void Initialize(BookingModel booking)
		{
			
			_booking = booking;
			DataContext = booking;
		}

		private void CheckIn_Click(object sender, RoutedEventArgs e)
		{
			_db.CheckInGuest(_booking.Id);
			MessageBox.Show("Guest Checked In", "Check In", MessageBoxButton.OK, MessageBoxImage.Information);
			Close();
		}
	}
}
