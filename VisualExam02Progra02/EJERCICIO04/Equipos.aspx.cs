using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EJERCICIO04
{
	public partial class Equipos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LlenarGrid();
		}

		protected void LlenarGrid()
		{
			string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
			using (SqlConnection con = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT *  FROM EQUIPOS	"))
				{
					using (SqlDataAdapter sda = new SqlDataAdapter())
					{
						cmd.Connection = con;
						sda.SelectCommand = cmd;
						using (DataTable dt = new DataTable())
						{
							sda.Fill(dt);
							datagrid.DataSource = dt;
							datagrid.DataBind();  // actualizar el grid view
						}
					}
				}
			}
		}


		public void alertas(String texto)
		{
			string message = texto;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("<script type = 'text/javascript'>");
			sb.Append("window.onload=function(){");
			sb.Append("alert('");
			sb.Append(message);
			sb.Append("')};");
			sb.Append("</script>");
			ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			int retorno = Clases.Equipos.Agregar(tTipoEquipo.Text, tModelo.Text,tUsuariosID.Text);
			if (retorno > 0)
			{
				alertas("Equipo se agrego correctamente");
				LlenarGrid();
			}
			else
			{
				alertas("Equipo no agregado");

			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			int retorno = Clases.Equipos.Modificar(tUsuariosID.Text, tTipoEquipo.Text, tModelo.Text, tEquipoID.Text);
			if (retorno > 0)
			{
				alertas("Equipo modficado");
				LlenarGrid();
			}
			else
			{
				alertas("no se pudo modificar el equipo");

			}
		}

		protected void Bconsulta_Click(object sender, EventArgs e)
		{
			int retorno = Clases.Equipos.Borrar(tEquipoID.Text);
			if (retorno > 0)
			{
				alertas("Equipo se borro correctamente");
				LlenarGrid();
			}
			else
			{
				alertas("no se pudo borrar");

			}
		}
	}
}