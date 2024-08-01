using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Modelo
{
    public class Empleado
    {
        ConnectionDB connect;
        private DataTable Drop_puesto()
        {
            DataTable tabla = new DataTable();
            connect = new ConnectionDB();
            connect.OpenConnection();
            string consulta = string.Format("select id_puesto as id, puesto from Puestos");
            SqlDataAdapter query = new SqlDataAdapter(consulta, connect.conectar);
            query.Fill(tabla);
            connect.CloseConnection();            
            return tabla;
        }

        private DataTable Grid_empleados()
        {
            DataTable tabla = new DataTable();
            connect = new ConnectionDB();
            connect.OpenConnection();
            string consulta = string.Format("select e.id_empleado as id, e.codigo, e.nombres, e.apellidos, e.direccion, e.telefono, e.fecha_nacimiento, p.puesto, e.id_puesto\r\nfrom Empleados as e inner join Puestos as p on e.id_puesto = p.id_puesto");
            SqlDataAdapter query = new SqlDataAdapter(consulta, connect.conectar);
            query.Fill(tabla);
            connect.CloseConnection();
            return tabla;
        }

        public void Drop_puesto(DropDownList dropDownList)
        {
            dropDownList.ClearSelection();
            dropDownList.Items.Clear();
            dropDownList.AppendDataBoundItems = true;
            dropDownList.Items.Add("<<Elige un puesto>>");
            dropDownList.Items[0].Value = "0";
            dropDownList.DataSource = Drop_puesto();
            dropDownList.DataTextField = "puesto";
            dropDownList.DataValueField = "id";
            dropDownList.DataBind();
        }

        public void Grid_empleados(GridView gridView)
        {
            gridView.DataSource = Grid_empleados();
            gridView.DataBind();
        }

        public int Crear(string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            connect = new ConnectionDB();
            connect.OpenConnection();
            string query = string.Format("insert into empleados (codigo, nombres, apellidos, direccion, telefono, fecha_nacimiento, id_puesto) values" +
                "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6})", codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto);
            SqlCommand command = new SqlCommand(query, connect.conectar);
            command.Connection = connect.conectar;
            int numero = command.ExecuteNonQuery();
            connect.CloseConnection();
            return numero;
        }

        public int Actualizar(string codigo, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_puesto, int id)
        {
            connect = new ConnectionDB();
            connect.OpenConnection();
            string query = string.Format("update empleados set codigo = '{0}', nombres = '{1}', apellidos = '{2}'," +
                "direccion = '{3}', telefono = '{4}', fecha_nacimiento = '{5}', id_puesto = {6} where id_empleado = {7}",
                codigo, nombres, apellidos, direccion, telefono, fecha, id_puesto, id);
            SqlCommand command = new SqlCommand(query, connect.conectar);
            command.Connection = connect.conectar;
            int numero = command.ExecuteNonQuery();
            connect.CloseConnection();
            return numero;
        }

        public int Eliminar(int id)
        {
            connect = new ConnectionDB();
            connect.OpenConnection();
            string query = string.Format("delete from empleados where id_empleado = {0}",id);
            SqlCommand command = new SqlCommand(query, connect.conectar);
            command.Connection = connect.conectar;
            int numero = command.ExecuteNonQuery();
            connect.CloseConnection();
            return numero;
            //Prueba 1 para subir cambios al repositorio en github.
        }
    }
}
