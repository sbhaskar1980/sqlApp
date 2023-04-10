using Microsoft.Data.SqlClient;
using sqlApp.Models;
namespace sqlApp.Services
{
    public class ProductService : IProductService
    {

        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        private SqlConnection getConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = getConnection();
            List<Product> products = new List<Product>();
            string statement = "Select ProductID, ProductName, Quantity from Products";
            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };
                    products.Add(product);
                }
            }
            conn.Close();
            return products;
        }
    }
}
