// --- Archivo: RolBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class RolBLL
    {
        private readonly RolDAL _rolDAL = new RolDAL();

        /// <summary>
        /// Lógica de negocio para obtener roles.
        /// </summary>
        public List<Rol> ObtenerRoles()
        {
            try
            {
                // Por ahora, solo llamamos a la DAL.
                return _rolDAL.ObtenerRoles();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al obtener roles: " + ex.Message);
            }
        }
    }
}