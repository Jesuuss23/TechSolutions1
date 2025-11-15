

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL = new ProductoDAL();

        public List<Producto> ObtenerProductos()
        {
            try
            {
                return _productoDAL.ObtenerProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al obtener productos: " + ex.Message);
            }
        }

        public bool RegistrarProducto(Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0 || producto.Stock < 0 || producto.IdCategoria <= 0)
            {
                return false; 
            }

            try
            {
                return _productoDAL.RegistrarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al registrar el producto: " + ex.Message);
            }
        }

        public bool ActualizarProducto(Producto producto)
        {
            if (producto.IdProducto <= 0 || string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0 || producto.Stock < 0 || producto.IdCategoria <= 0)
            {
                return false; 
            }

            try
            {
                return _productoDAL.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al actualizar el producto: " + ex.Message);
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
            {
                return false;
            }

            try
            {
                _productoDAL.EliminarProducto(idProducto);
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al eliminar el producto: " + ex.Message);
            }
        }
    }
}