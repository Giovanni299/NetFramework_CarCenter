using System;
using System.Collections.Generic;

namespace CarCenter.Models
{
    public class Factura
    {
        /// <summary>
        /// Gets or sets the cl p nombre.
        /// </summary>
        /// <value> The cl p nombre. </value>
        public string clNombre { get; set; }

        /// <summary>
        /// Gets or sets the cl p apellido.
        /// </summary>
        /// <value> The cl p apellido. </value>
        public string clApellido { get; set; }

        /// <summary>
        /// Gets or sets the cl tipo document.
        /// </summary>
        /// <value> The cl tipo document. </value>
        public string clTipoDoc { get; set; }

        /// <summary>
        /// Gets or sets the cl documento.
        /// </summary>
        /// <value> The cl documento. </value>
        public Int32 clDocumento { get; set; }

        /// <summary>
        /// Gets or sets the cl celular.
        /// </summary>
        /// <value> The cl celular. </value>
        public Int64 clCelular { get; set; }

        /// <summary>
        /// Gets or sets the cl direccion.
        /// </summary>
        /// <value> The cl direccion. </value>
        public string clDireccion { get; set; }

        /// <summary>
        /// Gets or sets the cl email.
        /// </summary>
        /// <value> The cl email. </value>
        public string clEmail { get; set; }

        /// <summary>
        /// Gets or sets the presupuesto.
        /// </summary>
        /// <value> The presupuesto. </value>
        public double presupuesto { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value> The total. </value>
        public double total { get; set; }

        /// <summary>
        /// Gets or sets the iva.
        /// </summary>
        /// <value> The iva. </value>
        public double iva { get; set; }

        /// <summary>
        /// Gets or sets the total cobro.
        /// </summary>
        /// <value> The total cobro. </value>
        public double totalCobro { get; set; }

        /// <summary>
        /// Gets or sets the mantenimientos.
        /// </summary>
        /// <value> The mantenimientos. </value>
        public List<Mantenimiento> mantenimientos { get; set; }
    }
}