<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webmasterGestionPerfiles.aspx.cs"
    Inherits="MotoPoint.AdminGestionPerfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/css/abmusuario.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ABM Usuarios</title>
</head>
<body>
    <form id="fromAdministradorPerfiles" runat="server">
        <div class="container">
            <div class="form-group">

                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtIdUsuario" TabIndex="2" placeholder="Id Usuario" class="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtNombreApellido" TabIndex="2" placeholder="Nombre y Apellido" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtFecNac" TabIndex="2" placeholder="Fecha Nacimiento" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtCatMoto" TabIndex="2" placeholder="Categoria moto" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
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
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaActivo" runat="server" Text="Activo" /></label>
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaInactivo" runat="server" Text="Inactivo" /></label>
            </div>
            <div id="busquedaEstado">
                <p><font color="red">Usuario no existe! </font></p>
            </div>
            <div class="form-group">
                <asp:Button ID="btnHabilitarBusqueda" runat="server" Text="Habilitar Busqueda" class="btn btn-primary" OnClick="btnHabilitarBusqueda_Click" />
                <asp:Button ID="btnBusqueda" runat="server" Text="Busqueda" class="btn btn-primary" OnClick="btnBusqueda_Click" />
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Nuevo Usuario" class="btn btn-success" OnClick="btnAgregarUsuario_Click" />
                <br />
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-warning" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </form>
</body>
</html>
<script>
    var busquedaEstado = '<%= Session["busquedaEstado"].ToString() %>';
    var guardadoEstado = '<%= Session["guardadoEstado"].ToString() %>';
    if (busquedaEstado == 1) {
        document.getElementById("busquedaEstado").style.display = 'inline';
    } else {
        document.getElementById("busquedaEstado").style.display = 'none';
    }
    if (guardadoEstado == 1) {
        alert("La actualizacion se realizo de forma correcta!");
    }
    if (guardadoEstado == 2) {
        alert("La actualizacion ha fallado!");
    }
</script>
