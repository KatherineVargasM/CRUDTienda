using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CRUDTienda.Models;

namespace CRUDTienda.Controller
{
    internal class PaisesController
    {
        private PaisesModel paisesModel = new PaisesModel();

        public List<PaisesModel> Todos()
        {
            return paisesModel.Todos();
        }

        public PaisesModel Obtener(int idPais)
        {
            return paisesModel.Obtener(idPais);
        }

        public string Insertar(PaisesModel pais)
        {
            return paisesModel.Insertar(pais);
        }

        public string Editar(PaisesModel pais)
        {
            return paisesModel.Editar(pais);
        }

        public string Eliminar(PaisesModel pais)
        {
            return paisesModel.Eliminar(pais);
        }
    }
}
