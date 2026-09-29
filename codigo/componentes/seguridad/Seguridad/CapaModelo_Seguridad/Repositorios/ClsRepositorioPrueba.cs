using CapaModelo_Seguridad.Contratos;
using CapaModelo_Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * ==================================================================
 * Área : Seguridad
 * Autor : Carlos David Calderón Ramirez
 * Carné : 9959-23-848
 * Fecha : 22/09/2026
 * ==================================================================
 * Propósito :
 * Aqui es esta clase se encuentran los querys utilizados para
 * realizar las diferentes acciones como insertar, seleccionar,
 * modificar y eliminar junto con el metodo para cada accion.
 * ===================================================================
*/

namespace CapaModelo_Seguridad.Repositorios
{
    public class ClsRepositorioPrueba : ClsSentencias,IRepositorioPrueba
    {
        private string _SelectAll;
        private string _Insert;
        private string _Update;
        private string _Delete;

        public ClsRepositorioPrueba()
        {
            _SelectAll = "SELECT * FROM tblbodegas";
            _Insert = "INSERT INTO tblbodegas VALUES (DEFAULT, ?,DEFAULT, DEFAULT, DEFAULT)";
            _Update = "UPDATE video SET nombre_bodega=? WHERE id_video=?";
            _Delete = "DELETE FROM tblEmpleado WHERE idEmpleado=?";
        }

        public int SeguridadMetAgregar(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_codigo_bodega", Entidad.CodigoBodega));
            Parametros.Add(new OdbcParameter("p_nombre_bodega", Entidad.NombreBodega));
           
          

            return SeguridadMetEjecucionNonQuery(_Insert, Parametros, CommandType.Text);
        }

        public int SeguridadMetEditar(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_codigo_bodega", Entidad.CodigoBodega));
            Parametros.Add(new OdbcParameter("p_nombre_bodega", Entidad.NombreBodega));


            return SeguridadMetEjecucionNonQuery(_Update, Parametros, CommandType.Text);
        }

        public int SeguridadMetRemover(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_codigo_bodega", Entidad.CodigoBodega));

            return SeguridadMetEjecucionNonQuery(_Delete, Parametros, CommandType.Text);
        }

        public IEnumerable<ClsPrueba> SeguridadMetObtenerTodos()
        {
            var ListaEmpleados = new List<ClsPrueba>();
            var TablaDatos = SeguridadMetEjecucionConsulta(_SelectAll, CommandType.Text);
            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Empleado = new ClsPrueba();
                Empleado.CodigoBodega = Convert.ToInt32(Fila[0]);
                Empleado.NombreBodega = Fila[1].ToString();
                
                Empleado.IsActive = Convert.ToBoolean(Fila[2]);
                Empleado.CreatedAt = Convert.ToDateTime(Fila[3]);
                Empleado.UpdatedAt = Convert.ToDateTime(Fila[4]);
                ListaEmpleados.Add(Empleado);
            }
            TablaDatos.Clear();
            TablaDatos = null;
            return ListaEmpleados;
        }
    }
}