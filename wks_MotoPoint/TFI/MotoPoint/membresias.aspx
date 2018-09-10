<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membresias.aspx.cs"
    Inherits="MotoPoint.membresias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="~/Content/css/membresias.css" rel="Stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="font-awesome/css/font-awesome.min.css" />

    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>

    <title>MotoPoint - Pago Membresias</title>
</head>
<body>
    <form id="frm_membresias" runat="server">
        <div>
            <div class="container">
                <div class="tiposMembresias">
                    <div class="row col-list">
                        <div class="col-md-4 t1">
                            <div class="col-head text-center">
                                <span class="glyphicon glyphicon-certificate" aria-hidden="true"></span>
                                <h2>Membresia BRONCE</h2>
                            </div>
                            <ul class="list-unstyled">
                                <li>
                                    <asp:RadioButton ID="rbtnMemBronce" GroupName="membresiaGrupo" runat="server" Text="Seleccionar Bronce" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row col-list">
                        <div class="col-md-4 t2">
                            <div class="col-head text-center">
                                <span class="glyphicon glyphicon-certificate" aria-hidden="true"></span>
                                <h2>Membresia Plata</h2>
                            </div>
                            <ul class="list-unstyled">
                                <li>
                                    <asp:RadioButton ID="rbtnMemPlata" GroupName="membresiaGrupo" runat="server" Text="Seleccionar Plata" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="row col-list">
                        <div class="col-md-4 t3">
                            <div class="col-head text-center">
                                <span class="glyphicon glyphicon-certificate" aria-hidden="true"></span>
                                <h2>Membresia ORO</h2>
                            </div>
                            <ul class="list-unstyled">
                                <li>
                                    <asp:RadioButton ID="rbtnMemOro" GroupName="membresiaGrupo" runat="server" Text="Seleccionar Oro" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    </div>
                    <hr />
                    <!-- Credit Card Payment Form - START -->
                    <div class="tarjetasPago">
                    <div class="col-xs-12 col-md-4 col-md-offset-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <div class="row">
                                    <h3 class="text-center">Detalle del pago</h3>
                                    <img class="img-responsive cc-img" src="http://www.prepbootstrap.com/Content/images/shared/misc/creditcardicons.png">
                                </div>
                            </div>
                            <div class="panel-body">
                                <div role="form">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <asp:Label ID="lblNumeroTarjeta" runat="server">Numero de tarjeta</asp:Label>
                                                <div class="input-group">
                                                    <input type="tel" class="form-control" placeholder="Numero valido de tarjeta" />
                                                    <span class="input-group-addon"><span class="fa fa-credit-card"></span></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-7 col-md-7">
                                            <div class="form-group">
                                                <asp:Label ID="lblFechaExpiracion" runat="server"><span class="hidden-xs">Expiracion</span><span class="visible-xs-inline">EXP</span> Fecha</asp:Label>
                                                <input type="tel" class="form-control" placeholder="MM / YY" />
                                            </div>
                                        </div>
                                        <div class="col-xs-5 col-md-5 pull-right">
                                            <div class="form-group">
                                                <asp:Label ID="lblCvCodigo" runat="server">CV Codigo</asp:Label>
                                                <input type="tel" class="form-control" placeholder="CVC" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-group">
                                                <asp:Label ID="lblNombreTitular" runat="server">Nombre del titular</asp:Label>
                                                <input type="text" class="form-control" placeholder="Nombre del titular" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="row">
                                    <div class="col-xs-12">
                                        <button class="btn btn-warning btn-lg btn-block">Pagar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <style>
                    .cc-img {
                        margin: 0 auto;
                    }
                </style>
                <!-- Credit Card Payment Form - END -->
            </div>
        </div>
    </form>
</body>
</html>
