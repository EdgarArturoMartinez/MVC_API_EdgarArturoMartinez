using Api_EdgarArturoMartinez.Model;
using System.Data.SqlClient;

namespace Api_EdgarArturoMartinez.Repository
{
    public static class ProductoVendidoHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<ProductoVendido> GetProductosVendidos()
        {           
            List<ProductoVendido> soldProductList = new List<ProductoVendido>();
            string query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProductoVendido objSoldProduct = new ProductoVendido();
                        objSoldProduct.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objSoldProduct.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        objSoldProduct.IdProducto = Convert.ToInt32(sqlDataReader["IdProducto"]);
                        objSoldProduct.IdVenta = Convert.ToInt32(sqlDataReader["IdVenta"]);

                        soldProductList.Add(objSoldProduct);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }          

            return soldProductList;
        }
    }
}
