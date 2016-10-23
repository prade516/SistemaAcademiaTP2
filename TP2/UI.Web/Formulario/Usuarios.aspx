<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <link href="../CSS/datagridview.css" rel="stylesheet" />
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Legajo"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="id_usuario" />
                <asp:BoundField HeaderText="Codigo Persona" DataField="Id_persona" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                <asp:BoundField HeaderText="Clave" DataField="clave" />
                <asp:BoundField HeaderText="Habilidado" DataField="habilitado" />
                <asp:BoundField HeaderText="Cambia Clave" DataField="cambia_clave" />
                <asp:BoundField HeaderText="Acesso" DataField="Tipo" />
                <asp:BoundField HeaderText="Correo Electronico" DataField="Email" />
                <%--<asp:BoundField HeaderText="Tipo persona" DataField="tipo_persona"/>--%>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanal" Visible="False" runat="server">

        <asp:TextBox ID="txtidUsuario" runat="server" CssClass="cajatexto" placeholder="Codigo Usuario"></asp:TextBox>&nbsp;
        <asp:Label Text="Habilitado" runat="server" CssClass="cajatexto" Width="60px" Height="22px"></asp:Label>
        <asp:CheckBox ID="Habilitado" runat="server" CssClass="cajatexto" Width="16px" Height="22px" placeholder="Habilitado"></asp:CheckBox>
        <asp:Label Text="Cambia Clave" runat="server" CssClass="cajatexto" Width="90px" Height="22px"></asp:Label>
        <asp:CheckBox ID="CkbCambiaClave" runat="server" CssClass="cajatexto" Width="16px" Height="22px" placeholder="Habilitado" /><br />
        <asp:TextBox ID="txtnombre" runat="server" CssClass="cajatexto" placeholder="Nombre" ReadOnly="true"></asp:TextBox>
        <asp:TextBox ID="txtidpersona" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtapellido" runat="server" CssClass="cajatexto1" placeholder="Apellido" ReadOnly="true"></asp:TextBox>
        <asp:Button ID="btnbuscarreferencia" Text="..........txtbuscar" runat="server" Width="16px" Height="22px" OnClick="Unnamed1_Click" CssClass="cajatexto" />
        <br />
        <asp:TextBox ID="txtusuario" runat="server" CssClass="cajatexto" placeholder="Nombre Usuario"></asp:TextBox>
        <asp:TextBox ID="txtclave" TextMode="Password" runat="server" CssClass="cajatexto" placeholder="Clave del Usuario"></asp:TextBox>
        <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server" CssClass="cajatexto" placeholder="Repetir Clave"></asp:TextBox>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="gridActionPanel" runat="server">
        <br />
        <br />
        <br />
        <br />
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="button" Visible="false">Cancelar</asp:LinkButton>
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="button" Visible="false" ValidationGroup="Controlar">Aceptar</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="button" Visible="false">Editar</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="button" Visible="false">Eliminar</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="button">Nuevo</asp:LinkButton>
    </asp:Panel>
    <center>
   <div>
       <br /><br />
       <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red" ValidationGroup="Controlar">El nombre no puede estar vacio</asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtapellido" ErrorMessage="El apellido no puede estar vacio" ForeColor="Red" ValidationGroup="Controlar">El apellido no puede estar vacio</asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsuario" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red" ValidationGroup="Controlar">El nombre de usuario no puede estar vacio</asp:RequiredFieldValidator><br />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtclave" ErrorMessage="Debe ingresar una clave" ForeColor="Red" ValidationGroup="Controlar">Debe ingresar una clave</asp:RequiredFieldValidator><br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtRepetirClave" ErrorMessage="Las clves no coinciden" ForeColor="Red" ValidationGroup="Controlar" ControlToCompare="txtclave">Las clves no coinciden</asp:CompareValidator><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtclave" Display="Dynamic" ValidationExpression="^([Ss&gt;{80,8}])$">La Contraseña debe ser mayor que 8 carateres</asp:RegularExpressionValidator>
   </div>
    </center>

</asp:Content>
