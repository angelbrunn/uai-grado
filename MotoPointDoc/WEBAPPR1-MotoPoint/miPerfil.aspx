<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="miPerfil.aspx.cs" Inherits="MotoPoint.miPerfil" meta:resourcekey="PageResource1" %>

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
                <div id="idPerfilBronce">
                    <img src="Content/image/perfilBronce.svg" alt="Avatar" class="avatar" />
                </div>
                <div id="idPerfilPlata">
                    <img src="Content/image/perfilPlata.svg" alt="Avatar" class="avatar" />
                </div>
                <div id="idPerfilOro">
                    <img src="Content/image/perfilOro.svg" alt="Avatar" class="avatar" />
                </div>
            </div>
            <div id="datosAvatar" class="form-group">
                <asp:TextBox runat="server" ID="txtNombreApellido" TabIndex="2" placeholder="Nombre y Apellido" class="form-control" meta:resourcekey="txtNombreApellidoResource1"></asp:TextBox>
                <br />
                <asp:TextBox runat="server" ID="txtFecNac" TabIndex="2" placeholder="Fecha Nacimiento" class="form-control" meta:resourcekey="txtFecNacResource1"></asp:TextBox>
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
                    <asp:TextBox runat="server" ID="txtCatMoto" TabIndex="2" placeholder="Categoria moto" class="form-control" meta:resourcekey="txtCatMotoResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtUsuario" TabIndex="2" placeholder="Usuario" class="form-control" meta:resourcekey="txtUsuarioResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtPassword" TabIndex="2" placeholder="Contraseña" class="form-control" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtEmail" TabIndex="2" placeholder="Email" class="form-control" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div id="accionesPerfil">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-primary" OnClick="btnVolver_Click" meta:resourcekey="btnVolverResource1" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-warning" OnClick="btnGuardar_Click" meta:resourcekey="btnGuardarResource1" />
                    <asp:Button ID="btnMembresia" runat="server" Text="Cambiar Membresia" class="btn btn-success" OnClick="btnMembresia_Click" meta:resourcekey="btnMembresiaResource1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script>
    var estadoUsuario = '<%= Session["estadoUsuario"].ToString() %>';
    var guardadoEstado = '<%= Session["guardadoEstado"].ToString() %>';
    var guardadoPerfil = '<%= Session["guardadoPerfil"].ToString() %>';
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
    if (guardadoPerfil == 3) {
        document.getElementById("idPerfilBronce").style.display = 'inline';
    } else if (guardadoPerfil == 2) {
        document.getElementById("idPerfilPlata").style.display = 'inline';
    } else if (guardadoPerfil == 1) {
        document.getElementById("idPerfilOro").style.display = 'inline';
    }
</script>
