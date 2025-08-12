using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Modelos
{
    public class Peliculas
    {
        private int id;
        private string nombre;
        private string director;
        private DateTime fechaLanzamiento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Director { get => director; set => director = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }
       
        

        public static DataTable CargarPeliculas()
        {
            SqlConnection conexion = Conexion.conectar();
            string comando = "select * from peliculas;";
            SqlDataAdapter adapter = new SqlDataAdapter(comando, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;


        }

        public bool InsertarPeliculas()
        {
            SqlConnection conexion = Conexion.conectar();
            string comando = "Insert into peliculas(nombre, director, fechaLanzamiento)"
                + "values (@nombre, @director, @fechaLanzamiento);";
            SqlCommand cmd = new SqlCommand(comando, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fechaLanzamiento", fechaLanzamiento);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool EliminarPeliculas(int id)
        {
            SqlConnection con = Conexion.conectar();

            string comando = "Delete from peliculas, where id = @id;";
            
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.ExecuteNonQuery() > 0)
            //este error que se presenta a la hora de borrar no existia al principio ,
            //cunado agrege el metodo actualizar y el doble clic no se como solucionarlo enserio
            //ya intente muchas cosas y no funciona nada
            {
                return true;

            }else
            {
                return false;
            }

        }



        public bool ActualizarPelicula () {

            SqlConnection con = Conexion.conectar();
            string comando = "UPDATE  Peliculas SET   nombre = @nombre "
                + ", director = @director  , fechaLanzamiento = @fecha WHERE id = @id; ";
            
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@director", director);
            cmd.Parameters.AddWithValue("@fecha", fechaLanzamiento);
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.ExecuteNonQuery() > 0)
                return true;
            
            else
                return false;
            
    
    
        }
    }
}

