<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ayuda.aspx.cs"
    Inherits="MotoPoint.ayuda" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/ayuda.css" rel="Stylesheet" type="text/css" />
    <title>Ayuda</title>
</head>
<body>
    <form id="frmAyuda" runat="server">
        <div class="container">
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtNombre" TabIndex="2" placeholder="Ingrese su nombre y apellido" class="form-control" meta:resourcekey="txtNombreResource1" ></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtDescripcion" TabIndex="2" placeholder="Ingrese su consulta" class="form-control" Rows="15" TextMode="MultiLine" meta:resourcekey="txtDescripcionResource1"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaTecnica" runat="server" GroupName="grpConsulta" Text="Consulta Tecnica" meta:resourcekey="rdaTecnicaResource1" /></label>
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaAdministrativa" runat="server" GroupName="grpConsulta" Text="Consulta Administrativa" meta:resourcekey="rdaAdministrativaResource1" /></label>
                <label class="radio-inline">
                    <asp:RadioButton ID="rdaSugerencia" runat="server" GroupName="grpConsulta" Text="Sugerencia" meta:resourcekey="rdaSugerenciaResource1" />
                </label>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="botonesEnviar">
                        <asp:Button ID="btnEnviar" class="form-control btn btn-register" runat="server" Text="Enviar" OnClick="btnEnviar_Click" meta:resourcekey="btnEnviarResource1" />
                    </div>
                    <br />
                    <div class="botonesEnviar">
                        <asp:Button ID="btnCancelar" class="form-control btn btn-register" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource1" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
