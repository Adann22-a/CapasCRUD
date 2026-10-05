using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion Conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = Conexion.abrirconexion();
            comando.CommandText = "Mostar Productos";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.cerrarconexion();

            return tabla;

        }
        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            comando.Connection = Conexion.abrirconexion();
            comando.CommandText = "InsertarPreoducxtos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@Descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrarconexion();


        }
        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            comando.Connection = Conexion.abrirconexion();
            comando.CommandText = "EditarProductos";

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", precio);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrarconexion();



        }

        public void Eliminar(int id)
        {
            comando.Connection = Conexion.abrirconexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrarconexion();

        }

    }
}
