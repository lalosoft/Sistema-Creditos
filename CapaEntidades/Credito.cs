using System;

namespace CapaEntidades
{
    public class Credito
    {
        public int IdCredito { get; set; }
        public string FechaInicio { get; set; }
        public string CveCte { get; set; }
        public float MontoPago { get; set; }
        public float PrecioPedido { get; set; }
        public int StatusCobranza { get; set; }
        public string Motivo { get; set; }
        public int Autorizado { get; set; }
        public string FechaAceptado { get; set; }
        public int StatusVendedor { get; set; }
        public string UserRecep { get; set; }
        public string SolicitudCte { get; set; }

        public Credito() { }
    }
}