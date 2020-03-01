namespace CarCenter.Models
{
    /// <summary>
    /// Class info servicio.
    /// </summary>
    public class Servicios
    {

        /// <summary>
        /// Gets or sets the nombre servicio.
        /// </summary>
        /// <value> The nombre servicio. </value>
        public string nombreServicio { get; set; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        /// <value> The precio. </value>
        public int precio { get; set; }

        /// <summary>
        /// Gets or sets the precio con descuento.
        /// </summary>
        /// <value> The precio con descuento. </value>
        public int precioDesc { get; set; }
    }
}