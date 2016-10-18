<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Inscripcion.master" AutoEventWireup="true" CodeBehind="frmAgregarNotas.aspx.cs" Inherits="UI.Web.Formulario.frmAgregarNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
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
