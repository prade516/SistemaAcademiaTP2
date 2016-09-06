<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <link href="CSS/datagridview.css" rel="stylesheet" />
    <asp:Panel ID="gridPanel" runat="server" Width="574px" >
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" GridLines="None" AllowPaging="true" CssClass="tamcol" PagerStyle-CssClass="pgr"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" HeaderStyle-BackColor="#99ccff" OnSelectedIndexChanged="gridview_SelectedIndexChanged" AlternatingRowStyle-CssClass="alt" Width="574px"   >
            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="id_usuario" />
                <asp:BoundField HeaderText="Codigo persona" DataField="id_persona" />
                <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                <asp:BoundField HeaderText="Clave" DataField="clave" />
                <asp:BoundField HeaderText="Habilidado" DataField="habilitado" />
                <asp:BoundField HeaderText="Cambia Clave" DataField="cambia_clave" />
                <%--<asp:BoundField HeaderText="Tipo persona" DataField="tipo_persona"/>--%>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanal" Visible="False" runat="server">

        <asp:Label ID="CodigoLabel" runat="server" Text="Codigo"></asp:Label>
        <asp:TextBox ID="txtidUsuario" runat="server"></asp:TextBox>      

        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado"></asp:Label>
        <asp:CheckBox ID="Habilitado" runat="server"></asp:CheckBox><br/>

        <asp:Label ID="nombreLabel" runat="server" Text="Nombre" ></asp:Label>
        <asp:TextBox ID="txtnombre" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="El nombre no puede estar vacio" ForeColor="Red">*</asp:RequiredFieldValidator>

        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido" ></asp:Label>
        <asp:TextBox ID="txtapellido" runat="server" Enabled="false"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtapellido" ErrorMessage="El apellido no puede estar vacio" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:Button  Text=".....txtbuscar" runat="server" Width="16px" Height="22px"/>
        <br/>
        <asp:Label ID="usuarioLabel" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtusuario" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtidUsuario" ErrorMessage="El nombre de usuario no puede estar vacio" ForeColor="Red">*</asp:RequiredFieldValidator>

        <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtclave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtclave" ErrorMessage="Debe ingresar una clave" ForeColor="Red">*</asp:RequiredFieldValidator>

        <asp:Label ID="repetirClveLabel" runat="server" Text="Repetir Clave"></asp:Label>
        <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtclave" ErrorMessage="Las clves no coinciden" ForeColor="Red">*</asp:CompareValidator>
    </asp:Panel>
    <br/>
    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <br/>
    <asp:Panel ID="formActionPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
