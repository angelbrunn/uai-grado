using SIS.ENTIDAD;
using System;
using System.Collections.Generic;

namespace SIS.BUSINESS
{
    public interface INegNegocio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="numeroSeguridad"></param>
        /// <param name="fechaValidez"></param>
        /// <param name="nombreTitular"></param>
        void RealizarCobroMembresia(string numeroTarjeta, string numeroSeguridad, string fechaValidez, string nombreTitular);
        /// <summary>
        /// 
        /// </summary>
        List<CategoriaMoto> ObtenerCategoriaMoto();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        int RegistrarMembresiaParaUsuario(string idMembresia, string idUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoMembresia"></param>
        /// <returns></returns>
        int ObtenerMembresiaSegunTipo(string tipoMembresia);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        int ObtenerMembresiaPrecio(string idMembresia);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombreApellido"></param>
        /// <param name="descipcion"></param>
        /// <param name="monto"></param>
        /// <param name="fechaPago"></param>
        /// <returns></returns>
        int RegistrarPagoUsuario(string idUsuario, string nombreApellido, string descipcion, string monto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="numeroOrden"></param>
        /// <param name="destinatarioEmail"></param>
        /// <param name="estadoPago"></param>
        /// <returns></returns>
        bool EnviarTicketConfirmacionPago(string idUsuario, int numeroOrden, string destinatarioEmail, string estadoPago);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        int ObtenerCodigoMembresiaUsuario(string idUsuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        int RegistrarMembresiaUsuario(string idUsuario, string idMembresia);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idMembresia"></param>
        /// <returns></returns>
        int ActualizarMembresiaUsuario(string idUsuario, string idMembresia);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreApellido"></param>
        /// <param name="email"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        bool EnviarConsulta(string nombreApellido, string email, string tipo, string descripcion);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool ConsultarLikeUsuario(string codRuta, string usuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        int RegistrarLikeUsuario(int idRutaLikeUsuario, string codRuta, string usuario, string fechaRuta);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        /// <returns></returns>
        string ObtenerFechaRuta(string codRuta);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int ObtenerIdLikeUsuario();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        void RegistrarVotacionRuta(string codRuta);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        List<Ruta> VotacionesUsuario(string usuario);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="codRuta"></param>
        void BorrarVotacionRutaUsuario(string usuario,string codRuta);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRuta"></param>
        void DecrementarVotacionRuta(string codRuta);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<RutaVotacion> DatosRutas();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Evento> DatosEventos();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<RutaVotacion> EstadoVotacion();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Ruta ObtenerDetalleRuta(string codRuta);
    }
}
