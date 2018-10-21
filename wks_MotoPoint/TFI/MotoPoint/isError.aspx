<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="isError.aspx.cs"
    Inherits="MotoPoint.isError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/feedback.css" rel="Stylesheet" type="text/css" />
    <title>Error</title>
</head>
<body>
    <form id="formFeedback" runat="server">
        <div id="bodyFeedback">
            <div id="mensajeFeedback">
            Lo sentimos!
            </div>
            <img id="imgFeedback" src="Content/image/feedback_negativo.svg" alt="Smiley face" />
            <br />
            <br />
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
            <br />
        </div>
    </form>
</body>
</html>
