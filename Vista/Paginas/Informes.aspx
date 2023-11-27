<%@ Page Title="Informe mensual" MasterPageFile="~/Paginas/Admin.Master" Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vista.Paginas.Informes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <strong>Informe mensual</strong>
            </div>
            <div class="panel-body">
                <asp:HyperLink runat="server" ID="hlIngreso" class="btn btn-success" role="button">Reportar mes</asp:HyperLink>
                <br />
                <div class="col-md-12" style="text-align: center; margin-top: 20px">
                    <div class="panel-heading">
                        <h3 class="panel-title text-center"><b>Meses reportados</b></h3>
                    </div>
                    <div class="table-responsive text-center">
                        <asp:GridView ID="gvMeses" runat="server" class="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="codigo" onpageindexchanging="gvMeses_PageIndexChanging" PageSize="10" onrowcommand="gvMeses_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="mes" HeaderText="Mes" />
                                <asp:BoundField DataField="enviado" HeaderText="Enviado" />
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Modificar" ImageUrl="~/img/icono_cambiar.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="Descargar" HeaderText="Descargar" ImageUrl="~/img/icon_excel.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="Eliminar" HeaderText="Eliminar" ImageUrl="~/img/icono_error.png" />
                            </Columns>
                            <EmptyDataTemplate>NO HAY MESES REPORTADOS</EmptyDataTemplate>
                            <HeaderStyle CssClass="success headerClass" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal popup Agregar -->
<asp:ModalPopupExtender ID="mpeAgregar" runat="server" TargetControlID="hlIngreso" CancelControlID="btCerrarAgregar" BackgroundCssClass="modalBackground" PopupControlID="pnlAgregar" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Agregar -->
<asp:Panel ID="pnlAgregar" runat="server" style="display:none; left:0px; background:white;" Width="500px">
    <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Reportar mes</h4>
        </div>
        <div class="modal-body">
            <label>Año &nbsp;<asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="tbAnio" ErrorMesesage="*" Font-Size="20px" ForeColor="red" ValidationGroup="mes" ErrorMessage="*"></asp:RequiredFieldValidator></label>
            <asp:TextBox ID="tbAnio" runat="server" class="form-control" placeholder="Año"></asp:TextBox>
            <asp:FilteredTextBoxExtender ID="tbAnio_fte" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="tbAnio"></asp:FilteredTextBoxExtender>
            <label>Mes &nbsp;<asp:RequiredFieldValidator ID="rfvMes" runat="server" ControlToValidate="ddlMes" ErrorMesesage="*" Font-Size="20px" ForeColor="red" ValidationGroup="mes" ErrorMessage="*"></asp:RequiredFieldValidator></label>
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
        </div>
        <div class="modal-footer">
            <asp:Button runat="server" ID="btCerrarAgregar" class="btn btn-default" Text="Cerrar" />
            <asp:Button runat="server" ID="btGuardarMes" class="btn btn-primary" Text="Guardar" onclick="btGuardarMes_Click" ValidationGroup="mes" />
        </div>
    </div>
</asp:Panel>

<!-- Modal popup Eliminar -->
<asp:ModalPopupExtender ID="mpeEliminar" runat="server" Enabled="false" TargetControlID="gvMeses" BackgroundCssClass="modalBackground" PopupControlID="pnlEliminar" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Eliminar -->
<asp:Panel ID="pnlEliminar" runat="server" style="display:none; left:0px; background:white;" Width="500px">
    <div class="modal-header"><h4>Eliminar Informe</h4>
        <div class="container-fluid well">
            <div class="row-fluid">
                <div class="span4" style="width: 300px">¿Desea eliminar este Informe mensual?</div>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Button ID="btCancelarEliminar" class="btn" runat="server" Text="Cancelar" onclick="btCancelarEliminar_Click" CausesValidation="false" />
        <asp:Button ID="btDelete" class="btn btn-danger" runat="server" Text="Aceptar" onclick="btDelete_Click" CausesValidation="false" />
    </div>
</asp:Panel>

</asp:Content>