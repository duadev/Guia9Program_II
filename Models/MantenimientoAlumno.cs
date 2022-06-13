using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Guia8Program_II.Models
{
    public class MantenimientoAlumno
    {

        private SqlConnection conexion;

        private void Conectar()
        {
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["Gestion"].ToString();
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception)

            {
                return;
            }
        }


        public int Agregar(Alumnos estudiante)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("insert into Alumnos(Carnet, Nombres, Apellidos, Direccion, Sexo, Telefono, Email) values(@carnet, @Nombre, @Apellido, @direccion, @sexo, @telefono, @correo)", conexion);

            comando.Parameters.Add("@carnet", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);

            comando.Parameters["@carnet"].Value = estudiante.Carnet;
            comando.Parameters["@nombre"].Value = estudiante.Nombres;
            comando.Parameters["@apellido"].Value = estudiante.Apellidos;
            comando.Parameters["@direccion"].Value = estudiante.Direccion;
            comando.Parameters["@sexo"].Value = estudiante.Sexo;
            comando.Parameters["@telefono"].Value = estudiante.Telefono;
            comando.Parameters["@correo"].Value = estudiante.Email;

            conexion.Open();

            int i = comando.ExecuteNonQuery();
            conexion.Close();

            return i;

        }

        internal int Editar(Alumnos student)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("update Alumnos set Carnet=@carnet, Nombres=@nombres,Apellidos = @apellidos, Direccion = @direccion, Sexo = @sexo, Telefono = @telefono, Email = @correo where Carnet = @carnet", conexion);

            comando.Parameters.Add("@nombres", SqlDbType.VarChar);
            comando.Parameters["@nombres"].Value = student.Nombres;
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters["@apellidos"].Value = student.Apellidos;
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = student.Direccion;
            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters["@sexo"].Value = student.Sexo;
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@telefono"].Value = student.Telefono;
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters["@correo"].Value = student.Email;
            comando.Parameters.Add("@carnet", SqlDbType.VarChar);
            comando.Parameters["@carnet"].Value = student.Carnet;

            conexion.Open();
       
            int i = comando.ExecuteNonQuery();
    
            conexion.Close();
            return i;
        }

        public int Eliminar(string carnet)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("delete from Alumnos where Carnet=@carnet", conexion);
            comando.Parameters.Add("@carnet", SqlDbType.VarChar);
            comando.Parameters["@carnet"].Value = carnet;

            conexion.Open();
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            return i;
        }


        public Alumnos Consultar(string carnet)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("select Carnet, Nombres, Apellidos, Direccion, Sexo, Telefono, Email from Alumnos where Carnet=@carnet", conexion);
            comando.Parameters.Add("@carnet", SqlDbType.VarChar);
            comando.Parameters["@carnet"].Value = carnet;

            conexion.Open();

            SqlDataReader Registros = comando.ExecuteReader();

            Alumnos student = new Alumnos();

            if (Registros.Read())
            {
                student.Carnet = Registros["carnet"].ToString();
                student.Nombres = Registros["nombres"].ToString();
                student.Apellidos = Registros["apellidos"].ToString();
                student.Direccion = Registros["direccion"].ToString();
                student.Sexo = Registros["sexo"].ToString();
                student.Telefono = Registros["telefono"].ToString();
                student.Email = Registros["email"].ToString();
            }

            conexion.Close();

            return student;
        }


        public List<Alumnos> ListarAlumnos()
        {

            Conectar();

            List<Alumnos> Alumnos = new List<Alumnos>();

            SqlCommand comando = new SqlCommand("select Carnet, Nombres, Apellidos, Direccion, Sexo, Telefono, Email from Alumnos", conexion);

            conexion.Open();

            SqlDataReader Registros = comando.ExecuteReader();
            while (Registros.Read())
            {
                Alumnos student = new Alumnos()
                {
                    Carnet = Registros["Carnet"].ToString(),
                    Nombres = Registros["Nombres"].ToString(),
                    Apellidos = Registros["Apellidos"].ToString(),
                    Direccion = Registros["Direccion"].ToString(),
                    Sexo = Registros["Sexo"].ToString(),
                    Telefono = Registros["Telefono"].ToString(),
                    Email = Registros["Email"].ToString(),

                };

                Alumnos.Add(student);

            }
            conexion.Close();
            return Alumnos;

        }



     
    }
}