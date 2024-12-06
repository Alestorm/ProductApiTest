namespace ProductsApiTest.WebApi.Infrastructure
{
    public class DatabaseConnection
    {
        public static string SetConnectionString(string server, string database, string user, string password)
        {
            return $"Persist Security Info=True;User ID = {user}; Pwd = {password}; Server = {server}; Database={database};MultipleActiveResultSets=True;TrustServerCertificate=True";
        }
    }
}
