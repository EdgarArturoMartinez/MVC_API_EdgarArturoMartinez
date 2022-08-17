using Api_EdgarArturoMartinez.Model;
using System.Data.SqlClient;

namespace Api_EdgarArturoMartinez.Repository
{
    public static class ProductoHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<Producto> GetProductos()
        {
            List<Producto> productsList = new List<Producto>();
            string query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Producto objProducto = new Producto();
                        objProducto.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objProducto.Descripciones = sqlDataReader["Descripciones"].ToString();
                        objProducto.Costo = Convert.ToDouble(sqlDataReader["Costo"]);
                        objProducto.PrecioVenta = Convert.ToDouble(sqlDataReader["PrecioVenta"]);
                        objProducto.Stock = Convert.ToInt32(sqlDataReader["Stock"]);
                        objProducto.IdUsuario = Convert.ToInt32(sqlDataReader["IdUsuario"]);
                        productsList.Add(objProducto);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }
            return productsList;    
        }
    }
}
