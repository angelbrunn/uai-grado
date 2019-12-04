<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membresiaspago.aspx.cs"
    Inherits="MotoPoint.membresiaspago" meta:resourcekey="PageResource1" %>

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
                                        <asp:Label ID="lblMontoPagar" runat="server" Text="MONTO A PAGAR" meta:resourcekey="lblMontoPagarResource1"></asp:Label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtMontoPagar" TabIndex="2" class="form-control" MaxLength="5" meta:resourcekey="txtMontoPagarResource1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="lblNumeroTarjeta" runat="server" Text="NUMERO TARJETA" meta:resourcekey="lblNumeroTarjetaResource1"></asp:Label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" ID="txtNumeroTarjeta" TabIndex="2" placeholder="Numero de tarjeta" class="form-control" MaxLength="16" meta:resourcekey="txtNumeroTarjetaResource1"></asp:TextBox>
                                            <span class="input-group-addon"><span class="fa fa-credit-card"></span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-7 col-md-7">
                                    <div class="form-group">
                                        <asp:Label ID="lblFechaExpiracion" runat="server" Text="FECHA EXPIRACION" meta:resourcekey="lblFechaExpiracionResource1"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtFecha" TabIndex="2" placeholder="MM / YY" class="form-control" meta:resourcekey="txtFechaResource1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-5 col-md-5 pull-right">
                                    <div class="form-group">
                                        <asp:Label ID="lblCvc" runat="server" Text="Codigo CVC" meta:resourcekey="lblCvcResource1"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCvc" TabIndex="2" placeholder="CVC" class="form-control" MaxLength="4" meta:resourcekey="txtCvcResource1"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="form-group">
                                        <asp:Label ID="lblTitularTarjeta" runat="server" Text="TITULAR TARJETA" meta:resourcekey="lblTitularTarjetaResource1"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtTitularTarjeta" TabIndex="2" placeholder="Titular de la tarjeta" class="form-control" MaxLength="45" meta:resourcekey="txtTitularTarjetaResource1"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:Button class="btn btn-warning btn-lg btn-block" ID="btnPagar" runat="server" Text="Proceso Pago" OnClick="btnPagar_Click" meta:resourcekey="btnPagarResource1" />
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
