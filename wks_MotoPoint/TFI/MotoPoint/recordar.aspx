<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recordar.aspx.cs"
    Inherits="MotoPoint.recordar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/css/recordar.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recordar</title>
</head>
<body>
    <form id="frmRecordar" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtEmail" TabIndex="2" placeholder="Ingrese su correo electronico" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="botonesEnviar">
                        <asp:Button ID="btnEnviar" class="form-control btn btn-register" runat="server" Text="Enviar" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
