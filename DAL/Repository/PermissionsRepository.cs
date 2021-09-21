using BusLay.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class PermissionsRepository
    {
        private readonly DataContext context;
        public PermissionsRepository(DataContext context)
        {
            this.context = context;
        }
        public Permission GetPermission(Permission permission)
        {
            try
            {
                context.Permissions.Add(permission);
                context.SaveChanges();
                return permission;
            }
            catch (Exception)
            {
                throw new Exception("HELL");
            }
           
        }

    }
}
