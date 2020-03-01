using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using CarCenter.Models;
using Oracle.DataAccess.Client;

namespace CarCenter.Services
{
    public class FacturaService
    {
        /// <summary>
        /// The Oracle connection.
        /// </summary>
        private readonly OracleConnection connection;

        /// <summary>
        /// The sp facturacion.
        /// </summary>
        private const string spFacturacion = "SPFACTURACION";

        /// <summary>
        /// Initializes a new instance of the <see cref="FacturaService"/> class.
        /// </summary>
        public FacturaService()
        {
            string conn = ConfigurationManager.ConnectionStrings["connectionOracle"].ToString();
            this.connection = new OracleConnection(conn);
        }

        /// <summary>
        /// Gets the information factura.
        /// </summary>
        /// <param name="cedula">The cedula.</param>
        /// <returns>Información de la factura.</returns>
        public Factura GetInfoFactura(string cedula)
        {
            try
            {
                this.connection.Open();
                OracleCommand oracmd = new OracleCommand();
                oracmd.Parameters.Add("pDocumento", OracleDbType.Int32, Convert.ToInt32(cedula), ParameterDirection.Input);
                oracmd.Parameters.Add("pCursorMtto", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.Parameters.Add("pCursorServicios", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.Parameters.Add("pCursorRepuestos", OracleDbType.RefCursor, ParameterDirection.Output);
                oracmd.CommandText = spFacturacion;
                oracmd.CommandType = CommandType.StoredProcedure;
                oracmd.Connection = this.connection;
                OracleDataReader reader = oracmd.ExecuteReader();

                Factura factura = GetDataFactura(reader);
                factura.clDocumento = Convert.ToInt32(cedula);
                reader.NextResult();
                GetDataServicios(reader, factura);
                reader.NextResult();
                GetDataRepuestos(reader, factura);

                this.connection.Close();
                return factura;
            }
            catch (Exception ex)
            {
                this.connection.Close();
                return null;
            }
        }

        /// <summary>
        /// Gets the data repuestos.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="factura">The factura.</param>
        private void GetDataRepuestos(OracleDataReader reader, Factura factura)
        {
            while (reader.Read())
            {
                int codMtto = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0].ToString());
                Repuesto repuesto = new Repuesto();
                repuesto.nombreRepuesto = reader[1] is DBNull ? string.Empty : reader[1].ToString();
                repuesto.precio = reader[2] is DBNull ? 0 : Convert.ToInt32(reader[2].ToString());
                repuesto.unidades = reader[3] is DBNull ? 0 : Convert.ToInt32(reader[3].ToString());
                repuesto.descuento = reader[4] is DBNull ? 0 : Convert.ToDouble(reader[4].ToString());
                repuesto.totalRep = repuesto.precio * repuesto.unidades;
                repuesto.totalRepDesc = repuesto.totalRep - (repuesto.totalRep * repuesto.descuento);
                factura.mantenimientos.FirstOrDefault(x => x.codigoMtto == codMtto)?.repuestos.Add(repuesto);
            }
        }

        /// <summary>
        /// Gets the data servicios.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="factura">The factura.</param>
        private void GetDataServicios(OracleDataReader reader, Factura factura)
        {            
            while (reader.Read())
            {
                int codMtto = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0].ToString());
                Servicios servicio = new Servicios();
                servicio.nombreServicio = reader[1] is DBNull ? string.Empty : reader[1].ToString();
                servicio.precio = reader[2] is DBNull ? 0 : Convert.ToInt32(reader[2].ToString());
                servicio.precioDesc = servicio.precio;

                factura.mantenimientos.FirstOrDefault(x => x.codigoMtto == codMtto)?.servicios.Add(servicio);
            }
        }

        /// <summary>
        /// Gets the data factura.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Info of Factura.</returns>
        private Factura GetDataFactura(OracleDataReader reader)
        {
            Factura factura = new Factura();
            factura.mantenimientos = new List<Mantenimiento>();
            bool firstClient = true;
            while (reader.Read())
            {
                if (firstClient)
                {
                    firstClient = false;
                    factura.clNombre = reader[0] is DBNull ? string.Empty : reader[0].ToString();
                    factura.clApellido = reader[1] is DBNull ? string.Empty : reader[1].ToString();
                    factura.clTipoDoc = reader[2] is DBNull ? string.Empty : reader[2].ToString();
                    factura.clCelular = reader[3] is DBNull ? 0 : Convert.ToInt64(reader[3].ToString());
                    factura.clDireccion = reader[4] is DBNull ? string.Empty : reader[4].ToString();
                    factura.clEmail = reader[5] is DBNull ? string.Empty : reader[5].ToString();
                    factura.presupuesto = reader[16] is DBNull ? 0 : Convert.ToInt32(reader[16].ToString());
                }

                Mantenimiento mtto = new Mantenimiento()
                {
                    codigoMtto = reader[6] is DBNull ? 0 : Convert.ToInt32(reader[6].ToString()),
                    fechaMtto = reader[7] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader[7].ToString()),
                    mcNombre = reader[8] is DBNull ? string.Empty : reader[8].ToString(),
                    mcApellido = reader[9] is DBNull ? string.Empty : reader[9].ToString(),
                    mcTipoDoc = reader[10] is DBNull ? string.Empty : reader[10].ToString(),
                    mcDocumento = reader[11] is DBNull ? 0 : Convert.ToInt32(reader[11].ToString()),
                    mcCelular = reader[12] is DBNull ? 0 : Convert.ToInt64(reader[12].ToString()),
                    mcDireccion = reader[13] is DBNull ? string.Empty : reader[13].ToString(),
                    mcEmail = reader[14] is DBNull ? string.Empty : reader[14].ToString(),
                    mcEstado = !(reader[15] is DBNull) && Convert.ToBoolean(Convert.ToByte(reader[15])),
                    servicios = new List<Servicios>(),
                    repuestos = new List<Repuesto>()
                };

                factura.mantenimientos.Add(mtto);
            }

            return factura;
        }
    }
}