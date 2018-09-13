<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membresias.aspx.cs"
    Inherits="MotoPoint.membresias" %>

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
    <form id="frm_membresias" runat="server">
        <div class="container">
            <div class="card-deck">
                <div class="card my-3">
                    <img src="http://placehold.it/560x560" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">Membresia Bronce</h4>
                        <p class="card-text">Aca viene las descripcion del plan bronce.</p>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btn btn-primary" ID="btnSeleccionarBronce" runat="server" Text="Seleccionar Bronce" />
                    </div>
                </div>
                <div class="card my-3">
                    <img src="http://placehold.it/560x560" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">Membresia Plata</h4>
                        <p class="card-text">Aca viene las descripcion del plan plata.</p>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btn btn-primary" ID="btnSeleccionarPlata" runat="server" Text="Seleccionar Plata" />
                    </div>
                </div>
                <div class="card my-3">
                    <img src="http://placehold.it/560x560" class="card-img-top" />
                    <div class="card-body">
                        <h4 class="card-title">Membresia Oro</h4>
                        <p class="card-text">Aca viene las descripcion del plan oro.</p>
                    </div>
                    <div class="card-footer">
                        <asp:Button class="btn btn-primary" ID="btnSeleccionarOro" runat="server" Text="Seleccionar Oro" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
