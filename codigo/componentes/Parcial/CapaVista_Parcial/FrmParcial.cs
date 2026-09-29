using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Parcial
{
    public partial class FrmParcial : Form
    {
        public FrmParcial()
        {
            InitializeComponent();
            navegador1.NavegadorMetConfigurar("bodegas", 4, 5);
        }

        private void FrmParcial_Load(object sender, EventArgs e)
        {

        }
    }
}
