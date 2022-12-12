namespace G_UNAMAD_CEPRE_API.Connection
{
    public class ConnectionBd
    {
        private string connectionString = string.Empty;
        public ConnectionBd()
        {
            var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = build.GetSection("ConnectionStrings:Conexion").Value;
        }

        public string cadendaSQL()
        {
            return connectionString;
        }
    }
}
