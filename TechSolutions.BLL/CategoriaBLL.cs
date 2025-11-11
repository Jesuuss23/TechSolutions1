using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Collections.Generic;
using System;

namespace TechSolutions.BLL
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL _categoriaDAL = new CategoriaDAL();

        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                return _categoriaDAL.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al obtener categorías: "+ ex.Message);
            }
        }
    }
}