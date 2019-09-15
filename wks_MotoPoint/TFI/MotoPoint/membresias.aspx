<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membresias.aspx.cs"
    Inherits="MotoPoint.membresias" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/membresias.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <title>MotoPoint - Seleccionar Membresias</title>
</head>
<body>
    <form id="frmMembresias" runat="server">
        <div class="container">
            <div class="card-deck">
                <div class="card my-3" style="box-shadow: 10px 10px 5px grey;">
                    <img src="Content/image/idCardBronce.svg" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">
                            <asp:Label ID="lblMembresiaBronce" Text="Membresia Bronce" runat="server" meta:resourcekey="lblMembresiaBronceResource1"></asp:Label></h4>
                        <p class="card-text">
                            <asp:Label ID="lblDescMembresiaBronce" Text="Aca viene las descripcion del plan bronce." runat="server" meta:resourcekey="lblDescMembresiaBronceResource1"></asp:Label></p>
                        <asp:Label ID="lblPrecioBronce" style="font-size:35px;" runat="server" meta:resourcekey="lblPrecioBronceResource1"></asp:Label>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btnSeleccion" ID="btnSeleccionarBronce" runat="server" Text="Seleccionar Bronce" OnClick="btnSeleccionarBronce_Click" meta:resourcekey="btnSeleccionarBronceResource1" />
                    </div>
                </div>
                <div class="card my-3" style="box-shadow: 10px 10px 5px grey;">
                    <img src="Content/image/idCardPlata.svg" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">
                            <asp:Label ID="lblMembresiaPlata" Text="Membresia Plata" runat="server" meta:resourcekey="lblMembresiaPlataResource1"></asp:Label></h4>
                        <p class="card-text">
                            <asp:Label ID="lblDescMembresiaPlata" Text="Aca viene las descripcion del plan plata." runat="server" meta:resourcekey="lblDescMembresiaPlataResource1"></asp:Label></p>
                        <asp:Label ID="lblPrecioPlata" style="font-size:35px;" runat="server" meta:resourcekey="lblPrecioPlataResource1"></asp:Label>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btnSeleccion" ID="btnSeleccionarPlata" runat="server" Text="Seleccionar Plata" OnClick="btnSeleccionarPlata_Click" meta:resourcekey="btnSeleccionarPlataResource1" />
                    </div>
                </div>
                <div class="card my-3" style="box-shadow: 10px 10px 5px grey;">
                    <img src="Content/image/idCardOro.svg" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">
                            <asp:Label ID="lblMembresiaOro" Text="Membresia Oro" runat="server" meta:resourcekey="lblMembresiaOroResource1"></asp:Label></h4>
                        <p class="card-text">
                            <asp:Label ID="lblDescMembresiaOro" Text="Aca viene las descripcion del plan oro." runat="server" meta:resourcekey="lblDescMembresiaOroResource1"></asp:Label></p>
                        <asp:Label ID="lblPrecioOro" style="font-size:35px;" runat="server" meta:resourcekey="lblPrecioOroResource1"></asp:Label>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btnSeleccion" ID="btnSeleccionarOro" runat="server" Text="Seleccionar Oro" OnClick="btnSeleccionarOro_Click" meta:resourcekey="btnSeleccionarOroResource1" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
