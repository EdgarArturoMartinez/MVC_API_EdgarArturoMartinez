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

        public static bool EliminarProductoVendido(int Id)
        {
            bool result = false;
            string query = "DELETE FROM ProductoVendido " +
                "WHERE Id = @id";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", Id);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }


        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {
            bool result = false;
            string query = "INSERT INTO ProductoVendido" +
                "(Stock, IdProducto, IdVenta)" +
                "VALUES (@stock, @idProducto, 1)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@stock", productoVendido.Stock);
                sqlCommand.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);

                try
                {
                    sqlConnection.Open();
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        result = true;
                    }
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
                return result;
            }
        }
    }
}
