﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.frmprincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenidomenucontextual" runat="server">
    <%--<asp:Menu ID="Menu1" runat="server" CssClass="cajatexto" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#F7F6F3" />
                        <DynamicSelectedStyle BackColor="#5D7B9D" />
                        <Items>
                            <asp:MenuItem NavigateUrl="~/Formulario/Home.aspx" Text="Inicio" Value="Inicio"></asp:MenuItem>
                            <asp:MenuItem Text="Personas" Value="Personas">
                                <asp:MenuItem Text="Administrador" Value="Administrador"></asp:MenuItem>
                                <asp:MenuItem Text="Docente" Value="Docente"></asp:MenuItem>
                                <asp:MenuItem Text="Alumno" Value="Alumno"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Inscripcion" Value="Inscripcion">
                                <asp:MenuItem Text="Examen" Value="Examen"></asp:MenuItem>
                                <asp:MenuItem Text="Cursar" Value="Cursar" NavigateUrl="~/Formulario/frmcursar.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Consultar" Value="Consultar">
                                <asp:MenuItem Text="Materias Aprobadas" Value="Materias Aprobadas"></asp:MenuItem>
                                <asp:MenuItem Text="Historia Academico" Value="Historia Academico"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Carrera" Value="Carrera">
                                <asp:MenuItem NavigateUrl="~/Formulario/frmEspecialidades.aspx" Text="Especialidades" Value="Especialidades"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Formulario/frmPlanes.aspx" Text="Planes" Value="Planes"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Formulario/frmMaterias.aspx" Text="Materias" Value="Materias"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Formulario/frmCursos.aspx" Text="Cursos" Value="Cursos"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Formulario/frmComisiones.aspx" Text="Comisiones" Value="Comisiones"></asp:MenuItem>
                            </asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#5D7B9D" />
                    </asp:Menu>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <h1>Bienvenido al Sistema academico</h1>
</asp:Content>
