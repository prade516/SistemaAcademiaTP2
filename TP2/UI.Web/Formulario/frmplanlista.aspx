<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/frmcarrera.master" AutoEventWireup="true" CodeBehind="frmplanlista.aspx.cs" Inherits="UI.Web.Formulario.frmplanlista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <div>
        <asp:Panel ID="gridPanel" runat="server">
            <link href="../CSS/datagridview.css" rel="stylesheet" />
            <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
                AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="7" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Codigo Plan" DataField="Codigo" />
                    <asp:BoundField HeaderText="Plan" DataField="Plan" />
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblTotal" runat="server"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
