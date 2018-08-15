using LibraryofBooks.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.DAL.Interfaces
{
    public interface IUnitOfWorkManager : IDisposable
    {

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();

    }
}
