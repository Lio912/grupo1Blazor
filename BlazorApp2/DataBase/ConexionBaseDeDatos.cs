using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorApp2.DataBase
{
    public class ConexionBaseDeDatos
    {
        private MySqlConnection conexion;

        public ConexionBaseDeDatos()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "123456789";
            string database = "educativa";

            string cadenaConexion = $"server={servidor};port={puerto};user={usuario};password={password};database={database};";

            conexion = new MySqlConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}
