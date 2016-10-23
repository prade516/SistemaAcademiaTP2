<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmexamen.aspx.cs" Inherits="UI.Web.Formulario.frmexamen" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
     <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="50" OnSelectedIndexChanged="gridview_SelectedIndexChanged" >
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="Año" DataField="Anio_especialidad"></asp:BoundField >
                <asp:BoundField HeaderText="Codigo Materia" DataField="ID"></asp:BoundField >
                <asp:BoundField HeaderText="Materia" DataField="Desc_Materia"></asp:BoundField >
                <asp:BoundField HeaderText="Plan" DataField="Plan"></asp:BoundField >
                <asp:CommandField HeaderText="Inscripcion" SelectText="Inscribir" ShowSelectButton="True"></asp:CommandField>
            </Columns>            
        </asp:GridView>

    </asp:Panel>
</asp:Content>
