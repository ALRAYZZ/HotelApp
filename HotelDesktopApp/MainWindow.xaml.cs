using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelDesktopApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IDatabaseCrud _db;
		private readonly IServiceProvider _serviceProvider;

		public MainWindow(IDatabaseCrud db, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			_db = db;
			_serviceProvider = serviceProvider;
		}

		private void searchForGuest_Click(object sender, RoutedEventArgs e)
		{
			List<BookingModel> bookings = _db.SearchBookings(lastNameText.Text);
			resultsList.ItemsSource = bookings; //This populates the listbox with the results of the search
			
		}

		private void goToCheckIn_Click(object sender, RoutedEventArgs e)
		{
			var checkInForm = App.serviceProvider.GetService<CheckIn>();
			var model = (BookingModel)((Button)e.Source).DataContext;


			checkInForm.Initialize(model);
			checkInForm.ShowDialog();

			
		}
	}
	
}