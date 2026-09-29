using CapaControlador_Seguridad;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Seguridad.frmReportes
{
    public partial class FrmReportePrueba : Form
    {
        private ClsModeloPrueba Prueba = new ClsModeloPrueba();
        public FrmReportePrueba()
        {
            InitializeComponent();
        }

        private void FrmReportePrueba_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSourceUsuario = new ReportDataSource("Bodega", Prueba.SeguridadMetObtenerTodos());
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_Seguridad.Reportes.Reporteprueba.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSourceUsuario);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
