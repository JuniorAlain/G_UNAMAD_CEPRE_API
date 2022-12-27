namespace G_UNAMAD_CEPRE_API.Connection
{
    public class ConnectionDb
    {
        private string connectionString = string.Empty;
        public ConnectionDb()
        {
            var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = build.GetSection("ConnectionStrings:Conexion").Value;
        }

        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
