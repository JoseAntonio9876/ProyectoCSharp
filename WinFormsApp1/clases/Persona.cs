using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.clases
{
    class Persona
    {
        private int  id;
        private string nombre;
        private string apellido_p;
        private string apellido_m;
        private string correo;

        public Persona()
        {
        }

        public Persona(int id, string nombre, string apellido_p, string apellido_m, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido_p = apellido_p;
            this.apellido_m = apellido_m;
            this.correo = correo;
        }

        public int Id { get => id; set => id = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido_p { get => apellido_p; set => apellido_p = value; }
        public string Apellido_m { get => apellido_m; set => apellido_m = value; }

        public int insertar_persona()
        {
            int numero = 0;
            try
            {
                ConexionBD conexion = new ConexionBD();
                //Abres la conexión 
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("SPInserta_alumno",conexion.conectarbd);
                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Aquí agregas los parámetros de tu procedimiento
                cmd.Parameters.AddWithValue("@nom_alumno", SqlDbType.VarChar).Value=nombre;
                cmd.Parameters.AddWithValue("@apellido_p", SqlDbType.VarChar).Value=apellido_p;
                cmd.Parameters.AddWithValue("@apellido_m", SqlDbType.VarChar).Value=Apellido_m;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = correo;
               
                //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                numero = cmd.ExecuteNonQuery();

           
             
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }
           

            return numero;


       }

        public int eliminar_persona()
        {
            int numero = 0;
            try
            {
                ConexionBD conexion = new ConexionBD();
                //Abres la conexión 
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("SPEliminar_alumno", conexion.conectarbd);
                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Aquí agregas los parámetros de tu procedimiento
                cmd.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = id;
               

                //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                numero = cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }


            return numero;


        }








        public DataTable obtener_personas()
        {
            List<Persona> listPersona = new List<Persona>();
            DataTable dt = new DataTable();
            try
            {
                ConexionBD conexion = new ConexionBD();
                //Abres la conexión 
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("[SP_obtenerPersona]", conexion.conectarbd);
                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;


                //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron

                // Se recupera el lector de datos al utilizar ExecuteReader
                // SqlDataReader lector = cmd.ExecuteReader();
                SqlDataAdapter  sda = new SqlDataAdapter(cmd);
               
                sda.Fill(dt);
               



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }

            return dt;
        }



        public int actualiza_persona()
        {
            int numero = 0;
            try
            {
                ConexionBD conexion = new ConexionBD();
                //Abres la conexión 
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("SP_actualiza_persona", conexion.conectarbd);
                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Aquí agregas los parámetros de tu procedimiento
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.AddWithValue("@apellidop", SqlDbType.VarChar).Value = apellido_p;
                cmd.Parameters.AddWithValue("@apellidom", SqlDbType.VarChar).Value = Apellido_m;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = correo;
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                numero = cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }


            return numero;


        }

        public DataTable buscar_persona()
        {
            DataTable dt = new DataTable();
            try
            {
                ConexionBD conexion = new ConexionBD();
                //Abres la conexión 
                conexion.abrir();
                SqlCommand cmd = new SqlCommand("SP_buscarPersona", conexion.conectarbd);
                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //Aquí agregas los parámetros de tu procedimiento
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;


                //Le indicas al SqlCommando que lo que va a ejecutar es Tipo Procedimiento Almacenado
                cmd.CommandType = CommandType.StoredProcedure;


                //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron

                // Se recupera el lector de datos al utilizar ExecuteReader
                // SqlDataReader lector = cmd.ExecuteReader();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }


            return dt;


        }

    }


}
