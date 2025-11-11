// --- Archivo: ProductoBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class ProductoBLL
    {
        // Instancia de la DAL de Producto
        private readonly ProductoDAL _productoDAL = new ProductoDAL();

        /// <summary>
        /// Lógica de negocio para obtener productos.
        /// </summary>
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

        /// <summary>
        /// Lógica de negocio para registrar un nuevo producto.
        /// </summary>
        public bool RegistrarProducto(Producto producto)
        {
            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0 || producto.Stock < 0 || producto.IdCategoria <= 0)
            {
                return false; // Datos básicos incompletos
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

        /// <summary>
        /// Lógica de negocio para actualizar un producto.
        /// </summary>
        public bool ActualizarProducto(Producto producto)
        {
            // --- Reglas de Negocio ---
            if (producto.IdProducto <= 0 || string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0 || producto.Stock < 0 || producto.IdCategoria <= 0)
            {
                return false; // Datos básicos incompletos
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

        /// <summary>
        /// Lógica de negocio para eliminar (lógicamente) un producto.
        /// </summary>
        public bool EliminarProducto(int idProducto)
        {
            // --- Reglas de Negocio ---
            if (idProducto <= 0)
            {
                return false; // ID no válido
            }

            try
            {
                _productoDAL.EliminarProducto(idProducto);
                return true; // Éxito si no hay excepción
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al eliminar el producto: " + ex.Message);
            }
        }
    }
}