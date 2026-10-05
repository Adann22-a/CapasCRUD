using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private SqlConnection conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practica;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public SqlConnection abrirconexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }
        public SqlConnection cerrarconexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
            
    }
}
