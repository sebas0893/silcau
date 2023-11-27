<%@ Page Language="C#" Title="Informe mensual" MasterPageFile="~/Paginas/Admin.Master" AutoEventWireup="true" CodeBehind="AdminInformeMensual.aspx.cs" Inherits="Vista.Paginas.AdminInformeMensual" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">

<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <b>Informe mensual</b>
            </div>
            <div class="panel-body">
                <asp:HyperLink runat="server" ID="hlEnviar" class="btn btn-info" role="button">Enviar Informe</asp:HyperLink>
                <asp:HyperLink runat="server" ID="hlCerrar" class="btn btn-primary" role="button" NavigateUrl="~/Paginas/AdminNuevoInforme.aspx">Cerrar</asp:HyperLink>
                <br />
                <div class="col-md-12" style="margin-top: 20px">
                     <div class="panel-heading">
                        <h4 class="panel-title text-center"><b>Municipio: </b><asp:Label ID="lbMunicipio" runat="server" Text=""></asp:Label></h4>
                        <br />
                        <h4 class="panel-title text-center"><b>Mes: </b><asp:Label ID="lbMes" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <!-- Reporte -->
                    <br />
                    <p style="text-align: justify"><b>OBSERVACIONES:</b> Los campos marcados con asterisco (*) son obligatorios. Para seleccionar varias opciones en los <b>campos con opción múltiple</b>, presione la tecla <b>Ctrl</b> mientras selecciona las respectivas opciones</p>
                    <asp:Button runat="server" ID="btAgregar" Text="Agregar Registro" class="btn btn-success" role="button" onclick="btAgregar_Click" />
                    <br />
                    <div class="table-responsive" style="text-align:center; margin-top:20px;">
                        <asp:GridView ID="gvReporte" runat="server" DataKeyNames="codigo" AutoGenerateColumns="False" class="table table-bordered table-striped" onrowcommand="gvReporte_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="autorizacion" HeaderText="Tipo de Autorización" />
                                <asp:BoundField DataField="resolucion" HeaderText="Número de Resolución" />
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" ItemStyle-Width="90px" />
                                <asp:BoundField DataField="proyecto" HeaderText="Nombre del Proyecto" />
                                <asp:BoundField DataField="titular" HeaderText="Titular o Propietario" />
                                <asp:BoundField DataField="ccNit" HeaderText="C.C. / Nit" />
                                <asp:BoundField DataField="vereda" HeaderText="Vereda" />
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Modificar" ImageUrl="~/img/icono_cambiar.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="Eliminar" HeaderText="Eliminar" ImageUrl="~/img/icono_error.png" />
                            </Columns>
                            <EmptyDataTemplate>
                                NO SE HAN AGREGADO REGISTROS
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="success headerClass" />
                        </asp:GridView>
                        <asp:HiddenField ID="hfCodigo" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal popup Reporte -->
<asp:ModalPopupExtender ID="mpeReporte" runat="server" Enabled="false" TargetControlID="btAgregar" BackgroundCssClass="modalBackground" PopupControlID="pnlReporte" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Reporte -->
<asp:Panel ID="pnlReporte" runat="server" style="display:none; overflow: auto; max-height: 600px; left:0px; background:white;" Width="650px">
    <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Registro</h4>
            </div>
            <div class="modal-body">
                <label>Tipo de Autorización (opción múltiple) &nbsp;<asp:RequiredFieldValidator ID="rfvAutorizacion" runat="server" ControlToValidate="lbAutorizacion" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <br /><asp:ListBox runat="server" ID="lbAutorizacion" class="form-control" DataValueField="codigo" DataTextField="nombre" SelectionMode="Multiple"></asp:ListBox>
                <label>Número de Resolución &nbsp;<asp:RequiredFieldValidator ID="rfvResolucion" runat="server" ControlToValidate="tbResolucion" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbResolucion" runat="server" class="form-control" MaxLength="50" placeholder="Resolución"></asp:TextBox>
                <asp:filteredtextboxextender ID="fteResolucion" runat="server" FilterType="Numbers" TargetControlID="tbResolucion" />
                <label>Fecha de Licencia &nbsp;<asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="tbFecha" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbFecha" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
                <label>Nombre del Proyecto</label>
                <asp:TextBox ID="tbProyecto" runat="server" class="form-control" MaxLength="250" placeholder="Proyecto"></asp:TextBox>
                <label>Titular o Propietario &nbsp;<asp:RequiredFieldValidator ID="rfvTitular" runat="server" ControlToValidate="tbTitular" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbTitular" runat="server" class="form-control" MaxLength="150" placeholder="Titular"></asp:TextBox>
                <label>C.C./Nit &nbsp;<asp:RequiredFieldValidator ID="rfvCcNit" runat="server" ControlToValidate="tbCcNit" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbCcNit" runat="server" class="form-control" MaxLength="15" placeholder="C.C./Nit"></asp:TextBox>
                <asp:filteredtextboxextender ID="fteCcNit" runat="server" FilterType="Numbers" TargetControlID="tbCcNit" />
                <label>Suelo &nbsp;<asp:RequiredFieldValidator ID="rfvSuelo" runat="server" ControlToValidate="ddlSuelo" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <br /><asp:DropDownList runat="server" ID="ddlSuelo" class="form-control" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                <label>Vereda &nbsp;<asp:RequiredFieldValidator ID="rfvVereda" runat="server" ControlToValidate="ddlVereda" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <br /><asp:DropDownList runat="server" ID="ddlVereda" class="form-control" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                <label>Paraje o Sector &nbsp;<asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="tbSector" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbSector" runat="server" class="form-control" MaxLength="250" placeholder="Paraje"></asp:TextBox>
                <label>Matrícula Inmobiliaria o Cédula Catastral &nbsp;<asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="tbMatricula" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbMatricula" runat="server" class="form-control" MaxLength="50" placeholder="Matrícula"></asp:TextBox>
                <label>Dirección</label>
                <asp:TextBox ID="tbDireccion" runat="server" class="form-control" MaxLength="150" placeholder="Dirección"></asp:TextBox>
                <label>Teléfono(s)</label>
                <asp:TextBox ID="tbTel" runat="server" class="form-control" MaxLength="30" placeholder="Teléfono(s)"></asp:TextBox>
                <div class="panel-body">
                    <!-- Coordenadas -->
                    <label><strong>Coordenadas GD (grados decimales)</strong> - <a href="https://www.coordenadas-gps.com/convertidor-de-coordenadas-gps" target="_blank">Convertidor de coordenadas GMS a GD</a></label>
                    <div class="alert alert-success alert-sm">
                        <label>Latitud (Norte) &nbsp;<asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="tbLatitud" ErrorMessage="Incorrecta" ValidationGroup="reporte" ForeColor="red" ValidationExpression="[\d]{1}[.][\d]{1,15}"></asp:RegularExpressionValidator></label>
                        <asp:TextBox runat="server" ID="tbLatitud" class="form-control" MaxLength="50" placeholder="Latitud"></asp:TextBox>
                        <label>Longitud (Oeste) &nbsp;<asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="tbLongitud" ErrorMessage="Incorrecta" ValidationGroup="reporte" ForeColor="red" ValidationExpression="^-[\d]{2}[.][\d]{1,15}"></asp:RegularExpressionValidator></label>
                        <asp:TextBox runat="server" ID="tbLongitud" class="form-control" MaxLength="50" placeholder="Longitud"></asp:TextBox>
                    </div>
                </div>
                <label>Área total (metros cuadrados) &nbsp;<asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="tbArea" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <asp:TextBox ID="tbArea" runat="server" class="form-control" MaxLength="8" placeholder="Área"></asp:TextBox>
                <asp:filteredtextboxextender ID="fteArea" runat="server" FilterType="Numbers, Custom" ValidChars="." TargetControlID="tbArea" />
                <label>Zonificación POT y Usos &nbsp;<asp:RequiredFieldValidator ID="rfvZonificacion" runat="server" ControlToValidate="ddlZonificacion" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <br /><asp:DropDownList runat="server" ID="ddlZonificacion" class="form-control" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                <label>Restricciones ambientales (opción múltiple) &nbsp;<asp:RequiredFieldValidator ID="rfvRestricciones" runat="server" ControlToValidate="lbRestricciones" ErrorMessage="*" Font-Size="20px" ForeColor="red" ValidationGroup="reporte"></asp:RequiredFieldValidator></label>
                <br /><asp:ListBox runat="server" ID="lbRestricciones" class="form-control" DataValueField="codigo" DataTextField="nombre" SelectionMode="Multiple"></asp:ListBox>
                <label>Radicado del Plan Acción Ambiental</label>
                <asp:TextBox ID="tbRadicado" runat="server" class="form-control" MaxLength="50" placeholder="Radicado"></asp:TextBox>
                <label>PDF de la licencia, concepto y/o autorización otorgada (Máximo 2 Mb)</label>
                <asp:FileUpload ID="fuAnexo" runat="server" class="form-control" />
                <label>Observaciones</label>
                <asp:TextBox ID="tbObservaciones" runat="server" class="form-control" MaxLength="500" Height="70px" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btCerrarReporte" class="btn btn-default" Text="Cerrar" onclick="btCerrarReporte_Click" />
                <asp:Button runat="server" ID="btGuardarDetalle" class="btn btn-primary" Text="Guardar" onclick="btGuardarDetalle_Click" ValidationGroup="reporte" />
            </div>
        </div>
</asp:Panel>

<!-- Modal popup Enviar -->
<asp:ModalPopupExtender ID="mpeEnviar" runat="server" TargetControlID="hlEnviar" CancelControlID="btCancelarEnviar" BackgroundCssClass="modalBackground" PopupControlID="pnlEnviar" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Enviar -->
<asp:Panel ID="pnlEnviar" runat="server" style="display:none; left:0px; background:white;" Width="500px">
    <div class="modal-header"><h4>Enviar reporte</h4>
        <div class="container-fluid well">
            <div class="row-fluid">
                <div class="span4" style="width: 424px; text-align:justify">¿Esta seguro de enviar el reporte?. Luego de enviado no se podrán realizar modificaciones</div>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Button ID="btCancelarEnviar" class="btn" runat="server" Text="Cancelar" />
        <asp:Button ID="btConfirmar" class="btn btn-info" runat="server" Text="Aceptar" onclick="btConfirmar_Click" CausesValidation="false" />
    </div>
</asp:Panel>

<!-- Modal popup Eliminar -->
<asp:ModalPopupExtender ID="mpeEliminar" runat="server" Enabled="false" TargetControlID="gvReporte" BackgroundCssClass="modalBackground" PopupControlID="pnlEliminar" DropShadow="true"></asp:ModalPopupExtender>

<!-- Panel Eliminar -->
<asp:Panel ID="pnlEliminar" runat="server" style="display:none; left:0px; background:white;" Width="500px">
    <div class="modal-header"><h4>Eliminar Registro</h4>
        <div class="container-fluid well">
            <div class="row-fluid">
                <div class="span4" style="width: 300px">¿Desea eliminar este Registro?</div>
            </div>
        </div>
    </div>
    <div class="modal-footer">
        <asp:Button ID="btCancelarEliminar" class="btn" runat="server" Text="Cancelar" onclick="btCancelarEliminar_Click" formnovalidate />
        <asp:Button ID="btDelete" class="btn btn-danger" runat="server" Text="Aceptar" onclick="btDelete_Click" formnovalidate />
    </div>
</asp:Panel>

</asp:Content>