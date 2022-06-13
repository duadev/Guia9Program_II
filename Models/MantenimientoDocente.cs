using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Guia8Program_II.Models
{
    public class MantenimientoDocente
    {
        private SqlConnection conexion;

        private void conectar()
        {
            string cadconexion = ConfigurationManager.ConnectionStrings["Gestion"].ToString();
            conexion = new SqlConnection(cadconexion);
        }

        public int Ingresar(Docente teacher)
        {
            conectar();

            SqlCommand comando = new SqlCommand("insert into Docentes(codigoDocente, nombre, Apellido,especialidad, titulo) values(@codigoDocente, @nombre, @apellido, @especialidad,@titulo)", conexion);

            comando.Parameters.Add("@codigoDocente", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@especialidad", SqlDbType.VarChar);
            comando.Parameters.Add("@titulo", SqlDbType.VarChar);

            comando.Parameters["@codigoDocente"].Value = teacher.codigoDocente;
            comando.Parameters["@nombre"].Value = teacher.nombre;
            comando.Parameters["@apellido"].Value = teacher.apellido;
            comando.Parameters["@especialidad"].Value = teacher.especialidad;
            comando.Parameters["@titulo"].Value = teacher.titulo;

            conexion.Open();
            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }


        public List<Docente> ListarTodos()
        {
            conectar();

            List<Docente> Docentes = new List<Docente>();

            SqlCommand comando = new SqlCommand("select codigoDocente, nombre, apellido, especialidad, titulo from Docentes", conexion);

            conexion.Open();

            SqlDataReader Registros = comando.ExecuteReader();

            while (Registros.Read())
            {
                Docente teacher = new Docente()
                {
                    
                    codigoDocente = Registros["codigoDocente"].ToString(),
                    nombre = Registros["nombre"].ToString(),
                    apellido = Registros["apellido"].ToString(),
                    especialidad = Registros["especialidad"].ToString(),
                    titulo = Registros["titulo"].ToString(),
                };

                Docentes.Add(teacher);
            }

            conexion.Close();
            return Docentes;
        }

        public Docente Consultar(string codigoDocente)
        {
            conectar();

            SqlCommand comando = new SqlCommand("select codigoDocente, nombre, apellido, especialidad, titulo from Docentes where codigoDocente = @codigoDocente", conexion);
            comando.Parameters.Add("@codigoDocente", SqlDbType.VarChar);
            comando.Parameters["@codigoDocente"].Value = codigoDocente;
            conexion.Open();

            SqlDataReader Registros = comando.ExecuteReader();
            Docente teacher = new Docente();

            if (Registros.Read())
            {

                teacher.codigoDocente = Registros["codigoDocente"].ToString();
                teacher.nombre = Registros["nombre"].ToString();
                teacher.apellido = Registros["apellido"].ToString();
                teacher.especialidad = Registros["especialidad"].ToString();
                teacher.titulo = Registros["titulo"].ToString(); 
            }

            conexion.Close();
            return teacher;
        }

        public int Editar(Docente teacher)
        {
            conectar();

            SqlCommand comando = new SqlCommand("update Docentes set codigoDocente=@codigoDocente, nombre=@nombre, apellido = @apellido, especialidad = @especialidad, titulo = @titulo where codigoDocente = @codigoDocente", conexion);
           
            comando.Parameters.Add("@codigoDocente", SqlDbType.VarChar);
            comando.Parameters["@codigoDocente"].Value = teacher.codigoDocente;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = teacher.nombre;

            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters["@apellido"].Value = teacher.apellido;

            comando.Parameters.Add("@especialidad", SqlDbType.VarChar);
            comando.Parameters["@especialidad"].Value = teacher.especialidad;

            comando.Parameters.Add("@titulo", SqlDbType.VarChar);
            comando.Parameters["@titulo"].Value = teacher.titulo;

            conexion.Open();

            int i = comando.ExecuteNonQuery();
         
            conexion.Close();
            return i;

        }

        public int Borrar(string codigoDocente)
        {
          
            conectar();
           
            SqlCommand comando = new SqlCommand("delete Docentes where codigoDocente=@codigoDocente", conexion);
     
            comando.Parameters.Add("@codigoDocente", SqlDbType.VarChar);
            comando.Parameters["@codigoDocente"].Value = codigoDocente;
         
            conexion.Open();

            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;
        }


    }
}