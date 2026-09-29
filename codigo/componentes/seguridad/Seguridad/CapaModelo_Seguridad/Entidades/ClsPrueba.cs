using System;
using System.Collections.Generic;
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
 * Aqui en esta clase se encuentran los get y set necesarios y 
 * utilizados en la vista del formulario
 * ===================================================================
*/

namespace CapaModelo_Seguridad.Entidades
{
    public class ClsPrueba
    {
        public int IdVideo { get; set; }
        public string TituloVideo { get; set; }
        public string GeneroVideo { get; set; }
        public double PrecioRentaVideo { get; set; }
        public int StockVideo { get; set; }
       
        public string CodigoVideo { get; set; }
        public string DirectorVideo { get; set; }
        public int AnioVideo { get; set; }
        public string ClasificacionVideo { get; set; }
        public int DuracionVideo { get; set; }
        public string IdiomaVideo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}