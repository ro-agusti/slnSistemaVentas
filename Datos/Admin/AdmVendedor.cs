using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Datos.Servidor;
using Datos.Models;

namespace Datos.Admin
{
   public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            // listar() vendedores
            string querySQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor";

            SqlCommand command = new SqlCommand(querySQL, AdmDB.ConectarBase());

            SqlDataReader reader;

            reader = command.ExecuteReader();

            List<Vendedor> vendedores = new List<Vendedor>();

            while (reader.Read())
            {
                vendedores.Add(
                    new Vendedor()
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        DNI = reader["DNI"].ToString(),
                        Comision = Convert.ToDecimal(reader["Comision"])
                    });
            }

            reader.Close();

            AdmDB.ConectarBase().Close();

            return vendedores;

        }

        public static DataTable TraerPorId(int id)
        {
            //TODO traerPorId(id) vendedores
            string consultaSQL = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Id=@Id";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, AdmDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Id");

            return ds.Tables["Id"];
        }

        public static DataTable ListarComision()
        {
            string querySql = "SELECT distinct Comision FROM dbo.Vendedor ";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdmDB.ConectarBase());


            DataSet ds = new DataSet();

            adapter.Fill(ds, "Comision");

            return ds.Tables["Comision"];
        }

        public static DataTable TraerVendedores(decimal comision)
        {
            // TraerVendedores(comision) vendedores


            string querySql = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Comision=@Comision";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdmDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = comision;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Comision");

            return ds.Tables["Comision"];
        }

        public static int Insertar(Vendedor vendedor)
        {
            // Insertar(vendedor) vendedores

            string querySQL = "INSERT dbo.Vendedor(Nombre,Apellido,DNI,Comision) VALUES (@Nombre,@Apellido,@DNI,@Comision)";

            SqlCommand command = new SqlCommand(querySQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;

            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;

            command.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;

            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();

            return filasAfectadas;
        }

        public static int Modificar(Vendedor vendedor)
        {
            // Modificar(vendedor) vendedores
            string querySQL = "UPDATE dbo.Vendedor SET Nombre=@Nombre, Apellido=@Apellido, DNI = @DNI, Comision = @Comision WHERE Id=@Id";

            SqlCommand command = new SqlCommand(querySQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;

            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;

            command.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;

            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.Id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();

            return filasAfectadas;
        }

        public static int Eliminar( int id )
        {
            // Eliminar(id) vendedores

            string querySQL = "DELETE FROM dbo.Vendedor where Id=@Id";

            SqlCommand command = new SqlCommand(querySQL, AdmDB.ConectarBase());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdmDB.ConectarBase().Close();

            return filasAfectadas;
        }
    }
}
