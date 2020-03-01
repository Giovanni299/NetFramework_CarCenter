using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarCenter.Models
{
    /// <summary>
    /// Class info Respuestos.
    /// </summary>
    public class Repuesto
    {
        /// <summary>
        /// Gets or sets the nombre Repuesto.
        /// </summary>
        /// <value> The nombre Repuesto. </value>
        public string nombreRepuesto { get; set; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        /// <value> The precio. </value>
        public int precio { get; set; }

        /// <summary>
        /// Gets or sets the unidades.
        /// </summary>
        /// <value> The unidades. </value>
        public int unidades { get; set; }

        /// <summary>
        /// Gets or sets the descuento.
        /// </summary>
        /// <value> The descuento. </value>
        public double descuento { get; set; }

        /// <summary>
        /// Gets or sets precio total por repuestos.
        /// </summary>
        /// <value> Precio total por repuestos. </value>
        public int totalRep { get; set; }

        /// <summary>
        /// Gets or sets precio total por repuestos con descuento.
        /// </summary>
        /// <value> Precio total por repuestos con descuento. </value>
        public double totalRepDesc { get; set; }
    }
}