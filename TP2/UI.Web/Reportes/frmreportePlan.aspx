<%@ Page Title="" Language="C#" MasterPageFile="~/Formulario/Site.Master" AutoEventWireup="true" CodeBehind="frmreportePlan.aspx.cs" Inherits="UI.Web.Reportes.frmreportePlan" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenidomenucontextual" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenidoprincipal" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportEmbeddedResource="UI.Web.Reportes.ReportPlan.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetplan" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PlanLogic, Business.Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></asp:ObjectDataSource>
</asp:Content>
