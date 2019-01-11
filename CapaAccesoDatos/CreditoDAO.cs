using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class CreditoDAO
    {
        #region "PATRON SINGLETON"
        private static CreditoDAO daoCredito = null;
        private CreditoDAO() { }
        public static CreditoDAO getInstance()
        {
            if (daoCredito == null)
            {
                daoCredito = new CreditoDAO();
            }
            return daoCredito;
        }
        #endregion

        public bool NuevoCredito(Credito objCredito)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spNuevoCredito", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", objCredito.FechaInicio);
                cmd.Parameters.AddWithValue("@CveCte", objCredito.CveCte);
                cmd.Parameters.AddWithValue("@MontoPago", objCredito.MontoPago);
                cmd.Parameters.AddWithValue("@PrecioPedio", objCredito.PrecioPedido);
                cmd.Parameters.AddWithValue("@UsrRecep", objCredito.UserRecep);
                cmd.Parameters.AddWithValue("@SoliCte", objCredito.SolicitudCte);

                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return response;

        }

        public bool ActualizaCredito(Credito objCredito)
        {
            bool response = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizaCredito", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCredito", objCredito.IdCredito);
                cmd.Parameters.AddWithValue("@prmStatusCobranza", objCredito.StatusCobranza);
                cmd.Parameters.AddWithValue("@Motivo", objCredito.Motivo);
                cmd.Parameters.AddWithValue("@qAutoriza", objCredito.Autorizado);
                cmd.Parameters.AddWithValue("@StatusVen", objCredito.StatusVendedor);
                cmd.Parameters.AddWithValue("@fchAcept", objCredito.FechaAceptado);

                conexion.Open();
                cmd.ExecuteNonQuery();
                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return response;
        }

        public bool ActualizaModif(string usr, int id_cred, string fecha)
        {
            bool response = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spModificado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsr", usr);
                cmd.Parameters.AddWithValue("@prmCrd", id_cred);
                cmd.Parameters.AddWithValue("@prmFecha", fecha);

                conexion.Open();
                cmd.ExecuteNonQuery();
                response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }

        public List<Credito> ListarCreditos()
        {
            List<Credito> Lista = new List<Credito>();
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarCreditos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Credito objCredito = new Credito();
                    objCredito.IdCredito = Convert.ToInt32(dr["id_credito"].ToString());
                    objCredito.FechaInicio = dr["fecha_inicio"].ToString();
                    objCredito.CveCte = dr["cve_cte"].ToString();
                    objCredito.MontoPago = float.Parse(dr["monto_pago"].ToString());
                    objCredito.PrecioPedido = float.Parse(dr["precio_pedido"].ToString());
                    objCredito.StatusCobranza = Convert.ToInt32(dr["status_cobranza"].ToString());
                    objCredito.Motivo = dr["motivo"].ToString();
                    objCredito.Autorizado = Convert.ToInt32(dr["autorizado"].ToString());
                    objCredito.StatusVendedor = Convert.ToInt32(dr["status_vendedor"].ToString());
                    objCredito.FechaAceptado = dr["fecha_aceptacion"].ToString();
                    objCredito.SolicitudCte = dr["solicitud_cte"].ToString();
                    Lista.Add(objCredito);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Lista;
        }

        public List<Credito> datosCredito(int id_credito)
        {
            List<Credito> Lista = new List<Credito>();
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spDatosCredito", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCredito", id_credito);

                conexion.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Credito objCredito = new Credito();
                    objCredito.CveCte = dr["cve_cte"].ToString();
                    objCredito.StatusCobranza = Int32.Parse(dr["status_cobranza"].ToString());
                    objCredito.Motivo = dr["motivo"].ToString();
                    objCredito.Autorizado = Int32.Parse(dr["autorizado"].ToString());
                    objCredito.StatusVendedor = Int32.Parse(dr["status_vendedor"].ToString());
                    Lista.Add(objCredito);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return Lista;
        }
    }
}