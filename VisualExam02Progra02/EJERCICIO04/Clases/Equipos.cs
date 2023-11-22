using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EJERCICIO04.Clases
{
	public class Equipos
	{
		public  int EquipoID { get; set; }

		public  string TipoEquipo { get; set; }

		public  string Modelo { get; set; }

		public  string UsuarioID { get; set; }

		public Equipos(int IDequiupo,string tipoEquipo,string modelo,string usuarioID) 
		{
			this.EquipoID = IDequiupo;
			this.TipoEquipo = tipoEquipo;
			this.Modelo = modelo;
			this.UsuarioID = usuarioID;
		}

		public Equipos() { }


		public static int Agregar(int EquipoID,string TipoEquipo,string Modelo,string UsuarioID)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("AGREGAREQUIPOS", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@EquipoID", EquipoID));
					cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
					cmd.Parameters.Add(new SqlParameter("@Modelo", Modelo));
					cmd.Parameters.Add(new SqlParameter("@UsuarioID", UsuarioID));
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
		public static int Modificar(int cod, string TipoEquipo)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("MODIFICAREQUIPOS", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@Codigo", cod));
					cmd.Parameters.Add(new SqlParameter("@TipoEquipo", TipoEquipo));
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
					SqlCommand cmd = new SqlCommand("BORRARUSUARIO", Conn)
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