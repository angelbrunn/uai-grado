<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs"
    Inherits="MotoPoint.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/css/registro.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro</title>
</head>
<body>
    <form id="frmRegistro" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNombre" TabIndex="2" placeholder="Nombre y Apellido" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtFechaNacimiento" TabIndex="2" placeholder="Fecha Nacimiento  -- / -- / --" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="CategoriaMotoList" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtEmail" TabIndex="2" placeholder="Correo Electronico" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtContraseña" TabIndex="2" type="password" placeholder="Contraseña" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="botonesGuardar">
                        <asp:Button ID="btnGuardarRegistro" class="form-control btn btn-register" runat="server" Text="Guardar" OnClick="btnGuardarRegistro_Click" />
                    </div>
                    <div class="botonesCancelar">
                        <asp:Button ID="btnCancelarRegistro" class="form-control btn btn-register" runat="server" Text="Cancelar" OnClick="btnCancelarRegistro_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
