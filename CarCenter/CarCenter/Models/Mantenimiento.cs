using System;
using System.Collections.Generic;

namespace CarCenter.Models
{
    /// <summary>
    /// Class info Mantenimiento.
    /// </summary>
    public class Mantenimiento
    {
        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        /// <value> The codigo mtto. </value>
        public int codigoMtto { get; set; }

        /// <summary>
        /// Gets or sets the fecha mtto.
        /// </summary>
        /// <value> The fecha mtto. </value>
        public DateTime fechaMtto { get; set; }

        /// <summary>
        /// Gets or sets the mc p nombre.
        /// </summary>
        /// <value> The mc p nombre. </value>
        public string mcNombre { get; set; }

        /// <summary>
        /// Gets or sets the mc p apellido.
        /// </summary>
        /// <value> The mc p apellido. </value>
        public string mcApellido { get; set; }

        /// <summary>
        /// Gets or sets the mc tipo document.
        /// </summary>
        /// <value> The mc tipo document. </value>
        public string mcTipoDoc { get; set; }

        /// <summary>
        /// Gets or sets the mc documento.
        /// </summary>
        /// <value> The mc documento. </value>
        public Int32 mcDocumento { get; set; }

        /// <summary>
        /// Gets or sets the mc celular.
        /// </summary>
        /// <value> The mc celular. </value>
        public Int64 mcCelular { get; set; }

        /// <summary>
        /// Gets or sets the mc direccion.
        /// </summary>
        /// <value> The mc direccion. </value>
        public string mcDireccion { get; set; }

        /// <summary>
        /// Gets or sets the mc email.
        /// </summary>
        /// <value> The mc email. </value>
        public string mcEmail { get; set; }

        /// <summary>
        /// Gets or sets the mc estado.
        /// </summary>
        /// <value> The mc estado. </value>
        public bool mcEstado { get; set; }

        /// <summary>
        /// Gets or sets the total serv.
        /// </summary>
        /// <value> The total serv. </value>
        public double totalServ { get; set; }

        /// <summary>
        /// Gets or sets the total rep.
        /// </summary>
        /// <value> The total rep. </value>
        public double totalRep { get; set; }

        /// <summary>
        /// Gets or sets the total mtto.
        /// </summary>
        /// <value> The total mtto. </value>
        public double totalMtto { get; set; }

        /// <summary>
        /// Gets or sets the servicios.
        /// </summary>
        /// <value> The servicios. </value>
        public List<Servicios> servicios { get; set; }

        /// <summary>
        /// Gets or sets the repuestos.
        /// </summary>
        /// <value> The repuestos. </value>
        public List<Repuesto> repuestos { get; set; }
    }
}