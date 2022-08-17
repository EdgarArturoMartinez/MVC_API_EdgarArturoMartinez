using Api_EdgarArturoMartinez.Model;
using System.Data.SqlClient;

namespace Api_EdgarArturoMartinez.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString =
            "Data Source=YUXMED0040L;Initial Catalog=SystemManagement;User=admin;Password=admin";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> userList = new List<Usuario>();

            string query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Usuario objUsuario = new Usuario();
                        objUsuario.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        objUsuario.Nombre = sqlDataReader["Nombre"].ToString();
                        objUsuario.Apellido = sqlDataReader["Apellido"].ToString();
                        objUsuario.NombreUsuario = sqlDataReader["NombreUsuario"].ToString();
                        objUsuario.Contrasena = sqlDataReader["Contraseña"].ToString();
                        objUsuario.Mail = sqlDataReader["Mail"].ToString();
                        userList.Add(objUsuario);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    throw new Exception("There is an error on query definition! " + ex.Message);
                }
            }
            return userList;    
        }
    }
}
