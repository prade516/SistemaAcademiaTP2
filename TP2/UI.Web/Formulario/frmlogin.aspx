<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmlogin.aspx.cs" Inherits="UI.Web.Formulario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
         <link href="../CSS/csslogin.css" rel="stylesheet" />
         <br /><br />
    <center>
       <div class="login">
            <br />
            <div class="login_form">
                <br />
                <h1>Sistema academia</h1>
                <asp:TextBox ID="txtusuario" runat="server" placeholder="Usuario" CssClass="login_un" ></asp:TextBox>
                <br /><br />
                 <asp:TextBox ID="Txtcontrasena" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="login_pas"></asp:TextBox>
                 <br /><br />
                 <asp:Button ID="btnlogin" runat="server" Text="Aceptar"  CssClass="login_btn" OnClick="btnlogin_Click"></asp:Button>
                  <br /><br />
                <asp:Label ID="msglabel" runat="server" Text="El usuario o la contraseña incorrecta" CssClass="login_lbl" Visible="false"></asp:Label>
                
            </div>
        </div>
        </center>
     </form>
</body>
</html>
