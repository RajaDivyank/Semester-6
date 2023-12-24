namespace Hotel_Management.DAL
{
    public class DAL_Helper
    {
        public static string ConnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
