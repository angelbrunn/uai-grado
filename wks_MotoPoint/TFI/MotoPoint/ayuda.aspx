﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ayuda.aspx.cs"
    Inherits="MotoPoint.ayuda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/ayuda.css" rel="Stylesheet" type="text/css" />
    <title>Ayuda</title>
</head>
<body>
    <form id="frmAyuda" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNombre" TabIndex="2" placeholder="Ingrese su nombre y apellido" class="form-control" required title="El nombre es requerido!"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtDescripcion" TabIndex="2" placeholder="Ingrese su consulta" class="form-control" required title="El nombre es requerido!" Rows="15" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaTecnica" runat="server" Text="Consulta Tecnica" /></label>
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaAdministrativa" runat="server" Text="Consulta Administrativa" /></label>
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaSugerencia" runat="server" Text="Sugerencia" /></label>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="botonesEnviar">
                        <asp:Button ID="btnEnviar" class="form-control btn btn-register" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
