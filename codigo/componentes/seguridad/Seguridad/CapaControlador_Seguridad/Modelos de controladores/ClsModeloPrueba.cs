/*
 * ==================================================================
 * Área : Seguridad
 * Fecha : 29/09/2026
 * ==================================================================
 * Propósito :
 *  El ClsModeloPrueba es el controlador que valida y prepara los
 *  datos de un video antes de enviarlos al repositorio y registra
 *  cada operación (Agregar, Editar, Eliminar) en la bitácora.
 * ===================================================================
*/

using CapaModelo_Seguridad.Contratos;
using CapaModelo_Seguridad.Entidades;
using CapaModelo_Seguridad.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using System.Linq;

namespace CapaControlador_Seguridad
{
    public class ClsModeloPrueba
    {
        private int _CodigoBodega;
        private string _NombreBodega;
       
        private bool _IsActive;
        private DateTime _CreatedAt;
        private DateTime _UpdatedAt;
        private ClsRepositorioPrueba _RepositorioPrueba;

        public EstadoEntidad Estado { private get; set; }
        private List<ClsModeloPrueba> _ListaVideo;

        public int IdVideo { get => _CodigoBodega; set => _CodigoBodega = value; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(150, MinimumLength = 1)]
        public string TituloVideo { get => _NombreBodega; set => _NombreBodega = value; }

        
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public DateTime CreatedAt { get => _CreatedAt; set => _CreatedAt = value; }
        public DateTime UpdatedAt { get => _UpdatedAt; set => _UpdatedAt = value; }

        public ClsModeloPrueba()
        {
            _RepositorioPrueba = new ClsRepositorioPrueba();
        }

        public List<ClsModeloPrueba> SeguridadMetObtenerTodos()
        {
            var ResultadoConsulta = _RepositorioPrueba.SeguridadMetObtenerTodos();
            _ListaVideo = new List<ClsModeloPrueba>();
            foreach (ClsPrueba Item in ResultadoConsulta)
            {
                _ListaVideo.Add(new ClsModeloPrueba
                {
                    _CodigoBodega = Item.CodigoBodega,
                    _NombreBodega = Item.NombreBodega,
                    
                    _IsActive = Item.IsActive,
                    _CreatedAt = Item.CreatedAt,
                    _UpdatedAt = Item.UpdatedAt
                });
            }
            return _ListaVideo;
        }

        public IEnumerable<ClsModeloPrueba> SeguridadMetBuscarPorId(string Filtro)
        {
            return _ListaVideo.FindAll(v =>
                v._CodigoBodega.ToString() == Filtro ||
                (v._NombreBodega != null && v._NombreBodega.Contains(Filtro)));
        }
    }
}