<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/frmcarrera.master" AutoEventWireup="true" CodeBehind="frmPlanes.aspx.cs" Inherits="UI.Web.Formulario.frmPlanes" %>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">        
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia"></asp:TextBox>  
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1"></asp:Button>
    </asp:Panel>
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
      
    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidplan" runat="server" placeholder="Codigo Plan" CssClass="cajatexto" ReadOnly="True"></asp:TextBox> 
                <asp:TextBox ID="txtDesc_plan" runat="server" CssClass="cajatexto" placeholder="Plan" ReadOnly="true"></asp:TextBox>                 
               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtidplan" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtdesc_especialidad" runat="server" CssClass="cajatexto" placeholder="Especialidad" ReadOnly="true" ></asp:TextBox>        
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txthorasemales" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtid_especialidad" runat="server" CssClass="cajatexto" placeholder="Codigo especialidad" Visible="false"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHsTotales" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="LabelEspecialidad" runat="server" Text="Especialidad" CssClass="cajatexto3" ReadOnly="True"></asp:Label> 
                 <asp:DropDownList ID="cbldEspecialidad" runat="server" CssClass="cajatexto1">
                </asp:DropDownList>
            </p>
            
        </asp:Panel>
   </center>
     <br /><br /><br /><br /><br />
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btncancelar_Click" ></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click" ></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" OnClick="btnEditar_Click" ></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click" ></asp:Button>
    </div>
</asp:Content>
