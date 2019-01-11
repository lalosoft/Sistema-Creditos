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
    public partial class Recepcion : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblFchRecep.Text = "Ultima Actualizacion: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Credito objCredito = GetEntidad();

            bool response = CreditoLN.getInstance().NuevoCredito(objCredito);

            if (response)
            {
                //Response.Write("<script>alert('Credito Guardado Con Exito')</script>");
                Response.Redirect("Recepcion.aspx");
                LimpiaCampos();
            }
            else Response.Write("<script>alert('No se pudo generar el Credito')</script>");
        }

        public Credito GetEntidad()
        {
            Credito objCredito = new Credito();
            objCredito.FechaInicio = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            objCredito.CveCte = txtClaveCte.Text.Trim();
            objCredito.MontoPago = float.Parse(txtMontoPed.Text);
            objCredito.PrecioPedido = float.Parse(txtPago.Text);
            objCredito.UserRecep = Application["App"].ToString();
            objCredito.SolicitudCte = listSolicitaCte.SelectedValue.ToString();

            return objCredito;
        }

        public void LimpiaCampos()
        {
            txtClaveCte.Text = string.Empty;
            txtPago.Text = string.Empty;
            txtMontoPed.Text = string.Empty;
            listSolicitaCte.SelectedIndex = 0;
        }

        [WebMethod]
        public static List<Credito> CreditosRecepcion()
        {
            List<Credito> Lista = null;
            try
            {
                Lista = CreditoLN.getInstance().ListarCreditos();
            }
            catch (Exception ex)
            {
                Lista = new List<Credito>();
            }
            return Lista;
        }
    }
}