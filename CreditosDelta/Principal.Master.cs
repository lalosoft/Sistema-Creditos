using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CreditosDelta
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["App"] == null)
                Response.Redirect("Login.aspx");

            else lblUsuario.Text = "Bienvenido: " + Application["App"].ToString();
        }
    }
}