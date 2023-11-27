using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class DetalleReporteDTO
    {

        private long codigo;

        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private ReporteDTO reporte;

        public ReporteDTO Reporte
        {
            get { return reporte; }
            set { reporte = value; }
        }

        private string autorizacion;

        public string Autorizacion
        {
            get { return autorizacion; }
            set { autorizacion = value; }
        }

        private string resolucion;

        public string Resolucion
        {
            get { return resolucion; }
            set { resolucion = value; }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string proyecto;

        public string Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        private string titular;

        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        private string ccNit;

        public string CcNit
        {
            get { return ccNit; }
            set { ccNit = value; }
        }

        private SueloDTO suelo;

        public SueloDTO Suelo
        {
            get { return suelo; }
            set { suelo = value; }
        }

        private VeredaDTO vereda;

        public VeredaDTO Vereda
        {
            get { return vereda; }
            set { vereda = value; }
        }

        private string sector;

        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string latitud;

        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        private string longitud;

        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        private decimal area;

        public decimal Area
        {
            get { return area; }
            set { area = value; }
        }

        private ZonificacionDTO zonificacion;

        public ZonificacionDTO Zonificacion
        {
            get { return zonificacion; }
            set { zonificacion = value; }
        }

        private string restricciones;

        public string Restricciones
        {
            get { return restricciones; }
            set { restricciones = value; }
        }

        private string radicado;

        public string Radicado
        {
            get { return radicado; }
            set { radicado = value; }
        }

        private string anexo;

        public string Anexo
        {
            get { return anexo; }
            set { anexo = value; }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Reporte

        private string nombreSuelo;

        public string NombreSuelo
        {
            get { return nombreSuelo; }
            set { nombreSuelo = value; }
        }

        private string nombreZonificacion;

        public string NombreZonificacion
        {
            get { return nombreZonificacion; }
            set { nombreZonificacion = value; }
        }

        private string nombreVereda;

        public string NombreVereda
        {
            get { return nombreVereda; }
            set { nombreVereda = value; }
        }

        private string mapa;

        public string Mapa
        {
            get { return mapa; }
            set { mapa = value; }
        }

        private int codigoMunicipio;

        public int CodigoMunicipio
        {
            get { return codigoMunicipio; }
            set { codigoMunicipio = value; }
        }

        private string nombreMunicipio;

        public string NombreMunicipio
        {
            get { return nombreMunicipio; }
            set { nombreMunicipio = value; }
        }

    }
}
