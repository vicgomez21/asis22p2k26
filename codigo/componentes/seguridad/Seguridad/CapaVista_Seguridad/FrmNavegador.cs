using CapaControlador_Seguridad;
using CapaVista_Seguridad.frmReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace CapaVista_Seguridad
{
    public partial class FrmNavegador : Form
    {
        public FrmNavegador()
        {
            InitializeComponent();
            navegador1.NavegadorMetConfigurar("tblbodegas", 4, 5);
            SeguridadMetInterceptarAyuda();
        }
        

        private void FrmNavegador_Load(object sender, EventArgs e)
        {

        }

        private void navegador1_NavegadorAccionSolicitada(string obj)
        {
            switch (obj)
            {
                case "IMPRIMIR":

                    new FrmReportePrueba().Show();
                    break;
            }
        }
        private void SeguridadMetInterceptarAyuda()
        {
            var btn = navegador1.Controls.Find("NavegadorBtnAyuda", true).FirstOrDefault();
            if (btn == null) return;
            
            var fi =typeof(Component).GetField("events", BindingFlags.NonPublic | BindingFlags.Instance);
            var eventList = fi.GetValue(btn) as EventHandlerList;
            var clickKey = typeof(Control).GetField("EventClick", BindingFlags.NonPublic | BindingFlags.Static)
                                                        ?.GetValue(null);
            if(eventList != null && clickKey != null)
            {
                eventList.RemoveHandler(clickKey, eventList[clickKey]);
            }

            btn.Click += (s, ev) =>
            {
                System.Diagnostics.Process.Start(
                  @"C:\proyectoasis22k26\ayuda\componentes\seguridad\SeguridadAyudas\SeguridadAyudas.chm");
            };
        }
    }
}
