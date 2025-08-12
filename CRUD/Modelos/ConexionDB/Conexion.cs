using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modelos
{
    public class Conexion
    {
        private static string servidor = "LAPTOP-VBIS1AO3\\SQLEXPRESS"; // Linea Cambiante
        private static string basededatos = "CINMastr";

        public static SqlConnection conectar()
        {
            //Aqui para mejorarlo falta algo llamado trycatch
            string cadena = $"Data source={servidor};Initial Catalog={basededatos};Integrated Security = true;";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;

        }
    }
}
