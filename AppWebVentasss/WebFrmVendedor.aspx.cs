using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Datos.Admin;
using System.Data;
using Datos.Models;
namespace AppWebVentasss
{
    public partial class WebFrmVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               MostrarVendedores();
                MostrarCombo();
            }
           
        }

        private void MostrarVendedores()
        {
            gridVendedor.DataSource = AdmVendedor.Listar();
            gridVendedor.DataBind();
        }

        private void MostrarCombo()
        {
            DataTable dt = AdmVendedor.ListarComision();
            ddlComision.Items.Add("[TODAS]");
            foreach (DataRow item in dt.Rows)
            {
                ddlComision.Items.Add(item["Comision"].ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Vendedor vendedor = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtapellido.Text,
                DNI = txtDni.Text,
                Comision=Convert.ToDecimal(txtComision.Text)
        };
            int filasAfectadas = AdmVendedor.Insertar(vendedor);
            FuncFilasAfectadas(filasAfectadas);

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtapellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtComision.Text = string.Empty;
            txtTraerID.Text= string.Empty;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            
            Vendedor vendedor = new Vendedor()
            {
                Id= Convert.ToInt32(txtTraerID.Text),
                Nombre = txtNombre.Text,
                Apellido = txtapellido.Text,
                DNI = txtDni.Text,
                Comision = Convert.ToDecimal(txtComision.Text)
            };
            int filasAfectadas = AdmVendedor.Modificar(vendedor);
            FuncFilasAfectadas(filasAfectadas);
            LimpiarCampos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTraerID.Text);
            int filasAfectadas = AdmVendedor.Eliminar(id);
            FuncFilasAfectadas(filasAfectadas);
            LimpiarCampos();
        }

        private void FuncFilasAfectadas(int filasAfectadas)
        {
            if (filasAfectadas > 0)
            {
                MostrarVendedores();
            }
        }

        protected void btnTraerID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTraerID.Text);
            gridVendedor.DataSource = AdmVendedor.TraerPorId(id);
            gridVendedor.DataBind();
            LimpiarCampos();
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            MostrarVendedores();
        }

        protected void ddlComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comisionCombo = ddlComision.SelectedItem.ToString();
            if (comisionCombo == "[TODAS]")
            {
                MostrarVendedores();
            }
            else
            {
                decimal comision = Convert.ToDecimal(ddlComision.SelectedValue);
                gridVendedor.DataSource = AdmVendedor.TraerVendedores(comision);
                gridVendedor.DataBind();
            }
        }
    }
}