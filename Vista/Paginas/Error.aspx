<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Vista.Paginas.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Compatibilidad IE -->
    <meta http-equiv="X-UA-Compatible" content="IE=7,8,9" />

    <!-- Css -->
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <link rel="stylesheet" href="../css/bootstrap.css" type="text/css" />

    <!-- Icono -->
    <link rel="shortcut icon" href="../img/favicon.ico">        
</head>      	
    
<body>
<form id="Form1" runat="server">
  
  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		
        <!-- Content -->
		<div class="content">
			<ul id="jetmenu" class="jetmenu blue">
	
             <!-- Container -->			
            <div id="container" class="backgmaster" style ="background: url(img/bg.jpg) no-repeat center center fixed; background-color: rgba(255,255,255,0.5); -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover; -webkit-box-shadow: 11px 14px 94px -4px rgba(107,107,107,1);-moz-box-shadow: 11px 14px 94px -4px rgba(107,107,107,1); box-shadow: 11px 14px 94px -4px rgba(107,107,107,1); padding-top:15px; border-radius: 7px;">
            
                <center>
                    <div style="background-color: rgba(255,255,255,0.6); width:100%; border-radius: 7px; ">
                       <asp:Image ID="Image2" runat="server" ImageUrl="~/img/logo_2.png" Height="130px" ></asp:Image>
                    </div>
                </center>
                <br />

                <!-- Menu -->
                <ul class="nav nav-tabs">
                    <li><asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Paginas/Inicio.aspx">Inicio</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlRegistro" runat="server" NavigateUrl="~/Paginas/Registro.aspx">Registro</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlConsultas" runat="server" NavigateUrl="~/Paginas/ConsultaExterna.aspx">Consultas</asp:HyperLink></li>
                </ul>
	
                <!-- Contenido -->
                <br />
                <div class="bloque">
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <h3>Esta página no está disponible</h3>
                                <p>Asegúrese de que la dirección está escrita correctamente</p>
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <br />

                <!-- Footer -->
                <center>
                    <div style="background-color: rgba(255,255,255,0.6); width:100%; border-radius: 7px; ">
                        <div class="bloque" style="font-family:Monospace; font-size: 14px; padding-top:7px; padding-bottom:7px;">
                            Sistema de Información del Licenciamiento y Control Ambiental Urbanístico SILCAU<br />
                            Corporación Autónoma Regional de las Cuencas de los Ríos Negro y Nare CORNARE <br />
                        </div>
                    </div>
                </center>

            </div>
        </ul>
    </div>

</form>
</body>
</html>