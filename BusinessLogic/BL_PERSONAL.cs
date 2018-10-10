using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using UserCode;
using System.Web;
namespace BusinessLogic
{
    public  class BL_PERSONAL
    {
        public DataTable Listar_disponibilidadPersonal(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_disponibilidadPersonal(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalCC(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_PersonalCC(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_Personal_Estados(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_Personal_Estados(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_PersonalGrupo(BE_PERSONAL obj)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_PersonalGrupo(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarPersonal(string centro,int idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            try
            {
                return new DA_PERSONAL().Get_AsignarPersonal(centro, idPersona, empresa, estado, capataz,ingeniero,fecha );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarPersonal_dni(string centro, string  idPersona, int empresa, int estado, string capataz, string ingeniero, string fecha)
        {
            try
            {
                return new DA_PERSONAL().Get_AsignarPersonal_DNI(centro, idPersona, empresa, estado, capataz, ingeniero, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Trabajadores_WCF(BE_PERSONAL oBE)
        {
            try
            {
                return new DA_PERSONAL().Mant_Insert_Trabajadores_WCF(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Mant_Insert_Trabajadores_WCF_DNI(BE_PERSONAL oBE)
        {
            try
            {
                return new DA_PERSONAL().Mant_Insert_Trabajadores_WCF_DNI(oBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UpdateCategoria(int idPersona, int categoria, string centro)
        {
            try
            {
                return new DA_PERSONAL().UpdateCategoria( idPersona, categoria, centro );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_Personal_x_Categoria(string Centro, int empresa, string grupo)
        {
            try
            {
                return new DA_PERSONAL().Get_Listar_Personal_x_Categoria(Centro, empresa, grupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable AsignarResponsable(string idPersona, string ingeniero, int tipo, int empresa, string centro)
        {
            try
            {
                return new DA_PERSONAL().AsignarResponsable(idPersona, ingeniero, tipo, empresa , centro );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Update_EstadoPersonal( int empresa, string centro,string TipoPersona)
        {
            try
            {
                return new DA_PERSONAL().Update_EstadoPersonal( empresa, centro, TipoPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable UpdateEstadoPersonal(string centro, int idPersona, int empresa, int estado)
        {
            try
            {
                return new DA_PERSONAL().Get_UpdateEstadoPersonal(centro, idPersona, empresa, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SP_OBTENER_PERSONAL(string Centro)
        {
            try
            {
                return new DA_PERSONAL().SP_OBTENER_PERSONAL(Centro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable uspUPD_PERSONAL_CATEGORIA_CAMBIO(int idPersona,int idPersonaNuevo, int categoria, string centro)
        {
            try
            {
                return new DA_PERSONAL().uspUPD_PERSONAL_CATEGORIA_CAMBIO(idPersona, idPersonaNuevo,categoria, centro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
