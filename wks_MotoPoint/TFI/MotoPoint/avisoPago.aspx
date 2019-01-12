<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avisoPago.aspx.cs"
    Inherits="MotoPoint.avisoPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/avisopago.css" rel="Stylesheet" type="text/css" />
    <title>Aviso Pago</title>
</head>
<body>
    <form id="frmAvisoPago" runat="server">
        <div class="container">
            <div id="bodyFeedback">
                <div id="mensajeFeedback">
                    Solo falta el ultimo paso, <br />Adquiera su Membresia!
                </div>
                <img id="imgFeedback" src="Content/image/faltaPago.svg" alt="Smiley face" />
                <br />
                <asp:Button runat="server" ID="btnPagar" Text="Contratar" OnClick="btnPagar_Click" />
                <br />
                <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
