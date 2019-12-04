<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webmaster.aspx.cs"
    Inherits="MotoPoint.admin" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/css/webmaster.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>WebMaster</title>
</head>
<body>
    <form id="fromAdministrador" name="fromAdministrador" runat="server">
        <div id="dbEstado">
            <p>
                <asp:Label ID="lblDbEstado" Text="DB - DIGITO VERIFICADOR - OK" value="1" runat="server" meta:resourcekey="lblDbEstadoResource1"></asp:Label>
            </p>
        </div>

        <div id="abmUser">
            <p>
                <asp:Label ID="lblLinkGestionPerfiles" value="1" runat="server" meta:resourcekey="lblLinkGestionPerfilesResource1"> </asp:Label><asp:LinkButton ID="LinkGestionPerfiles" runat="server" OnClick="LinkGestionPerfiles_Click" meta:resourcekey="LinkGestionPerfilesResource1"><asp:Label ID="lblGestionPerfilesIntoLink" value="1" runat="server" meta:resourcekey="lblGestionPerfilesIntoLinkResource1"> </asp:Label></asp:LinkButton>
            </p>
            <p>
                <asp:Label ID="lblLinkHome" value="1" runat="server" meta:resourcekey="lblLinkHomeResource1"></asp:Label><asp:LinkButton ID="LinkHome" runat="server" OnClick="LinkHome_Click" meta:resourcekey="LinkHomeResource1"><asp:Label ID="LinkHomeInto" value="1" runat="server" meta:resourcekey="LinkHomeIntoResource1"> </asp:Label></asp:LinkButton>
            </p>
        </div>
        <div id="abmContingencia">
            Se han producidos errores criticos -
            <asp:LinkButton ID="linkContingencia" runat="server" OnClick="linkContingencia_Click" meta:resourcekey="linkContingenciaResource1">Ver contingencia!</asp:LinkButton>
        </div>
        <br />
        <div>
            <asp:Table ID="tbBitacora" runat="server" Height="102px" Width="100%" meta:resourcekey="tbBitacoraResource1">
                <asp:TableRow meta:resourcekey="TableRowResource1">
                    <asp:TableCell meta:resourcekey="TableCellResource1">idEvento</asp:TableCell>
                    <asp:TableCell meta:resourcekey="TableCellResource2">idUsuario</asp:TableCell>
                    <asp:TableCell meta:resourcekey="TableCellResource3">descripcion</asp:TableCell>
                    <asp:TableCell meta:resourcekey="TableCellResource4">fecha</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <div id="admBackup">
            <asp:Label ID="lblAdminBitacora" value="1" runat="server" meta:resourcekey="lblAdminBitacoraResource1"></asp:Label>
            <p>
                <asp:CheckBox ID="chkbxBitacora" Text="Bitacora" runat="server" meta:resourcekey="chkbxBitacoraResource1" />
                <asp:CheckBox ID="chkbxUsuario" Text="Usuario" runat="server" meta:resourcekey="chkbxUsuarioResource1" />
                <asp:CheckBox ID="chkbxGrupo" Text="Grupo" runat="server" meta:resourcekey="chkbxGrupoResource1" />
                <asp:CheckBox ID="chkbxGrupoPermiso" Text="GrupoPermisos" runat="server" meta:resourcekey="chkbxGrupoPermisoResource1" />
                <asp:CheckBox ID="chkbxPermiso" Text="Permiso" runat="server" meta:resourcekey="chkbxPermisoResource1" />
                <asp:CheckBox ID="chkbxMultiIdioma" Text="Multi-Idioma" runat="server" meta:resourcekey="chkbxMultiIdiomaResource1" />
                <asp:CheckBox ID="chkbxUsuarioGrupo" Text="UsuarioGrupo" runat="server" meta:resourcekey="chkbxUsuarioGrupoResource1" />
            </p>
            <p>
                <asp:Button class="btn success" ID="btnExportar" Text="Exportar" runat="server" OnClick="btnExportar_Click" meta:resourcekey="btnExportarResource1" />
                <asp:Button class="btn success" ID="btnImportar" Text="Importar" runat="server" OnClick="btnImportar_Click" meta:resourcekey="btnImportarResource1" />
            </p>
            <br />
        </div>
        <div id="admDebug">
            <asp:Label ID="lblBtnWebMaster" value="1" runat="server" meta:resourcekey="lblBtnWebMasterResource1"></asp:Label>
            <p>
                <asp:Button class="btn warning" ID="btnTbitacora" Text="Test Bitacora" runat="server" OnClick="btnTbitacora_Click" meta:resourcekey="btnTbitacoraResource1" />
                <asp:Button class="btn warning" ID="btnTidioma" Text="Cambiar Idioma" runat="server" meta:resourcekey="btnTidiomaResource1" OnClick="btnTidioma_Click" />
                <asp:Button class="btn info" ID="btnTinfo" Text="Informacion Pagos" runat="server" OnClick="btnTinfo_Click" meta:resourcekey="btnTinfoResource1" />
                <asp:Button class="btn danger" ID="btnSalir" Text="Salir" runat="server" OnClick="btnSalir_Click" meta:resourcekey="btnSalirResource1" />
            </p>
        </div>
    </form>
</body>
</html>
<script>
    var dbEstadoSession = '<%= Session["dbEstado"].ToString() %>';
    var dbEstadoContingencia = '<%= Session["dbContingencia"].ToString() %>';
    var dbEstadoExportacion = '<%= Session["fExportar"].ToString() %>';
    var dbEstadoImportacion = '<%= Session["fImportar"].ToString() %>';

    if (dbEstadoSession == 1) {
        document.getElementById("dbEstado").style.background = '#e81212';
        document.getElementById('lblDbEstado').innerHTML = 'DB - ERROR DIGITO VERIFICADOR!';
    }
    if (dbEstadoExportacion == 1) {
        alert("La exportacion se realizo de forma correcta!");
    }
    if (dbEstadoImportacion == 1) {
        alert("La importacion se realizo de forma correcta!");
    }
    if (dbEstadoContingencia == 1) {
        document.getElementById("abmContingencia").style.margin = '-5px 0px';
        document.getElementById("abmContingencia").style.textAlign = 'left';
        document.getElementById("abmContingencia").style.fontFamily = 'arial, sans-serif';
    } else {
        document.getElementById("abmContingencia").style.display = 'none';
    }
</script>
