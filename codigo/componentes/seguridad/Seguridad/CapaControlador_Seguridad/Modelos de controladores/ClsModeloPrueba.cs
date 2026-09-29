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
        private int _IdVideo;
        private string _TituloVideo;
        private string _GeneroVideo;
        private double _PrecioRentaVideo;
        private int _StockVideo;
        private string _CodigoVideo;
        private string _DirectorVideo;
        private int _AnioVideo;
        private string _ClasificacionVideo;
        private int _DuracionVideo;
        private string _IdiomaVideo;
        private bool _IsActive;
        private DateTime _CreatedAt;
        private DateTime _UpdatedAt;
        private ClsRepositorioPrueba _RepositorioPrueba;

        public EstadoEntidad Estado { private get; set; }
        private List<ClsModeloPrueba> _ListaVideo;

        public int IdVideo { get => _IdVideo; set => _IdVideo = value; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(150, MinimumLength = 1)]
        public string TituloVideo { get => _TituloVideo; set => _TituloVideo = value; }

        [StringLength(50)]
        public string GeneroVideo { get => _GeneroVideo; set => _GeneroVideo = value; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        public double PrecioRentaVideo { get => _PrecioRentaVideo; set => _PrecioRentaVideo = value; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int StockVideo { get => _StockVideo; set => _StockVideo = value; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(20, MinimumLength = 1)]
        public string CodigoVideo { get => _CodigoVideo; set => _CodigoVideo = value; }

        [Required(ErrorMessage = "El director es obligatorio")]
        [StringLength(100)]
        public string DirectorVideo { get => _DirectorVideo; set => _DirectorVideo = value; }

        [Range(1888, 2100, ErrorMessage = "El año no es válido")]
        public int AnioVideo { get => _AnioVideo; set => _AnioVideo = value; }

        [Required(ErrorMessage = "La clasificación es obligatoria")]
        [StringLength(10)]
        public string ClasificacionVideo { get => _ClasificacionVideo; set => _ClasificacionVideo = value; }

        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser mayor a cero")]
        public int DuracionVideo { get => _DuracionVideo; set => _DuracionVideo = value; }

        [Required]
        [StringLength(30)]
        public string IdiomaVideo { get => _IdiomaVideo; set => _IdiomaVideo = value; }

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
                    _IdVideo = Item.IdVideo,
                    _TituloVideo = Item.TituloVideo,
                    _GeneroVideo = Item.GeneroVideo,
                    _PrecioRentaVideo = Item.PrecioRentaVideo,
                    _StockVideo = Item.StockVideo,
                    _CodigoVideo = Item.CodigoVideo,
                    _DirectorVideo = Item.DirectorVideo,
                    _AnioVideo = Item.AnioVideo,
                    _ClasificacionVideo = Item.ClasificacionVideo,
                    _DuracionVideo = Item.DuracionVideo,
                    _IdiomaVideo = Item.IdiomaVideo,
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
                v._IdVideo.ToString() == Filtro ||
                (v._TituloVideo != null && v._TituloVideo.Contains(Filtro)));
        }
    }
}