<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webmasterpagos.aspx.cs"
    Inherits="MotoPoint.webmasterpagos" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Content/css/webmaster.css" rel="Stylesheet" type="text/css" />
    <title>WebMaster</title>
</head>
<body>
    <form id="fromAdministradorPagos" runat="server">
        <div class="SistemaLogHeader">
            <div id="abmUser">
                <asp:Label ID="lblContingencia" runat="server" Text="Errores pagos de Membresias" meta:resourcekey="lblContingenciaResource1"></asp:Label>
                </br>
            </br>
            <asp:LinkButton ID="LinkAdmin" runat="server" OnClick="LinkAdmin_Click" meta:resourcekey="LinkAdminResource1">Ir a WebMaster !</asp:LinkButton>
            </div>
        </div>
        <div class="SistemaLogContenido">
            <asp:GridView ID="GridViewPago" Class="LogSystemView" runat="server" meta:resourcekey="GridViewPagoResource1"></asp:GridView>
        </div>
    </form>
</body>
</html>
