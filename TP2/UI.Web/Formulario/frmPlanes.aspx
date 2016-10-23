<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmPlanes.aspx.cs" Inherits="UI.Web.Formulario.frmPlanes" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="7" OnSelectedIndexChanged="gridview_SelectedIndexChanged" OnPageIndexChanging="gridview_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Codigo Plan" DataField="Codigo" />
                <asp:BoundField HeaderText="Plan" DataField="Plan" />
                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidplan" runat="server" placeholder="Codigo Plan" CssClass="cajatexto" ReadOnly="True"></asp:TextBox> 
                <asp:TextBox ID="txtDesc_plan" runat="server" CssClass="cajatexto" placeholder="Plan" Enabled="false"></asp:TextBox>                 
                <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad" CssClass="cajatexto3" ReadOnly="True"></asp:Label> 
                 <asp:DropDownList ID="cbldEspecialidad" runat="server" CssClass="cajatexto1" Enabled="false">
                </asp:DropDownList>
            </p>
            
        </asp:Panel>
   </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btncancelar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click" Visible="false" ValidationGroup="Controlar"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" Visible="false" OnClick="btnEliminar_Click"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" OnClick="btnEditar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click"></asp:Button>
    </div>

    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar el Plan" ForeColor="Red" ValidationGroup="Controlar" ControlToValidate="txtDesc_plan"></asp:RequiredFieldValidator>
    </div>
</asp:Content>
