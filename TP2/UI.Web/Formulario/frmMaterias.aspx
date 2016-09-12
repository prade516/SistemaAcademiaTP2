<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/frmcarrera.master" AutoEventWireup="true" CodeBehind="frmMaterias.aspx.cs" Inherits="UI.Web.Formulario.frmMaterias" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:Panel runat="server">        
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Materia"></asp:TextBox>  
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1" OnClick="btnbuscar_Click"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <link href="../CSS/datagridview.css" rel="stylesheet" />
        <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="true" AlternatingRowStyle-CssClass="alt" PageSize="7" OnPageIndexChanging="gridview_PageIndexChanging" OnSelectedIndexChanged="gridview_SelectedIndexChanged1">
            <Columns>
                <asp:BoundField HeaderText="Codigo Materia" DataField="id_materia" />               
                <asp:BoundField HeaderText="Materia" DataField="desc_materia" />
                 <asp:BoundField HeaderText="Plan" DataField="desc_plan" />
                <asp:BoundField HeaderText="Horas Semanales" DataField="hs_semanales" />
                <asp:BoundField HeaderText="Horas Totales" DataField="hs_totales" />
                 <asp:BoundField HeaderText="Codigo plan" DataField="Id_Plan" Visible="false"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
      
    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server">
            <br />
            <p class="corto">
            <asp:TextBox ID="txtidmateria" runat="server" placeholder="Codigo materia" CssClass="cajatexto" ReadOnly="True"></asp:TextBox> 
                <asp:TextBox ID="txtplan" runat="server" CssClass="cajatexto" placeholder="Plan" ReadOnly="true"></asp:TextBox>                    
                <asp:Button ID="txtbuscaridplan" runat="server" CssClass="buttonext" Text="..." OnClick="txtbuscaridplan_Click" />
                 <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtidplan" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtdesc_materia" runat="server" CssClass="cajatexto" placeholder="Materia" ></asp:TextBox>        
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txthorasemales" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txthorasemales" runat="server" CssClass="cajatexto" placeholder="Horas semanales"></asp:TextBox>
                <asp:TextBox ID="txtHsTotales" runat="server" CssClass="cajatexto" placeholder="Totales Horas"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHsTotales" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            </p>
            <asp:TextBox ID="txtidplan" runat="server" placeholder="Codigo del plan" CssClass="cajatexto" Visible="false"></asp:TextBox>
        </asp:Panel>
   </center>   
    <div>
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="btncancelar_Click"></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button" OnClick="btnaceptar_Click1"></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" OnClick="btnEditar_Click"></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click"></asp:Button>

    </div>    
</asp:Content>
