<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmMaterias.aspx.cs" Inherits="UI.Web.Formulario.frmMaterias" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="10" OnPageIndexChanging="gridview_PageIndexChanging" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Codigo Materia" DataField="Id_Materia" />
                <asp:BoundField HeaderText="Materia" DataField="Desc_Materia" />
                <asp:BoundField HeaderText="" />
                <asp:BoundField HeaderText="Plan" DataField="Plan" />
                <asp:BoundField HeaderText="Horas Semanales" DataField="Hs_Semanales" />
                <asp:BoundField HeaderText="Horas Totales" DataField="Hs_Totales" />
                <asp:BoundField HeaderText="Codigo plan" DataField="Id_Plan" Visible="false" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidmateria" runat="server" placeholder="Codigo materia" CssClass="cajatexto" ReadOnly="True"></asp:TextBox>                 
                 <asp:TextBox ID="txtdesc_materia" runat="server" CssClass="cajatexto" placeholder="Materia" Enabled="false"></asp:TextBox>        
                 <asp:TextBox ID="txthorasemales" runat="server" CssClass="cajatexto" placeholder="Horas semanales" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="txtHsTotales" runat="server" CssClass="cajatexto" placeholder="Totales Horas" Enabled="false"></asp:TextBox>
                <asp:Label ID="LabelPlan" runat="server" Text="Plan" CssClass="cajatexto3" ReadOnly="True"></asp:Label>              
                <asp:DropDownList ID="cbldPlan" runat="server" CssClass="cajatexto1" Enabled="false"></asp:DropDownList> 
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
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btncancelar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click1" ValidationGroup="alta" Visible="false"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" OnClick="btnEliminar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" OnClick="btnEditar_Click" Visible="false"></asp:Button>        
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click"></asp:Button>

    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txthorasemales" ErrorMessage="Debe ingresar la cantidad de hora semanal" ForeColor="Red" ValidationGroup="alta"></asp:RequiredFieldValidator>
        <br />
    </div>
</asp:Content>
