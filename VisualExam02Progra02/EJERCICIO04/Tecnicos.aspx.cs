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
	public partial class Tecnicos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LlenarGrid();
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

		protected void LlenarGrid()
		{
			string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
			using (SqlConnection con = new SqlConnection(constr))
			{
				using (SqlCommand cmd = new SqlCommand("SELECT *  FROM TECNICOS1	"))
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

	
		protected void Button1_Click(object sender, EventArgs e)
		{
			int retorno = Clases.Tecnicos.Agregar(tNombre.Text, tEspecialidad.Text);
			if (retorno > 0)
			{
				alertas("Tecnico se agrego correctamente");
				LlenarGrid();
			}
			else
			{
				alertas("Tecnico no agregado");

			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{

			int retorno = Clases.Tecnicos.Modificar(tNombre.Text, tEspecialidad.Text, tTecnicoID.Text);
			if (retorno > 0)
			{
				alertas("Tecnico modificado correctamente");
				LlenarGrid();
			}
			else
			{
				alertas("Tecnico mmodificado correctamente");

			}
		}

		protected void Bconsulta_Click(object sender, EventArgs e)
		{
			int retorno = Clases.Tecnicos.Borrar(tTecnicoID.Text);
			if (retorno > 0)
			{
				alertas("Tecnico Borrado");
				LlenarGrid();
			}
			else
			{
				alertas("No se pudo borrar tecnico");

			}
		}
	}