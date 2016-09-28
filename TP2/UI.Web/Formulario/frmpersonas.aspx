<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/personas.master" AutoEventWireup="true" CodeBehind="frmpersonas.aspx.cs" Inherits="UI.Web.Administrador.frmInscripcion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenidoprincipal" runat="server">
      <link href="../CSS/datagridview.css" rel="stylesheet" />
    <asp:GridView ID="gridview" runat="server"  AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="Direccion" DataField="Direccion"/>
                <asp:BoundField HeaderText="E-Mail" DataField="Email"/>
                <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                 <%--<asp:BoundField HeaderText="Legajo" DataField="Legajo"/>--%>
                <asp:BoundField HeaderText="Acesso" DataField="Tipo_Persona"/>
                <%--<asp:BoundField HeaderText="Sexo" DataField="Sexo"/>--%>
                <asp:CommandField HeaderText="Seleccionar" SelectText="Selecionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView> 
    <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidPersona" runat="server" placeholder="Codigo Persona" CssClass="cajatexto" ReadOnly="True"></asp:TextBox>                 
                 <asp:TextBox ID="txtnombre" runat="server" CssClass="cajatexto" placeholder="Nombre" Enabled="false"></asp:TextBox>        
                 <asp:TextBox ID="txtapellido" runat="server" CssClass="cajatexto" placeholder="Apellido" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="txtdireccion" runat="server" CssClass="cajatexto" placeholder="Direccion" Enabled="false"></asp:TextBox>
                  <asp:TextBox ID="txtE_mail" runat="server" CssClass="cajatexto" placeholder="E-mail" Enabled="false"></asp:TextBox>        
                 <asp:TextBox ID="txttelefono" runat="server" CssClass="cajatexto" placeholder="Telefono" Enabled="false"></asp:TextBox>
                <asp:Calendar ID="cdFecha_nac" runat="server" placeholder="Fecha Nacimiento"  ></asp:Calendar>
                <asp:TextBox ID="TxtLegajo" runat="server" CssClass="cajatexto" placeholder="Legajo" Enabled="false"></asp:TextBox>         
                <asp:DropDownList ID="cblTipo_persona" runat="server" CssClass="cajatexto1" Enabled="false"></asp:DropDownList> 
                 <asp:DropDownList ID="cblPlan" runat="server" CssClass="cajatexto1" Enabled="false"></asp:DropDownList> 
                 <asp:DropDownList ID="CblSexo" runat="server" CssClass="cajatexto1" Enabled="false"></asp:DropDownList> 
                </p>
        </asp:Panel>
   </center>
    <br />
    <br />
    <br />
     <br />
    <br />
    <br />
     <br />    
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button"  Visible="false"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button"  ValidationGroup="alta" Visible="false"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button"  Visible="false"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button"  Visible="false"></asp:Button>        
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" ></asp:Button>

    </div>
</asp:Content>
