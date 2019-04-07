﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterHome.Master" AutoEventWireup="true" CodeBehind="rutas.aspx.cs"
    Inherits="MotoPoint.rutas" %>

<asp:Content ID="MasterNavBar" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="MasterContenidoRutas" ContentPlaceHolderID="body" runat="server">
    <div id="contenedorRutas">
        <div class="card-deck">
            <div class="card">
                <img class="card-img-top" src="Content/rutas/MDQ.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - MDQ </h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action. </p><span><asp:ImageButton id="btnDetaMDQ01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaMDQ_Click" /></span>
                    <p>
                        <asp:Button ID="btnLikeMDQ01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeMDQ_Click" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblMDQ01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:"></asp:Label>
                        <asp:Label ID="lblMDQ01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:"></asp:Label>
                        <asp:Label ID="lblMDQ01Estado" class="" runat="server" Text=""></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/rutas/ATALAYA.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - ATALAYA</h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p><span><asp:ImageButton id="btnDetaATA01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaATA_Click" /></span>
                    <p>
                        <asp:Button ID="btnLikeATA01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeATA01_Click" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblATA01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:"></asp:Label>
                        <asp:Label ID="lblATA01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:"></asp:Label>
                        <asp:Label ID="lblATA01Estado" class="" runat="server" Text=""></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/rutas/CORDOBA.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - CORDOBA</h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p><span><asp:ImageButton id="btnDetaCOD01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaCOD_Click" /></span>
                    <p>
                        <asp:Button ID="btnLikeCOD01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeCOD01_Click" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblCOD01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:"></asp:Label>
                        <asp:Label ID="lblCOD01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:"></asp:Label>
                        <asp:Label ID="lblCOD01Estado" class="" runat="server" Text=""></asp:Label>
                    </small>
                </div>
            </div>
            <div class="card">
                <img class="card-img-top" src="Content/rutas/ROS.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">BS AS - ROSARIO</h5>
                    <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.</p><span><asp:ImageButton id="btnDetaROS01" class="detalleIcon" runat="server" imageUrl="~/Content/image/rutaDetalle.svg" onClick ="btnDetaROS_Click" /></span>
                    <p>
                        <asp:Button ID="btnLikeROS01" class="btnLike" runat="server" Text="Like" OnClick="btnLikeROS01_Click" />
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">
                        <asp:Label ID="lblROS01CantMotos" class="lblCantMotos" runat="server" Text="Motoqueros:"></asp:Label>
                        <asp:Label ID="lblROS01FechaLimite" class="lblFechaCierre" runat="server" Text="Cierre:"></asp:Label>
                        <asp:Label ID="lblROS01Estado" class="" runat="server" Text=""></asp:Label>
                    </small>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal01:AVISO DE LIKE -->
    <div class="modal fade" id="AvisoModal01" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AvisoModalLikeTitulo">Aviso Votación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Usted ya ha dado like a esta Ruta!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal02:DETALLE DE LA RUTA -->
    <div class="modal fade" id="AvisoModal02" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AvisoModalDetalleTitulo">Detalle Ruta</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    aca pone el detalle de la ruta
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openModal() {
            $('#AvisoModal01').modal('show');
        }
        function openModalDetalle() {
            $('#AvisoModal02').modal('show');
        }
    </script>
</asp:Content>
