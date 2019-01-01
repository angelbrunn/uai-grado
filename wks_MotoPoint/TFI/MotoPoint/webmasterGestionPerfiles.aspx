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
                    <asp:TextBox runat="server" ID="txtNombreApellido" TabIndex="2" placeholder="Nombre y Apellido" class="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtIdUsuario" TabIndex="2" placeholder="Id Usuario" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtCatMoto" TabIndex="2" placeholder="Categoria moto" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtUsuario" TabIndex="2" placeholder="Usuario" class="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtFecNac" TabIndex="2" placeholder="Fecha Nacimiento" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtPassword" TabIndex="2" placeholder="Contraseña" class="form-control"></asp:TextBox>
                </div>
                <br />
            </div>

            <div class="form-group">

            </div>


            <div class="form-group">
                <button type="button" class="btn btn-primary">Habilitar Busqueda</button>
                <button type="button" class="btn btn-primary">Busqueda</button>
                <button type="button" class="btn btn-success">Nuevo Usuario</button>
                <br />
                <br />
                <button type="button" class="btn btn-danger">Cancelar</button>
                <button type="button" class="btn btn-warning">Guardar</button>
            </div>
        </div>
    </form>
</body>
</html>
