using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EJERCICIO04.Clases
{
	public class Usuarios
	{
		public string UsuariosID { get; set; }
		public string Nombre { get; set; }
		public string CorreoElectronico { get; set; }
		public string Telefono { get; set; }

		public Usuarios(string IDusuarios, string nombre, string correoElectronico, string telefono)
		{
			this.UsuariosID = IDusuarios;
			this.Nombre = nombre;
			this.CorreoElectronico = correoElectronico;
			this.Telefono = telefono;

		}

		public Usuarios() { }

	
		public static int Agregar(string UsuariosID, string Nombre, string CorreoElectronico, string Telefono)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("AGREGARUSUARIO", Conn)
					{
						CommandType = CommandType.StoredProcedure
					};
					cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
					cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", CorreoElectronico));
					cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
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
		public static int Modificar(int cod,string Nombre)
		{
			int retorno = 0;

			SqlConnection Conn = new SqlConnection();
			try
			{
				using (Conn = DBConn.obtenerConexion())
				{
					SqlCommand cmd = new SqlCommand("MODIFICARUSUARIO", Conn)
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
	}	}