<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmListaPersona.aspx.cs" Inherits="UI.Web.Administrador.frmmaterias" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="Contenidomenucontextual" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenidoprincipal" runat="server">
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
            <asp:BoundField HeaderText="Acesso" DataField="Tipo_Persona" />
            <%--   <asp:BoundField HeaderText="E-Mail" DataField="Email" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Fecha Nac" DataField="Fecha_Nac" />
            <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
            <asp:BoundField HeaderText="Acesso" DataField="Tipo_Persona" />
            <asp:BoundField HeaderText="Codigo Plan" DataField="Id_Plan" />
            <asp:BoundField HeaderText="Sexo" DataField="Sexo" />--%>
            <asp:CommandField HeaderText="Seleccionar" SelectText="Selecionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
