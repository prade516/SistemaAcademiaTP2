<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.master" AutoEventWireup="true" CodeBehind="frmCursos.aspx.cs" Inherits="UI.Web.Formulario.frmCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <%--  <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/bootstrap-chosen.css" rel="stylesheet" />
    <script src="../JS/bootstrap.min.js"></script>

    <script src="../JS/respond.min.js"></script>
    <script src="../JS/html5shiv.min.js"></script>--%>

    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
   <%-- <script src="../JS/jquery-1.8.0.js"></script>
    <script src="../JS/jquery-ui.js"></script>
    <script src="../JS/jquery-ui.min.js"></script>
    <script src="../JS/jquery.min.js"></script>
    <script src="../JS/jquery.min1.js"></script>
    <link href="../CSS/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $("#Txtcupo").autocomplete({
                source: function (request, responde) {
                    var param = { id_materia: $("Txtcupo").val() };
                    $.ajax({
                        url: "frmMaterias.aspx/Buscar",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json:charset=utf-8",
                        dataFilter: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value:item
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(errorThrown);
                        }                            
                    })
                }
            });
        });--%>
    </script>
    <asp:Panel runat="server">
        <asp:TextBox ID="txtbuscar" runat="server" CssClass="cajatexto" placeholder="Buscar por Comision"></asp:TextBox>
        <asp:Button ID="btnbuscar" runat="server" Text="Buscar" CssClass="button1"></asp:Button>
    </asp:Panel>
    <link href="../CSS/datagridview.css" rel="stylesheet" />
    <center>
    <asp:Panel ID="gridPanel" runat="server">
       
        <asp:GridView ID="gridview" runat="server"  AutoGenerateColumns="False" CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None"
            AllowPaging="True" AlternatingRowStyle-CssClass="alt" PageSize="80" OnPageIndexChanging="gridview_PageIndexChanging" OnSelectedIndexChanged="gridview_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField HeaderText="Codigo Curso" DataField="IdCurso"/>
                <asp:BoundField HeaderText="Codigo Materia" DataField="IdMateria"/>
                <asp:BoundField HeaderText="Materia" DataField="Desc_materia"/>
                <asp:BoundField HeaderText="Codigo Comision" DataField="IdComision"/>
                 <asp:BoundField HeaderText="Comision" DataField="Desc_comision"/>
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario"/>
                <asp:BoundField HeaderText="Cupo" DataField="Cupo"/>
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <center>
        <asp:Panel ID="estiloPanal" Visible="true" runat="server" Height="16px">
            <br />
            <%--<p class="corto">--%>
                <asp:TextBox ID="txtidCurso" runat="server" placeholder="Codigo Curso" CssClass="cajatexto" ReadOnly="True" Enabled="false"></asp:TextBox>  
               <asp:TextBox ID="txtanio_calendario" runat="server" CssClass="cajatexto" placeholder="Año Calendario" Enabled="false"></asp:TextBox>  
               <asp:TextBox ID="Txtcupo" runat="server" CssClass="cajatexto" placeholder="Cupo" Enabled="false"></asp:TextBox>              
               <asp:DropDownList ID="cblMateria" runat="server" CssClass="cajatexto1" placeholder="Elegir Materia" Enabled="false"></asp:DropDownList>  
               <asp:DropDownList ID="cblcomision" runat="server" CssClass="cajatexto1" placeholder="Elegir Comision" Enabled="false"></asp:DropDownList> 
              <%--</p>--%>
        </asp:Panel>
   </center> 
   <br />
        
        <br /><br /><br />   <br />      
    <div>       
        <asp:Button ID="btncancelar" runat="server" Text="Cancelar" CssClass="button" Visible="false" OnClick="btncancelar_Click" ></asp:Button>
        <asp:Button ID="btnaceptar" runat="server" Text="Aceptar" CssClass="button"  ValidationGroup="Controlar" Visible="false" OnClick="btnaceptar_Click"></asp:Button>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="button" Visible="false" OnClick="btnEliminar_Click" ></asp:Button>
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="button" Visible="false" OnClick="btnEditar_Click"  ></asp:Button>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="btnNuevo_Click" ></asp:Button>
    </div>
        
        <br /><br /><br />   <br /> 
        <div>
            <asp:Label ID="msgError" runat="server" ForeColor="Red"></asp:Label>
            <br /> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="Debe ingresar el año Calendario" ForeColor="Red" ValidationGroup="Controlar" ControlToValidate="txtanio_calendario"></asp:RequiredFieldValidator>
            <br /> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Debe Ingresar el cupo" ForeColor="Red" ValidationGroup="Controlar" ControlToValidate="Txtcupo"></asp:RequiredFieldValidator>
        
     </div>
<%--        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <form>
                        <select class="chosen-select">
                        <option>elegir</option>       
                        </select>
                    </form>
                </div>

            </div>
        </div>
        <script src="../JS/chosen.jquery.js"></script>
        <script src="../JS/bootstrap.min.js"></script>
        <script src="../JS/jquery.min.js"></script>
        <script>
            $('.chosen-select').chosen();
        </script>--%>
</asp:Content>
