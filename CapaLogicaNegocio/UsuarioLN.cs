using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class UsuarioLN
    {
        #region "PATRON SINGLETON"
        private static UsuarioLN objUsuario = null;
        private UsuarioLN() { }
        public static UsuarioLN getInstance()
        {
            if (objUsuario == null)
            {
                objUsuario = new UsuarioLN();
            }
            return objUsuario;
        }
        #endregion

        public Usuario AccesoSistema(string usr, string pass)
        {
            try
            {
                return UsuarioDAO.getInstance().AccesoSistema(usr, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool guardaAcceso(string usr, DateTime fecha_acceso)
        {
            try
            {
                return UsuarioDAO.getInstance().guardaAcceso(usr, fecha_acceso);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Usuario> getArea(string id_user)
        {
            try
            {
                return UsuarioDAO.getInstance().getArea(id_user);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
