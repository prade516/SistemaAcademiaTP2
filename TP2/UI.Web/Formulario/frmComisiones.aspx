<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmComisiones.aspx.cs" Inherits="UI.Web.Formulario.frmComisiones" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Comision"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <center>
    <asp:Panel ID="gridPanel" runat="server">
       <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="30" OnPageIndexChanging="gridview_PageIndexChanging" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Codigo Comision" DataField="IdComision"/>
                <asp:BoundField HeaderText="Comision" DataField="DescComision"/>
                 <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad"/>
                <asp:BoundField HeaderText="Plan" DataField="Plan"/>
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
                <asp:TextBox ID="txtidComision" runat="server" placeholder="Codigo Comision" CssClass="cajatexto" ReadOnly="True" Enabled="false"></asp:TextBox> 
                <asp:TextBox ID="txtDesc_comision" runat="server" CssClass="cajatexto" placeholder="Comision" Enabled="false"></asp:TextBox>  
                <asp:TextBox ID="txtPlan" runat="server" CssClass="cajatexto" placeholder="Comision" Visible="false"></asp:TextBox>      
                <asp:TextBox ID="txtanio_especialidad" runat="server" CssClass="cajatexto" placeholder="Año Especialidad" Enabled="false"></asp:TextBox>  
                <asp:Label ID="LabelPlan" runat="server" Text="Plan" CssClass="cajatexto3" ReadOnly="True" ></asp:Label> 
                 <asp:DropDownList ID="cbldPlan" runat="server" CssClass="cajatexto1" Enabled="false"></asp:DropDownList>                      
                          
              </p>
        </asp:Panel>
   </center> 
        <br />
        
        <br /><br /><br />   <br />      
    <div>       
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" Visible="false" OnClick="btncancelar_Click"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click" ValidationGroup="Controlar" Visible="false"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" Visible="false" OnClick="btnEliminar_Click"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" Visible="false" OnClick="btnEditar_Click" ></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click" ></asp:Button>
    </div>
        
        <br /><br /><br />   <br /> 
        <div>
            <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
            <br /> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtanio_especialidad" ErrorMessage="Debe ingresar el año de la especialidad" ForeColor="Red" ValidationGroup="Controlar"></asp:RequiredFieldValidator>
            <br /> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc_comision" ErrorMessage="Debe Ingresar la comision" ForeColor="Red" ValidationGroup="Controlar"></asp:RequiredFieldValidator>
        </div>
</asp:Content>
