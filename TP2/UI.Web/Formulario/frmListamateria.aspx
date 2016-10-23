<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmListamateria.aspx.cs" Inherits="UI.Web.Formulario.frmplanlista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
      <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1"></asp:Button>
    </asp:Panel>
    <div>
        <asp:Panel ID="gridPanel" runat="server">
            <link href="../CSS/datagridview.css" rel="stylesheet" />
            <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
                AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="7" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Codigo Materia" DataField="Id_Materia" />
                    <asp:BoundField HeaderText="Materia" DataField="Desc_Materia" />
                    <asp:BoundField HeaderText="Plan" DataField="Plan" />
                    <asp:BoundField HeaderText="Horas Semanales" DataField="Hs_Semanales" />
                    <asp:BoundField HeaderText="Horas Totales" DataField="Hs_Totales" />
                    <asp:BoundField HeaderText="Codigo plan" DataField="Id_Plan" Visible="false" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
