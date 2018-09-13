<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membresiaspago.aspx.cs"
    Inherits="MotoPoint.membresiaspago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/membresiaspago.css" rel="Stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="font-awesome/css/font-awesome.min.css" />

    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>

    <title>MotoPoint - Pago Membresias</title>
</head>
<body>
    <form id="frm_membresiaspago" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <h3 class="text-center">DETALLE DE PAGO</h3>
                                <img class="img-responsive cc-img" src="http://www.prepbootstrap.com/Content/images/shared/misc/creditcardicons.png" />
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <asp:Label ID="lblNumeroTarjeta" runat="server" Text="NUMERO TARJETA"></asp:Label>
                                        <div class="input-group">
                                            <input type="tel" class="form-control" placeholder="Valid Card Number" />
                                            <span class="input-group-addon"><span class="fa fa-credit-card"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-7 col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="lblFechaExpiracion" runat="server" Text="FECHA EXPIRACION"></asp:Label>
                                        <input type="tel" class="form-control" placeholder="MM / YY" />
                                    </div>
                                </div>
                                <div class="col-xs-5 col-md-5 pull-right">
                                    <div class="form-group">
                                        <asp:Label ID="lblCvc" runat="server" Text="CVC CODE"></asp:Label>
                                        <input type="tel" class="form-control" placeholder="CVC" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <asp:Label ID="lblTitularTarjeta" runat="server" Text="TITULAR TARJETA"></asp:Label>
                                        <input type="text" class="form-control" placeholder="Card Owner Names" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:Button class="btn btn-warning btn-lg btn-block" ID="btnPagar" runat="server" Text="Proceso Pago" />
                                </div>
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
    </form>
</body>
</html>
