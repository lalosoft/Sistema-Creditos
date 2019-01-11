using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion

        public Usuario AccesoSistema(string id_usr, string pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", id_usr.ToLower());
                cmd.Parameters.AddWithValue("@prmPass", pass);

                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.ID_Usuario = dr["id_usuario"].ToString();
                    objUsuario.Pass = dr["contrasenia"].ToString();
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }

        public bool guardaAcceso(string id_usr, DateTime fecha)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAcceso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", id_usr);
                cmd.Parameters.AddWithValue("@fecha_acceso", fecha);

                conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            finally
            {
                conexion.Close();
            }
            return response;
        }

        public List<Usuario> getArea(string id_user)
        {
            List<Usuario> Lista = new List<Usuario>();
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spGetArea", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUser", id_user);

                conexion.Open();
                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Area_Empleado = Int32.Parse(dr["area_job"].ToString());
                    Lista.Add(objUsuario);
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
