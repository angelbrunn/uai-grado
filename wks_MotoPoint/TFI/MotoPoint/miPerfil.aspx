﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="miPerfil.aspx.cs" Inherits="MotoPoint.miPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/perfil.css" rel="Stylesheet" type="text/css" />
    <title>Mi Perfil</title>
</head>
<body>
    <form id="frmPerfil" runat="server">
        <div class="container">
            <div id="imagenAvatar">
                <img src="Content/image/perfilBronce.svg" alt="Avatar" class="avatar" />
            </div>
            <div id="datosAvatar" class="form-group">
                <asp:TextBox runat="server" ID="txtNombreApellido" TabIndex="2" placeholder="Nombre y Apellido" class="form-control"></asp:TextBox>
                <br />
                <asp:TextBox runat="server" ID="txtFecNac" TabIndex="2" placeholder="Fecha Nacimiento" class="form-control"></asp:TextBox>
                <div id="estadoUsuarioActivo">
                    <p><font color="green">Usuario Activo! </font></p>
                </div>
                <div id="estadoUsuarioInactivo">
                    <p><font color="red">Usuario Inactivo! </font></p>
                </div>
            </div>
            <br />
            <br />
            <div class="form-group">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtCatMoto" TabIndex="2" placeholder="Categoria moto" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtUsuario" TabIndex="2" placeholder="Usuario" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtPassword" TabIndex="2" placeholder="Contraseña" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtEmail" TabIndex="2" placeholder="Email" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div id="accionesPerfil">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-primary" OnClick="btnVolver_Click" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-warning" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnMembresia" runat="server" Text="Cambiar Membresia" class="btn btn-success" OnClick="btnMembresia_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script>
    var estadoUsuario = '<%= Session["estadoUsuario"].ToString() %>';
    var guardadoEstado = '<%= Session["guardadoEstado"].ToString() %>';
    if (estadoUsuario == 1) {
        document.getElementById("estadoUsuarioActivo").style.display = 'inline';
        document.getElementById("estadoUsuarioInactivo").style.display = 'none';
    } else {
        document.getElementById("estadoUsuarioInactivo").style.display = 'none';
        document.getElementById("estadoUsuarioActivo").style.display = 'inline';
    }
    if (guardadoEstado == 1) {
        alert("La actualizacion se realizo de forma correcta!");
    }
    if (guardadoEstado == 2) {
        alert("La actualizacion ha fallado!");
    }
</script>
