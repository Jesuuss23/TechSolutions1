

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class RolBLL
    {
        private readonly RolDAL _rolDAL = new RolDAL();

        public List<Rol> ObtenerRoles()
        {
            try
            {
                return _rolDAL.ObtenerRoles();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al obtener roles: " + ex.Message);
            }
        }
    }
}