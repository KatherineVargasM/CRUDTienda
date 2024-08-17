using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDTienda.Controller;
using CRUDTienda.Models;

namespace CRUDTienda.Views
{
    public partial class Paises : Form
    {
        PaisesController paisesController = new PaisesController();
        public string IdPais = null;
        public Paises()
        {
            InitializeComponent();
        }

        private void Paises_Load(object sender, EventArgs e)
        {
            cargarLista();
        }
        public void cargarLista()
        {
            lst_Paises.DataSource = paisesController.Todos();
            lst_Paises.DisplayMember = "Detalle";
            lst_Paises.ValueMember = "IdPais";

        }

        private void lst_Paises_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if(lst_Paises.SelectedItem != null)
            {
                IdPais = lst_Paises.SelectedValue.ToString();
                PaisesModel pais = paisesController.Obtener(Convert.ToInt32(IdPais));
                if (pais != null)
                {
                    txt_Pais.Text = pais.Detalle;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pais de la lista.");
            }
        }

        private void lst_Paises_DoubleClick(object sender, EventArgs e)
        {
            if (lst_Paises.SelectedItem != null)
            {
                PaisesModel paisSeleccionado = (PaisesModel)lst_Paises.SelectedItem;
                string mensaje = $"Nombre del Pais: {paisSeleccionado.Detalle}";

                MessageBox.Show(mensaje, "Informacion del Pais");
            }
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            PaisesModel pais = new PaisesModel
            {
                IdPais = string.IsNullOrEmpty(IdPais) ? 0 : Convert.ToInt32(IdPais),
                Detalle = txt_Pais.Text
            };

            if (pais.IdPais > 0)
            {
                respuesta = paisesController.Editar(pais);
            }
            else
            {
                respuesta = paisesController.Insertar(pais);
            }

            if (respuesta == "ok")
            {
                IdPais = null;
                cargarLista();
                MessageBox.Show("Se guardo con exito.");
            }
            else
            {
                IdPais = null;
                MessageBox.Show("Error al guardar.");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lst_Paises.SelectedItem != null)
            {
                PaisesModel pais = new PaisesModel
                {
                    IdPais = Convert.ToInt32(lst_Paises.SelectedValue)
                };
                string respuesta = paisesController.Eliminar(pais);

                if (respuesta == "ok")
                {
                    cargarLista();
                    MessageBox.Show("Pais eliminado con exito.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pais.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pais de la lista.");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Pais.Text = string.Empty;
            IdPais = null;
            lst_Paises.ClearSelected();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
