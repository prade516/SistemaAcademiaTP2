<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmEspecialidades.aspx.cs" Inherits="UI.Web.Formulario.frmEspecialidades" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia" OnTextChanged="txtbuscar_TextChanged"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <center>
    <asp:Panel ID="gridPanel" runat="server">
       <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="7" OnSelectedIndexChanged="gridview_SelectedIndexChanged" OnPageIndexChanging="gridview_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Codigo Especialidad" DataField="Idespecialidad" />
                <asp:BoundField HeaderText="Especialidad" DataField="DescEspecialidad" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
                <asp:TextBox ID="txtidespecialidad" runat="server" placeholder="Codigo Especialidad" CssClass="cajatexto" ReadOnly="True"></asp:TextBox> 
                <asp:TextBox ID="txtDesc_especialidad" runat="server" CssClass="cajatexto" placeholder="Especialidad" Enabled="false"></asp:TextBox>                    
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc_especialidad" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
           </p>
        </asp:Panel>
   </center> <br />
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btncancelar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click" Visible="false" ValidationGroup="Controlar"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" Visible="false" OnClick="btnEliminar_Click"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" OnClick="btnEditar_Click" Visible="false"></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click" ></asp:Button>

    </div>
        <br />
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="msgError" runat="server" ForeColor="Red" ></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar el Plan" ForeColor="Red" ValidationGroup="Controlar" ControlToValidate="txtDesc_especialidad"></asp:RequiredFieldValidator>
    </div>

</asp:Content>
