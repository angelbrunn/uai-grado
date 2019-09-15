<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recordar.aspx.cs"
    Inherits="MotoPoint.recordar" meta:resourcekey="PageResource1" %>

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
                <asp:TextBox runat="server" ID="txtEmail" TabIndex="2" placeholder="Ingrese su correo electronico" class="form-control" required title="El email es requerido!" meta:resourcekey="txtEmailResource1"></asp:TextBox>
            </div>
            <div class="form-group">
                <div id="usuarioOk">
                    <p><font color="red">Usuario no existe! </font></p>
                </div>
                <div class="row">
                    <div class="botonesEnviar">
                        <asp:Button ID="btnEnviar" class="form-control btn btn-register" runat="server" Text="Enviar" OnClick="btnEnviar_Click" meta:resourcekey="btnEnviarResource1" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script>
    var dbEstadoUsuario = '<%= Session["usuarioOk"].ToString() %>';
    if (dbEstadoUsuario == 1) {
        document.getElementById("usuarioOk").style.display = 'inline';
    } else {
        document.getElementById("usuarioOk").style.display = 'none';
    }
</script>
