using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Guia8Program_II.Models
{
    public class MantenimientoNota
    {

        private SqlConnection conexion;

        private void Conectar()
        {
            
            string cadconexion = ConfigurationManager.ConnectionStrings["Gestion"].ToString();
            conexion = new SqlConnection(cadconexion);
        }

        //

        public int Ingresar(Nota subject)
        {
            /* Llamamos al método "Conectar" que tiene por objetivo iniciar la variable "conexion" con la
            conexión a la base de datos "Base8" */
             Conectar();
            // Definimos una variable para indicar las sentencias SQL a la tabla "Materias"
            SqlCommand comando = new SqlCommand("insert into Notas(codMateria,carnetEstudiante,notaObtenida, estado) values(@codMateria,@carnetEstudiante,@notaObtenida, @estado)", conexion);
            // Definimos los tipos y valores parametrizados
            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters.Add("@carnetEstudiante", SqlDbType.VarChar);
            comando.Parameters.Add("@notaObtenida", SqlDbType.VarChar);
            comando.Parameters.Add("@estado", SqlDbType.VarChar);
            // Pasamos los datos de los campos a los parámetros de la instrucción SQL
            comando.Parameters["@codMateria "].Value = subject.codMateria;
            comando.Parameters["@carnetEstudiante"].Value = subject.carnetEstudiante;
            comando.Parameters["@notaObtenida"].Value = subject.notaObtenida;
            comando.Parameters["@estado"].Value = subject.estado;
            // Abrimos la conexión a la base de datos
            conexion.Open();
            // Ejecutamos el comando "select" a la tabla "Materias"
            int i = comando.ExecuteNonQuery();
            // Cerramos la conexión
            conexion.Close();
            return i;
        }

        //

        public List<Nota> ListarTodos()
        {


Conectar();
            
            List<Nota> Notas = new List<Nota>();
           
            SqlCommand comando = new SqlCommand("select codMateria,carnetEstudiante,notaObtenida, estado from Notas",
            conexion);
         
            conexion.Open();
          
            SqlDataReader Registros = comando.ExecuteReader();
         
            while (Registros.Read())
            {
           
                Nota subject = new Nota()
                {
           
                    codMateria = Registros["codMateria"].ToString(),
                    carnetEstudiante = Registros["carnetEstudiante"].ToString(),
                    notaObtenida = Registros["notaObtenida"].ToString(),
                    estado = Registros["estado"].ToString(),
                   
                   
                };
                // Agregamos el registro a la lista
                Notas.Add(subject);
            }
            // Cerramos la conexión
            conexion.Close();
            return Notas;
        }

        //

        public Nota Consultar(string carnetEstudiante)
        {
            /* Llamamos al método "Conectar" para iniciar la variable "conexion" con la conexión a la
            base de datos "Base8" */
            Conectar();
            // Definimos una variable para indicar las sentencias SQL a la tabla "notas"
            SqlCommand comando = new SqlCommand("select codMateria, carnetEstudiante, notaObtenida, estado from Notas where carnetEstudiante = @carnetEstudiante", conexion);
            // Definimos los tipos y valores parametrizados:
            comando.Parameters.Add("@carnetEstudiante", SqlDbType.VarChar);
            comando.Parameters["@carnetEstudiante"].Value = carnetEstudiante;
           
            // Abrimos la conexión
            conexion.Open();
            /* Definimos un objeto "DataReader" que almacenará los registros generados por la consulta
            "select" a la tabla "notas" */
            SqlDataReader Registros = comando.ExecuteReader();
            // Creamos un objeto de tipo "Materia"

Nota subject = new Nota();
            // Para cada registro en el DataReader
            if (Registros.Read())
            {
                // Asignamos valores a los atributos del objeto de tipo "notas"
                subject.codMateria = Registros["codMateria"].ToString();
                subject.carnetEstudiante = Registros["carnetEstudiante"].ToString();
                subject.notaObtenida = Registros["notaObtenida"].ToString();
                subject.estado = Registros["estado"].ToString();
                
            }
            // Cerramos la conexión
            conexion.Close();
            // Regresamos el objeto de tipo "notas"
            return subject;
        }

        //

        public int Modificar(Nota subject)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("update Notas set CodMateria=@codMateria, carnetEstudiante=@carnetEstudiante, notaObtenida = @notaObtenida, estado=@estado where carnetEstudiante = @carnetEstudiante", conexion);

            comando.Parameters.Add("@carnetEstudiante", SqlDbType.VarChar);
            comando.Parameters["@carnetEstudiante"].Value = subject.carnetEstudiante;

            comando.Parameters.Add("@notaObtenida", SqlDbType.Int);
            comando.Parameters["@notaObtenida"].Value = subject.notaObtenida;

            comando.Parameters.Add("@estado", SqlDbType.VarChar);
            comando.Parameters["@estado"].Value = subject.estado;

            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters["@codMateria"].Value = subject.codMateria;


            conexion.Open();

            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }
        //

        public int Borrar(string carnetEstudiante)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("delete from Notas where carnetEstudiante=@carnetEstudiante", conexion);

            comando.Parameters.Add("@carnetEstudiante", SqlDbType.VarChar);
            comando.Parameters["@carnetEstudiante"].Value = carnetEstudiante;

            conexion.Open();

            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }

    }
}