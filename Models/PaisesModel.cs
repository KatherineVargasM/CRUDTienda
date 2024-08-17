using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CRUDTienda.Config;

namespace CRUDTienda.Models
{
    internal class PaisesModel
    {
        public int IdPais { get; set; }
        public string Detalle { get; set; }

        private ConexionBDD conexionBDD = new ConexionBDD();

        public List<PaisesModel> Todos()
        {
            string cadena = "select * from Paises";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexionBDD.AbrirConexion());
            DataTable data = new DataTable();
            adapter.Fill(data);
            List<PaisesModel> listaPaises = new List<PaisesModel>();

            foreach (DataRow fila in data.Rows)
            {
                PaisesModel pais = new PaisesModel
                {
                    IdPais = Convert.ToInt32(fila["IdPais"]),
                    Detalle = fila["Detalle"].ToString()
                };
                listaPaises.Add(pais);
            }
            conexionBDD.CerrarConexion();
            return listaPaises;
        }

        public PaisesModel Obtener(int idPais)
        {
            string cadena = "select * from Paises where IdPais = @IdPais";
            SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion());
            cmd.Parameters.AddWithValue("@IdPais", idPais);
            SqlDataReader lector = cmd.ExecuteReader();

            PaisesModel pais = null;
            if (lector.Read())
            {
                pais = new PaisesModel
                {
                    IdPais = Convert.ToInt32(lector["IdPais"]),
                    Detalle = lector["Detalle"].ToString()
                };
            }
            lector.Close();
            conexionBDD.CerrarConexion();
            return pais;
        }

        public string Insertar(PaisesModel pais)
        {
            try
            {
                string cadena = "insert into Paises (Detalle) values (@Detalle)";
                SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion());
                cmd.Parameters.AddWithValue("@Detalle", pais.Detalle);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }

        public string Editar(PaisesModel pais)
        {
            try
            {
                string cadena = "update Paises set Detalle = @Detalle where IdPais = @IdPais";
                SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion());
                cmd.Parameters.AddWithValue("@Detalle", pais.Detalle);
                cmd.Parameters.AddWithValue("@IdPais", pais.IdPais);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }

        public string Eliminar(PaisesModel pais)
        {
            try
            {
                string cadena = "delete from Paises where IdPais = @IdPais";
                SqlCommand cmd = new SqlCommand(cadena, conexionBDD.AbrirConexion());
                cmd.Parameters.AddWithValue("@IdPais", pais.IdPais);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                conexionBDD.CerrarConexion();
            }
        }
    }
}
