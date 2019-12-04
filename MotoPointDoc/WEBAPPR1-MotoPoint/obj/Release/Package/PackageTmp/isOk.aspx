<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="isOk.aspx.cs" Inherits="MotoPoint.isOk" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/feedback.css" rel="Stylesheet" type="text/css" />
    <title>Ok</title>
</head>
<body>
    <form id="formFeedback" runat="server">
        <div id="bodyFeedback">
            <div id="mensajeFeedback">
            Todo anda bien!
            </div>
            <img id="imgFeedback" src="Content/image/feedback_positivo.svg" alt="Smiley face" />
            <br />
            <br />
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" meta:resourcekey="btnVolverResource1" />
            <br />
        </div>
    </form>
</body>
</html>
