﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/personas.master" AutoEventWireup="true" CodeBehind="frmpersonas.aspx.cs" Inherits="UI.Web.Administrador.frmInscripcion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <link href="../CSS/bootstrap-datetimepicker-standalone.css" rel="stylesheet" />
    <link href="../CSS/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="../CSS/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../JsDataPicker/bootstrap-datetimepicker.min.js"></script>
    <script src="../JsDataPicker/bootstrap-datetimepicker.min.js"></script>
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Legajo"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <link href="../CSS/datagridview.css" rel="stylesheet" />
     <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
        AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80" OnSelectedIndexChanged="gridview_SelectedIndexChanged"> 
        <Columns>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
            <asp:BoundField HeaderText="E-Mail" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Fecha Nac" DataField="Fecha_Nac" />
            <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
            <asp:BoundField HeaderText="Acesso" DataField="Tipo_Persona" />
            <asp:BoundField HeaderText="Codigo Plan" DataField="Id_Plan" />
            <asp:BoundField HeaderText="Sexo" DataField="Sexo" />
            <asp:CommandField HeaderText="Seleccionar" SelectText="Selecionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <center>
    <asp:Panel ID="estiloPanal" Visible="true" runat="server">
        <br />
        <p class="corto">
            <asp:TextBox ID="txtidPersona" runat="server" placeholder="Codigo Persona" CssClass="cajatexto" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtnombre" runat="server" CssClass="cajatexto" placeholder="Nombre" Enabled="false"></asp:TextBox>
            <asp:TextBox ID="txtapellido" runat="server" CssClass="cajatexto" placeholder="Apellido" Enabled="false"></asp:TextBox>
            <asp:TextBox ID="txtdireccion" runat="server" CssClass="cajatexto" placeholder="Direccion" Enabled="false"></asp:TextBox>
            <asp:TextBox ID="txtE_mail" runat="server" CssClass="cajatexto" placeholder="E-mail" Enabled="false"></asp:TextBox>
            <asp:TextBox ID="txttelefono" runat="server" CssClass="cajatexto" placeholder="Telefono" Enabled="false"></asp:TextBox>
            <asp:TextBox ID="fecha_nacimiento" runat="server" CssClass="cajatexto" placeholder="Fecha nacimiento" Enabled="true"></asp:TextBox>
            <%--<img src="../image/calender.png" />--%>
            <asp:TextBox ID="TxtLegajo" runat="server" CssClass="cajatexto" placeholder="Legajo" Enabled="false"></asp:TextBox>
            <asp:DropDownList ID="cblTipo_persona" runat="server" CssClass="cajatexto1" Enabled="false">
                <asp:ListItem>Elegir Categoria</asp:ListItem>
                <asp:ListItem>Administrador</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
                <asp:ListItem>Alumno</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="cblPlan" runat="server" CssClass="cajatexto1" Enabled="false" OnSelectedIndexChanged="cblPlan_SelectedIndexChanged"></asp:DropDownList>
            <asp:DropDownList ID="CblSexo" runat="server" CssClass="cajatexto1" Enabled="false">
                <asp:ListItem>Elegir Sexo</asp:ListItem>
                <asp:ListItem>M</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
            </asp:DropDownList>
        </p>
    </asp:Panel>
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" Visible="false" OnClick="btncancelar_Click"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" ValidationGroup="alta" Visible="false" OnClick="btnaceptar_Click"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" Visible="false" OnClick="btnEliminar_Click"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" Visible="false" OnClick="btnEditar_Click"></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click"></asp:Button>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar el nombre" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txtnombre"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar el Apellido" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txtapellido"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar la Direccion" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txtdireccion"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar un Correo correcto" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txtE_mail"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar el telefono" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txttelefono"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe ingresar la fecha de Nacimiento" ForeColor="Red" ValidationGroup="alta" ControlToValidate="fecha_nacimiento"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe ingresar el Legajo" ForeColor="Red" ValidationGroup="alta" ControlToValidate="TxtLegajo"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Debe ingresar el tipo de Persona" ForeColor="Red" ValidationGroup="alta" ControlToValidate="cblTipo_persona"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Debe elegir el Plan" ForeColor="Red" ValidationGroup="alta" ControlToValidate="cblPlan"></asp:RequiredFieldValidator><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingresa un e_mail corecto como ese ejemplo&lt;d@.com&gt;" ForeColor="Red" ValidationGroup="alta" ControlToValidate="txtE_mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
    </div>
    <script type="text/javascript">
        $(function () {
            $('#fecha_nacimiento').datetimepicker({
                locale: 'ru'
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('#<%=fecha_nacimiento.ClientID%>').datetimepicker({
                 changeMonth: true,
                 changeYear: true,
                 dateFormat: "dd/mm/yy"
             });

         });

    </script>
</asp:Content>
