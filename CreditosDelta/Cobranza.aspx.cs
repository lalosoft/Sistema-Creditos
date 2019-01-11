using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CapaEntidades;
using CapaLogicaNegocio;
using CreditosDelta.Custom;

namespace CreditosDelta
{
    public partial class Cobranza : BasePage
    {
        static string usr_cob = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["App"] == null)
                Response.Redirect("Login.aspx");

            else
            {
                usr_cob = Application["App"].ToString();
                lblFecha.Text = "Ultima Actualización: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            
        }

        [WebMethod]
        public static List<Credito> ListarCreditos()
        {
            List<Credito> Lista = null;
            try
            {
                Lista = CreditoLN.getInstance().ListarCreditos();
            }catch(Exception ex)
            {
                Lista = new List<Credito>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarCredito(string id_credito, string statusCob, string motivo, string qAut, string statusVend)
        {
            //string recibido = Int32.Parse(id_credito.Trim()) + Int32.Parse(statusCob.Trim()) + motivo + Int32.Parse(qAut.Trim()) + Int32.Parse(statusVend.Trim()) + usr_cob;
            if (Int32.Parse(statusCob) != 0)
            {

                Credito objCredito = new Credito()
                {
                    IdCredito = Int32.Parse(id_credito),
                    StatusCobranza = Int32.Parse(statusCob),
                    Motivo = motivo,
                    Autorizado = Int32.Parse(qAut),
                    StatusVendedor = Int32.Parse(statusVend),
                    FechaAceptado = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                };
                bool response = CreditoLN.getInstance().ActualizaCredito(objCredito);
            }

            else
            {
                Credito objCredito = new Credito()
                {
                    IdCredito = Int32.Parse(id_credito),
                    StatusCobranza = Int32.Parse(statusCob),
                    Motivo = motivo,
                    Autorizado = Int32.Parse(qAut),
                    StatusVendedor = Int32.Parse(statusVend),
                    FechaAceptado = "",
                };
                bool response = CreditoLN.getInstance().ActualizaCredito(objCredito);
            }
            bool ok = CreditoLN.getInstance().ActualizaModif(usr_cob, Int32.Parse(id_credito), DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            return true;
        }

        [WebMethod]
        public static List<Credito> datosCredito(string id_credito)
        {
            int id_cred = Int32.Parse(id_credito);
            List<Credito> Lista = null;
            try
            {
                Lista = CreditoLN.getInstance().datosCredito(id_cred);
            }
            catch(Exception ex)
            {
                Lista = new List<Credito>();
            }
            return Lista;
            
        }
    }
}