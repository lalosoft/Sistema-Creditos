using System;
using System.Collections.Generic;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocio
{
    public class CreditoLN
    {
        #region "PATRON SINGLETON"
        private static CreditoLN objCredito = null;
        private CreditoLN() { }
        public static CreditoLN getInstance()
        {
            if (objCredito == null)
            {
                objCredito = new CreditoLN();
            }
            return objCredito;
        }
        #endregion

        public bool NuevoCredito(Credito objCredito)
        {
            try
            {
                return CreditoDAO.getInstance().NuevoCredito(objCredito);

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool ActualizaCredito(Credito objCredito)
        {
            try
            {
                return CreditoDAO.getInstance().ActualizaCredito(objCredito);

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool ActualizaModif(string usr, int id_cred, string fecha)
        {
            try
            {
                return CreditoDAO.getInstance().ActualizaModif(usr, id_cred, fecha);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Credito> ListarCreditos()
        {
            try
            {
                return CreditoDAO.getInstance().ListarCreditos();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Credito> datosCredito(int id_credito)
        {
            try
            {
                return CreditoDAO.getInstance().datosCredito(id_credito);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}