<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.Master" AutoEventWireup="true" CodeBehind="frmpasarregularidad.aspx.cs" Inherits="UI.Web.Formulario.frmpasarregularidad" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
  <link href="../CSS/datagridview.css" rel="stylesheet" />
    <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
        AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80">
        <Columns>
            <asp:BoundField HeaderText="Codigo Materia" DataField="Id_Materia" />
            <asp:BoundField HeaderText="Materia" DataField="Desc_Materia" />
         
            <asp:CommandField HeaderText="Seleccionar" SelectText="Inscribir" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
