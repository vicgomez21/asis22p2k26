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
            _SelectAll = "SELECT * FROM video";
            _Insert = "INSERT INTO video VALUES (DEFAULT, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, DEFAULT, DEFAULT, DEFAULT)";
            _Update = "UPDATE video SET titulo=?, genero=?, precio_renta=?, stock=?, codigo=?, director=?, anio=?, clasificacion=?, duracion=?, idioma=? WHERE id_video=?";
            _Delete = "DELETE FROM tblEmpleado WHERE idEmpleado=?";
        }

        public int SeguridadMetAgregar(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_titulo", Entidad.TituloVideo));
            Parametros.Add(new OdbcParameter("p_genero", Entidad.GeneroVideo));
            Parametros.Add(new OdbcParameter("p_precio_renta", Entidad.PrecioRentaVideo));
            Parametros.Add(new OdbcParameter("p_stock", Entidad.StockVideo));
            Parametros.Add(new OdbcParameter("p_codigo", Entidad.CodigoVideo));
            Parametros.Add(new OdbcParameter("p_director", Entidad.DirectorVideo));
            Parametros.Add(new OdbcParameter("p_anio", Entidad.AnioVideo));
            Parametros.Add(new OdbcParameter("p_clasificacion", Entidad.ClasificacionVideo));
            Parametros.Add(new OdbcParameter("p_duracion", Entidad.DuracionVideo));
            Parametros.Add(new OdbcParameter("p_idioma", Entidad.IdiomaVideo));
          

            return SeguridadMetEjecucionNonQuery(_Insert, Parametros, CommandType.Text);
        }

        public int SeguridadMetEditar(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_titulo", Entidad.TituloVideo));
            Parametros.Add(new OdbcParameter("p_genero", Entidad.GeneroVideo));
            Parametros.Add(new OdbcParameter("p_precio_renta", Entidad.PrecioRentaVideo));
            Parametros.Add(new OdbcParameter("p_stock", Entidad.StockVideo));
            Parametros.Add(new OdbcParameter("p_codigo", Entidad.CodigoVideo));
            Parametros.Add(new OdbcParameter("p_director", Entidad.DirectorVideo));
            Parametros.Add(new OdbcParameter("p_anio", Entidad.AnioVideo));
            Parametros.Add(new OdbcParameter("p_clasificacion", Entidad.ClasificacionVideo));
            Parametros.Add(new OdbcParameter("p_duracion", Entidad.DuracionVideo));
            Parametros.Add(new OdbcParameter("p_idioma", Entidad.IdiomaVideo));
            Parametros.Add(new OdbcParameter("p_id_video", Entidad.IdVideo));

            return SeguridadMetEjecucionNonQuery(_Update, Parametros, CommandType.Text);
        }

        public int SeguridadMetRemover(ClsPrueba Entidad)
        {
            var Parametros = new List<OdbcParameter>();
            Parametros.Add(new OdbcParameter("p_id_video", Entidad.IdVideo));

            return SeguridadMetEjecucionNonQuery(_Delete, Parametros, CommandType.Text);
        }

        public IEnumerable<ClsPrueba> SeguridadMetObtenerTodos()
        {
            var ListaEmpleados = new List<ClsPrueba>();
            var TablaDatos = SeguridadMetEjecucionConsulta(_SelectAll, CommandType.Text);
            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Empleado = new ClsPrueba();
                Empleado.IdVideo = Convert.ToInt32(Fila[0]);
                Empleado.TituloVideo = Fila[1].ToString();
                Empleado.GeneroVideo = Fila[2].ToString();
                //datos double y float
                Empleado.PrecioRentaVideo =  Convert.ToDouble(Fila[3]);
                Empleado.StockVideo = Convert.ToInt32(Fila[4]);
                Empleado.CodigoVideo = Fila[5].ToString();
                Empleado.DirectorVideo = Fila[6].ToString();
                Empleado.AnioVideo = Convert.ToInt32(Fila[7]); 
                Empleado.ClasificacionVideo = Fila[8].ToString();
                Empleado.DuracionVideo = Convert.ToInt32(Fila[9]);
                Empleado.IdiomaVideo = Fila[10].ToString();
                Empleado.IsActive = Convert.ToBoolean(Fila[11]);
                Empleado.CreatedAt = Convert.ToDateTime(Fila[12]);
                Empleado.UpdatedAt = Convert.ToDateTime(Fila[13]);
                ListaEmpleados.Add(Empleado);
            }
            TablaDatos.Clear();
            TablaDatos = null;
            return ListaEmpleados;
        }
    }
}