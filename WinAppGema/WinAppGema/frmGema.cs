using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppGema
{
    public partial class frmGema : Form
    {
        Gema ObjGema = new Gema();
        public frmGema() {
            InitializeComponent();
        }

        private void frmGema_Load(object sender, EventArgs e) {
            ObjGema.InitializeData(txtSide, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e) {
            ObjGema.ReadData(txtSide);
            ObjGema.DibujarDecagonoMayor(picCanvas);
            ObjGema.DibujarDecagonoMedio(picCanvas);
            ObjGema.DibujarDecagonoMenor(picCanvas);
            ObjGema.PuntoFinal(picCanvas);
            ObjGema.PintarPetalosP(picCanvas);
            ObjGema.PintarPetalosS(picCanvas);
        }
        
        private void btnReset_Click(object sender, EventArgs e) {
            ObjGema.InitializeData(txtSide, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            ObjGema.CloseForm(this);
        }
    }
}
