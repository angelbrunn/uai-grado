using SIS.ENTIDAD;
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
        bool EnviarTicketConfirmacionPago(string idUsuario, int numeroOrden, string destinatarioEmail,string estadoPago);
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
    }
}
