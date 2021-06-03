using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WinFormsApp1.clases


{
    class ConexionBD
    {
        string cadena = @"Data Source=DESKTOP-GI7118P\ANTHONY;Initial Catalog=Ejercicio1;Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();

        public ConexionBD()
        {
            conectarbd.ConnectionString = cadena;

        }
        public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("conexión correcta");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al conectar" + ex.Message);
            }
        }
        public void cerrar()
        {
            conectarbd.Close();
        }
    }

}
