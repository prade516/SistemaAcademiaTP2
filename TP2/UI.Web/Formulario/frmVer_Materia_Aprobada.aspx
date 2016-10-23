<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmVer_Materia_Aprobada.aspx.cs" Inherits="UI.Web.Formulario.frmVer_Materia_Aprobada" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
   <asp:Panel ID="gridPanel" runat="server">
       <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="30" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Codigo Inscripcion" DataField="IdInscripcion" />
                <asp:BoundField HeaderText="Materia" DataField="Desc_Materia" />
                <%--<asp:BoundField HeaderText="Apellido" DataField="Apellido" />--%>
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <%--<asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />--%>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
