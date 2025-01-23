using Blog.UI;
using Blog.UI.Screens;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            //CONFIGURATION CONNECTION
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Path.Combine("Configurations", "appsettings.Development.json"), optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();

            Menu.Load();

            ScreenManager.Pause();

            Database.Connection.Close();
        }
    }
}