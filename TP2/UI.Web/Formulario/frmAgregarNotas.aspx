<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmAgregarNotas.aspx.cs" Inherits="UI.Web.Formulario.frmAgregarNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="50">
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="Codigo Inscripcion" DataField="IdInscripcion"></asp:BoundField>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"></asp:BoundField>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"></asp:BoundField>
                <asp:BoundField HeaderText="Materia" DataField="Desc_Materia"></asp:BoundField>
                <asp:CommandField HeaderText="Inscripcion" SelectText="Inscribir" ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField HeaderText="Seleccionar" SelectText="Agregar Nota" ShowDeleteButton="true"></asp:CommandField>
            </Columns>

        </asp:GridView>

    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">                          
                 <asp:TextBox ID="txtdesc_materia" runat="server" CssClass="cajatexto" placeholder="Materia" Enabled="false"></asp:TextBox>        
                 <asp:TextBox ID="txtnota" runat="server" CssClass="cajatexto" placeholder="Nota" Enabled="false"></asp:TextBox>
                </p>
        </asp:Panel>
   </center>
</asp:Content>
