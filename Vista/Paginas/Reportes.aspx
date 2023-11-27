<%@ Page Title="Reportes" EnableEventValidation="false" MasterPageFile="~/Paginas/Admin.Master" Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vista.Paginas.Reportes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <strong>Reportes</strong>
            </div>
            <div class="panel-body">
                <div class="col-md-4">
                    <label>Reporte &nbsp;<asp:RequiredFieldValidator ID="rfvReporte" runat="server" ControlToValidate="ddlReporte" ErrorMessage="*" Font-Size="20px" ForeColor="red"></asp:RequiredFieldValidator></label>
                    <asp:DropDownList runat="server" ID="ddlReporte" class="form-control" onchange="ChangeReporte()">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem Value="1">Municipios registrados</asp:ListItem>
                    </asp:DropDownList>
                    <label>Regional</label>
                    <asp:DropDownList runat="server" ID="ddlRegional" class="form-control">
                        <asp:ListItem Value="">Seleccione</asp:ListItem>
                        <asp:ListItem Value="1">Aguas</asp:ListItem>
                        <asp:ListItem Value="2">Páramo</asp:ListItem>
                        <asp:ListItem Value="3">Porcenus</asp:ListItem>
                        <asp:ListItem Value="4">Valles</asp:ListItem>
                        <asp:ListItem Value="5">Bosques</asp:ListItem>
                    </asp:DropDownList>
                    <label>Municipio</label>
                    <asp:DropDownList runat="server" ID="ddlMunicipio" class="form-control" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label>Fecha inicial </label>
                    <asp:TextBox runat="server" ID="tbFechaInicial"  class="form-control" TextMode="Date"></asp:TextBox>
                    <label>Fecha final </label>
                    <asp:TextBox runat="server" ID="tbFechaFinal"  class="form-control" TextMode="Date"></asp:TextBox>
                    <label>Mes</label>
                    <div class="controls form-inline">
                        <asp:DropDownList runat="server" ID="ddlMes" class="form-control">
                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                            <asp:ListItem Value="1">Enero</asp:ListItem>
                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                            <asp:ListItem Value="4">Abril</asp:ListItem>
                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                            <asp:ListItem Value="6">Junio</asp:ListItem>
                            <asp:ListItem Value="7">Julio</asp:ListItem>
                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                            <asp:ListItem Value="9">Septiembre</asp:ListItem>
                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:TextBox ID="tbAnio" runat="server" Width="215px" class="form-control" placeholder="Año" MaxLength="4"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteAnio" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="tbAnio"></asp:FilteredTextBoxExtender>
                    </div>
                </div>
                <br /><br />
                <div class="col-md-12">
                    <br /><asp:Button runat="server" ID="btGenerar" class="btn btn-lg btn-success pull-left" Width="200px" Text="Generar reporte" onclick="btGenerar_Click" />
                    <center>
                        <br />
                        <rsweb:reportviewer ID="rvReporte" runat="server" 
                            Width="808px" BackColor="White" BorderStyle="Groove" Font-Names="Verdana" 
                            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" Visible="False" 
                            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
                            KeepSessionAlive="False">
                        </rsweb:reportviewer>
                    </center>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>