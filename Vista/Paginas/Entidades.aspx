<%@ Page Title="Entidades" MasterPageFile="~/Paginas/Admin.Master" Language="C#" AutoEventWireup="true" CodeBehind="Entidades.aspx.cs" Inherits="Vista.Paginas.Entidades" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    
<div class="row">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <strong>Entidades</strong>
            </div>
            <div class="panel-body">
                
                <!-- Filtros -->
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Nombre</label>
                        <asp:TextBox ID="tbNombre" runat="server" class="form-control" placeholder="Nombre" />
                    </div>
                    <div class="form-group">
                        <label>C.C./NIT</label>
                        <asp:TextBox ID="tbNit" runat="server" class="form-control" placeholder="C.C./NIT" />
                    </div>
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" class="form-control">
                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                            <asp:ListItem Value="1">Aprobado</asp:ListItem>
                            <asp:ListItem Value="2">Pendiente por aprobar</asp:ListItem>
                            <asp:ListItem Value="3">Bloqueado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Button runat="server" ID="btFiltrar" Text="Consultar Entidades" class="btn btn-success" onclick="btFiltrar_Click" />
                        </div>
                    </div>
                </div>

                <div class="col-md-12" style="text-align: center; margin-top: 10px">
                    <div class="table-responsive text-center">
                        <br />
                        <asp:GridView ID="gvUsuarios" runat="server" class="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" onselectedindexchanged="gvUsuarios_SelectedIndexChanged" DataKeyNames="codigo" onpageindexchanging="gvUsuarios_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="nombre" HeaderText="Responsable" />
                                <asp:BoundField DataField="id" HeaderText="C.C./NIT" />
                                <asp:BoundField DataField="email" HeaderText="Email" />
                                <asp:BoundField DataField="estado" HeaderText="Estado" />
                                <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/img/editar.jpg" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <EmptyDataTemplate>
                                NO SE ENCONTRARON ENTIDADES CON EL FILTRO SELECCIONADO
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="success headerClass" />
                            <SelectedRowStyle Font-Bold="True" />
                        </asp:GridView>
                    </div>
                </div>

            </div>
        </div>
    </div>

</div>

</asp:Content>