<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webmasterContingencia.aspx.cs" 
    Inherits="MotoPoint.admContingencia" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/css/webmaster.css" rel="Stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WebMaster</title>
</head>
<body>
    <form id="fromAdministradorContingencia" runat="server">
        <div class="SistemaLogHeader">
            <div id="abmUser">
            <asp:Label ID="lblContingencia" runat="server" Text="Errores criticos reportados del Sistema" meta:resourcekey="lblContingenciaResource1"></asp:Label>
            </br>
            </br>
            <asp:LinkButton ID="LinkAdmin" runat="server" OnClick="LinkAdmin_Click" meta:resourcekey="LinkAdminResource1">Ir a WebMaster !</asp:LinkButton>
            </div>
        </div>
        <div class="SistemaLogContenido">
            <asp:GridView ID="GridViewLogSystem" Class="LogSystemView" runat="server" meta:resourcekey="GridViewLogSystemResource1"></asp:GridView>
        </div>
    </form>
</body>
</html>
