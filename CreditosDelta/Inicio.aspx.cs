using System;
using System.Collections.Generic;
using System.Web.Services;
using CapaEntidades;
using CapaLogicaNegocio;
using CreditosDelta.Custom;

namespace CreditosDelta
{
    public partial class Inicio : BasePage
    {
        static string usuario = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["App"] == null)
                Response.Redirect("Login.aspx");
            else usuario = Application["App"].ToString(); ;
        }

        [WebMethod]
        public static List<Usuario> getArea()
        {
            List<Usuario> Lista = null;
            try
            {
                Lista = UsuarioLN.getInstance().getArea(usuario);
            }catch(Exception ex)
            {
                Lista = new List<Usuario>();
            }
            return Lista;
        }
    }
}