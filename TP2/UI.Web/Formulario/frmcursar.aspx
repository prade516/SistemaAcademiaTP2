<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmcursar.aspx.cs" Inherits="UI.Web.Formulario.frmcursar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
     <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="50" OnSelectedIndexChanged="gridview_SelectedIndexChanged">
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="Año" DataField="Anio_especialidad"></asp:BoundField >
                <asp:BoundField HeaderText="Codigo Materia" DataField="ID"></asp:BoundField >
                <asp:BoundField HeaderText="Materia" DataField="Desc_Materia"></asp:BoundField >
                <asp:BoundField HeaderText="Plan" DataField="Plan"></asp:BoundField >
                <asp:CommandField HeaderText="Inscripcion" SelectText="Inscribir" ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField  DeleteText="Elimar" ShowDeleteButton="false"></asp:CommandField>
            </Columns>
            
        </asp:GridView>

    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidmateria" runat="server" placeholder="Codigo materia" CssClass="cajatexto" ReadOnly="True" Visible="false"></asp:TextBox>                 
                 <asp:TextBox ID="txtdesc_materia" runat="server" CssClass="cajatexto" placeholder="Materia" Enabled="false" Visible="false"></asp:TextBox>        
                 <asp:TextBox ID="txthorasemales" runat="server" CssClass="cajatexto" placeholder="Horas semanales" Enabled="false" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtHsTotales" runat="server" CssClass="cajatexto" placeholder="Totales Horas" Enabled="false" Visible="false"></asp:TextBox>
                <asp:Label ID="LabelPlan" runat="server" Text="Plan" CssClass="cajatexto3" ReadOnly="True" Visible="false"></asp:Label>              
                <asp:DropDownList ID="cbldPlan" runat="server" CssClass="cajatexto1" Enabled="false" Visible="false"></asp:DropDownList> 
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
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" Visible="false"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button"  ValidationGroup="alta" Visible="false" OnClick="btnaceptar_Click"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button"  Visible="false"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button"  Visible="false"></asp:Button>        
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" Visible="false" OnClick="btnNuevo_Click"></asp:Button>

    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txthorasemales" ErrorMessage="Debe ingresar la cantidad de hora semanal" ForeColor="Red" ValidationGroup="alta"></asp:RequiredFieldValidator>--%>
        <br />
    </div>
</asp:Content>
