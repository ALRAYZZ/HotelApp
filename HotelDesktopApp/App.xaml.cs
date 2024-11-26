using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using DataAccessLibrary.Data;
using DataAccessLibrary.Databases;

namespace HotelDesktopApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static ServiceProvider serviceProvider;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var serviceCollection = new ServiceCollection();
			serviceCollection.AddTransient<MainWindow>();
			serviceCollection.AddTransient<CheckIn>();
			serviceCollection.AddTransient<ISqlDataAccess, SqlDataAccess>();
			serviceCollection.AddTransient<IDatabaseCrud, SqlCrud>();


			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			
			IConfiguration configuration = builder.Build();

			serviceCollection.AddSingleton(configuration);

			serviceProvider = serviceCollection.BuildServiceProvider();
			var mainWindow = serviceProvider.GetService<MainWindow>();

			mainWindow.Show();
		}

		
	}

}
