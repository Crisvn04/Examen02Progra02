using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EJERCICIO04.Clases
{
	public class Tecnicos
	{
		public  int TecnicoID { get; set; }
		public  string Nombre { get; set; }
		public  string Especialidad { get; set; }

		public Tecnicos(int IDtecnico,string nombre,string especialidad) 
		{
			this.TecnicoID = IDtecnico;
			this.Nombre = nombre;
			this.Especialidad = especialidad;	

		}

		public Tecnicos() { }

		public static int Agregar(string Nombre,string Especialidad)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("AGREGARTECNICOS", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
					cmd.Parameters.Add(new SqlParameter("@Especialiad", Especialidad));
					retorno = cmd.ExecuteNonQuery();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				retorno = -1;
			}
			finally
			{
				Conn.Close();
			}

			return retorno;


		}
		public static int Modificar(int cod, string Nombre)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("MODIFICARTECNICO", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@Codigo", cod));
					cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
					retorno = cmd.ExecuteNonQuery();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				retorno = -1;
			}
			finally
			{
				Conn.Close();
			}

			return retorno;


		}
		public static int Borrar(int cod)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("BORRARTECNICOS", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@Codigo", cod));
					retorno = cmd.ExecuteNonQuery();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				retorno = -1;
			}
			finally
			{
				Conn.Close();
			}

			return retorno;


		}



	}
}