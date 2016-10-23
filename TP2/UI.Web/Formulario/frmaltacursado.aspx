<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmaltacursado.aspx.cs" Inherits="UI.Web.Formulario.frmaltacursado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <link href="../CSS/datagridview.css" rel="stylesheet" />
    <center><h3> Elegir una comision</h3></center>
    <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
        AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Codigo Curso" DataField="IdCurso" />
            <asp:BoundField HeaderText="Comision" DataField="Desc_Comision" />
            <%--   <asp:BoundField HeaderText="Codigo Comision" DataField="IdComision"/>
                 <asp:BoundField HeaderText="Comision" DataField="Desc_comision"/>
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario"/>
                <asp:BoundField HeaderText="Cupo" DataField="Cupo"/>--%>
            <asp:CommandField HeaderText="Seleccionar" SelectText="Inscribir" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
