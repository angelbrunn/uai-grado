<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blockUsuario.aspx.cs"
    Inherits="MotoPoint.blockUsuario" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/blockUsuario.css" rel="Stylesheet" type="text/css" />
    <title>Usuario Bloqueado</title>
</head>
<body>
    <form id="frmBlockUser" runat="server">
        <div class="container">
            <img id="imgFeedback" src="Content/image/BlockUsuario.png" alt="Smiley face" />
            <br />
            <br />
            <div class="alert alert-danger" role="alert">
                Su usuario ha sido bloqueado - Comuniquese con soporte tecnico motopointserviciocontacto@gmail.com
            </div>
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" meta:resourcekey="btnVolverResource1" />
            <br />
        </div>
    </form>
</body>
</html>
