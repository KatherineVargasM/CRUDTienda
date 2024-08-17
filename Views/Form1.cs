using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDTienda.Views;

namespace CRUDTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pAISESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paises frm_Paises = new Paises();
            frm_Paises.Show();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes frm_Clientes = new Clientes();
            frm_Clientes.Show();
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores frm_Proveedores = new Proveedores();
            frm_Proveedores.Show();
        }
    }
}
