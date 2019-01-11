using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CapaEntidades;
using CapaLogicaNegocio;
using CreditosDelta.Custom;

namespace CreditosDelta
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["UserSession"] = null;
                Application["App"] = null;
            }
        }

        /*protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = UsuarioLN.getInstance().AccesoSistema(txtUsuario.Text, txtPass.Text);
            if (objUsuario != null)
            {
                Application["App"] = txtUsuario.Text;
                UsuarioLN.getInstance().guardaAcceso(txtUsuario.Text, DateTime.Now);
                Response.Redirect("Inicio.aspx");
            }
            else Response.Write("<script>alert('usuario incorrecto')</script>");
        }*/

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);

            if (auth)
            {
                Usuario objUsuario = UsuarioLN.getInstance().AccesoSistema(LoginUser.UserName, LoginUser.Password);

                if (objUsuario != null)
                {
                    SessionManager = new SessionManager(Session);
                    SessionManager.UserSessionObjeto = objUsuario;

                    Application["App"] = LoginUser.UserName.ToLower();
                    UsuarioLN.getInstance().guardaAcceso(LoginUser.UserName, DateTime.Now);

                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);


                    //Response.Redirect("Inicio.aspx");
                }
                else Response.Write("<script>alert('usuario incorrecto')</script>");
            }
        }
    }
}