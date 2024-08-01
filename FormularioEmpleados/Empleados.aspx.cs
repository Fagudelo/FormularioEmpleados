using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioEmpleados
{
    public partial class Empleados : System.Web.UI.Page
    {
        Empleado empleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empleado = new Empleado();
                empleado.Drop_puesto(Drl_puesto);
                empleado.Grid_empleados(Grid_empleados);
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if (empleado.Crear(txt_codigo.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fecha.Text, Convert.ToInt32(Drl_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Ingreso exitoso.";
                empleado.Grid_empleados(Grid_empleados);
            }
        }

        protected void Grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codigo.Text = Grid_empleados.SelectedRow.Cells[2].Text;
            txt_nombres.Text = Grid_empleados.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = Grid_empleados.SelectedRow.Cells[4].Text;
            txt_direccion.Text = Grid_empleados.SelectedRow.Cells[5].Text;
            txt_telefono.Text = Grid_empleados.SelectedRow.Cells[6].Text;
            DateTime fecha = Convert.ToDateTime(Grid_empleados.SelectedRow.Cells[7].Text);
            txt_fecha.Text = fecha.ToString("yyyy-MM-dd");
            int indice = Grid_empleados.SelectedRow.RowIndex;
            Drl_puesto.SelectedValue = Grid_empleados.DataKeys[indice].Values["id_puesto"].ToString();
            btn_actualizar.Visible = true;
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            empleado = new Empleado();
            if (empleado.Actualizar(txt_codigo.Text, txt_nombres.Text, txt_apellidos.Text, txt_direccion.Text, txt_telefono.Text, txt_fecha.Text, Convert.ToInt32(Drl_puesto.SelectedValue), Convert.ToInt32(Grid_empleados.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificación exitosa.";
                empleado.Grid_empleados(Grid_empleados);
            }
        }

        protected void Grid_empleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            empleado = new Empleado();
            if (empleado.Eliminar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Eliminación exitosa.";
                empleado.Grid_empleados(Grid_empleados);
            }
        }
    }
}