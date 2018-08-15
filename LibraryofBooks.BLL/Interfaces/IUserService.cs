using LibraryofBooks.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryofBooks.ViewModels;

namespace LibraryofBooks.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(RegisterViewModel userDto, string role);
        Task<ClaimsIdentity> Authenticate(LoginViewModel userDto);
        Task SetInitialData(RegisterViewModel adminDto, List<string> roles, string role);
    }
}
