using ClassLibrary.Modelos;
using System;
using System.Linq;
using System.Web.Services;
using WebServiceGT.DataSet1TableAdapters;

namespace WebServiceGT
{
    /// <summary>
    /// Descripción breve de WebServiceGT
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGT : System.Web.Services.WebService
    {
        DATOS_PERSONALESTableAdapter dpgt = new DATOS_PERSONALESTableAdapter();
        DataSet1 dsDatos = new DataSet1();
        EJERCICIOS_CLASESEntities datos = new EJERCICIOS_CLASESEntities();

        [WebMethod]

        public DataSet1 Ver()
        {
            DataSet1 ds;
            this.dpgt.Fill(dsDatos.DATOS_PERSONALES);
            return dsDatos;
        }

        [WebMethod]
        public DATOS_PERSONALES Buscar(string cedula)
        {
            var datosPersonales = datos.DATOS_PERSONALES.FirstOrDefault(a => a.DTPNUMDOCUMENTO == cedula);
            return datosPersonales;
        }

        [WebMethod]
        public string Insertar(string DTPTIPODOCUMENTO, string DTPNUMDOCUMENTO, string DTPAPELLIDO1, string DTPAPELLIDO2,
           int CODESTADO, string DTPNOMBRES,
           string DTPDIRECCION, string DTPTELEFONO, string DTPCORREO)
        {
            string resultado;
            try
            {
                this.dpgt.Insert(DTPTIPODOCUMENTO, DTPNUMDOCUMENTO, DTPAPELLIDO1, DTPAPELLIDO2, DTPNOMBRES, CODESTADO, DTPDIRECCION,
                    DTPTELEFONO, DTPCORREO);
                resultado = "El registro se inserto correctamente";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado = "Error al insertar" + ex.Message.ToString();
                return resultado;
            }
        }

        [WebMethod]
        public string Actualizar(int DTPCODIGOI, string DTPTIPODOCUMENTO, string DTPNUMDOCUMENTO, string DTPAPELLIDO1, string DTPAPELLIDO2,
            int CODESTADO, string DTPNOMBRES,
           string DTPDIRECCION, string DTPTELEFONO, string DTPCORREO)
        {
            string resultado;
            try
            {
                this.dpgt.Update(DTPTIPODOCUMENTO, DTPNUMDOCUMENTO, DTPAPELLIDO1, DTPAPELLIDO2, DTPNOMBRES, CODESTADO, DTPDIRECCION,
                    DTPTELEFONO, DTPCORREO, DTPCODIGOI);
                resultado = "El registro se actualizo correctamente";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado = "Error al insertar" + ex.Message.ToString();
                return resultado;
            }
        }

        [WebMethod]
        public string Eliminar(int DTPCODIGOI)
        {
            try
            {
                this.dpgt.Delete(DTPCODIGOI);
                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }

        
    }
}
