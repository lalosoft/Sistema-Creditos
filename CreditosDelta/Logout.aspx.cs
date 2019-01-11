using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CreditosDelta.Custom;

namespace CreditosDelta
{
    public partial class Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserSession"] = null;
            Application["App"] = null;
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Login.aspx");
        }
    }
}