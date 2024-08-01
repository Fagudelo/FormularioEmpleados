<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="FormularioEmpleados.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Formulario de Empleados</h1>
    <asp:Label ID="Lbl_Codigo" runat="server" Text="Código" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control" placeholder="Código"></asp:TextBox>
    <asp:Label ID="lbl_nombres" runat="server" Text="Nombres" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control" placeholder="Nombres"></asp:TextBox>
    <asp:Label ID="lbl_apellidos" runat="server" Text="Apellidos" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_apellidos" runat="server" CssClass="form-control" placeholder="Apellidos"></asp:TextBox>
    <asp:Label ID="lbl_direccion" runat="server" Text="Dirección" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" placeholder="Direccion"></asp:TextBox>
    <asp:Label ID="lbl_telefono" runat="server" Text="Teléfono" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" placeholder="Teléfono" TextMode="Number"></asp:TextBox>
    <asp:Label ID="lbl_fecha" runat="server" Text="Fecha de Nacimiento" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:TextBox ID="txt_fecha" runat="server" CssClass="form-control" placeholder="Fecha Nacimiento" TextMode="Date"></asp:TextBox>
    <asp:Label ID="lbl_puesto" runat="server" Text="Puesto" CssClass="badge" Font-Size="Small" ForeColor="Black"></asp:Label>
    <asp:DropDownList ID="Drl_puesto" runat="server" CssClass="form-control"></asp:DropDownList><br />
    <asp:Button ID="btn_guardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_guardar_Click" />
    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btn_actualizar_Click" Visible="False" />
    <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>
    <br /><br />
    <asp:GridView ID="Grid_empleados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="id,id_puesto" OnRowDeleting="Grid_empleados_RowDeleting" OnSelectedIndexChanged="Grid_empleados_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_select" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_eliminar" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="codigo" HeaderText="Código" />
            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="puesto" HeaderText="Puesto" />
        </Columns>
    </asp:GridView>
</asp:Content>