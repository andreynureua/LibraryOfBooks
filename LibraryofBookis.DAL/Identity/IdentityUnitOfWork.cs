using LibraryofBooks.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryofBooks.Entities;

namespace LibraryofBooks.DAL.Identity
{
    public class IdentityUnitOfWork : IUnitOfWorkManager
    {

        private ApplicationContext _db;

        private ApplicationUserManager _userManager { get; set; }
        private ApplicationRoleManager _roleManager { get; set; }

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }


        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                }
                this.disposed = true;
            }
        }

    }
}
