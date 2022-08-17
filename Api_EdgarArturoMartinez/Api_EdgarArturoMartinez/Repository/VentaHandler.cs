using Api_EdgarArturoMartinez.Model;
using System.Data.SqlClient;

namespace Api_EdgarArturoMartinez.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<Venta> GetVentas()
        {            
            List<Venta> salesList = new List<Venta>();
            string query = "SELECT Id, Comentarios FROM Venta";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Venta objSales = new Venta();
                        objSales.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objSales.Comentarios = sqlDataReader["Comentarios"].ToString();
                        salesList.Add(objSales);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }           

            return salesList;
        }
    }
}
