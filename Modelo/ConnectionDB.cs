using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ConnectionDB
    {
        private string conexion = "Server=.\\SQLEXPRESS; Database=db_empresa; Trusted_Connection=True;";

        public SqlConnection conectar = new SqlConnection();
        public void OpenConnection()
        {
            try
            {
                conectar.ConnectionString = conexion;
                conectar.Open();
                //System.Diagnostics.Debug.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine (ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if(conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                    //System.Diagnostics.Debug.WriteLine("Conexión Cerrada con éxito.");
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
