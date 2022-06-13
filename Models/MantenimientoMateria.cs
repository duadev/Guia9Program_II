using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Guia8Program_II.Models
{
    public class MantenimientoMateria
    {
        private SqlConnection conexion;

        private void Conectar()
        {

            string cadconexion = ConfigurationManager.ConnectionStrings["Gestion"].ToString();
            conexion = new SqlConnection(cadconexion);
        }

        public int Ingresar(Materia subject)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("insert into Materias(codMateria, nombre, unidadValorativas) values(@codMateria, @nombre, @unidadValorativas)", conexion);

            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@unidadValorativas", SqlDbType.Int);
            // Pasamos los datos de los campos a los parámetros de la instrucción SQL
            comando.Parameters["@codMateria "].Value = subject.codMateria;
            comando.Parameters["@nombre"].Value = subject.nombre;
            comando.Parameters["@unidadValorativas"].Value = subject.unidadValorativas;

            conexion.Open();

            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }

        public List<Materia> ListarTodos()
        {

            Conectar();

            List<Materia> Materias = new List<Materia>();

            SqlCommand comando = new SqlCommand("select codMateria, nombre, unidadValorativas from Materias", conexion);

            conexion.Open();
            SqlDataReader Registros = comando.ExecuteReader();

            while (Registros.Read())
            {

                Materia subject = new Materia()
                {
                    // Almacenamos los datos de cada registro en los atributos de la clase
                    codMateria = Registros["codMateria"].ToString(),
                    nombre = Registros["nombre"].ToString(),
                    unidadValorativas = int.Parse(Registros["unidadValorativas"].ToString())
                };

                Materias.Add(subject);
            }

            conexion.Close();
            return Materias;
        }


        //

        public Materia Consultar(string codMateria)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("select codMateria, Nombre, unidadValorativas from Materias where codMateria = @codMateria", conexion);

            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters["@codMateria"].Value = codMateria;

            conexion.Open();

            SqlDataReader Registros = comando.ExecuteReader();

            Materia subject = new Materia();

            if (Registros.Read())
            {

                subject.codMateria = Registros["codMateria"].ToString();
                subject.nombre = Registros["nombre"].ToString();
                subject.unidadValorativas = int.Parse(Registros["unidadValorativas"].ToString());
            };

            conexion.Close();

            return subject;
        }

        //

        public int Modificar(Materia subject)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("update Materias set CodMateria=@codMateria, nombre=@nombre, unidadValorativas = @unidadValorativas where CodMateria = @codMateria", conexion);

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = subject.nombre;
            comando.Parameters.Add("@unidadValorativas", SqlDbType.Int);
            comando.Parameters["@unidadValorativas"].Value = subject.unidadValorativas;
            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters["@codMateria"].Value = subject.codMateria;

            conexion.Open();

            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }

        //

        public int Borrar(string codMateria)
        {

            Conectar();

            SqlCommand comando = new SqlCommand("delete from Materias where CodMateria=@codMateria", conexion);

            comando.Parameters.Add("@codMateria", SqlDbType.VarChar);
            comando.Parameters["@codMateria"].Value = codMateria;

            conexion.Open();

            int i = comando.ExecuteNonQuery();

            conexion.Close();
            return i;
        }

    }
}