using LibraryofBooks.BLL.Infrastructure;
using LibraryofBooks.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using LibraryofBooks.BLL.Interfaces;
using LibraryofBooks.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using LibraryofBooks.DAL;
using LibraryofBooks.DAL.Identity;
using LibraryofBooks.DAL.Repositories;
using LibraryofBooks.ViewModels;
namespace LibraryofBooks.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWorkManager _database { get; set; }

        public UserService(IUnitOfWorkManager uow)
        {
            _database = uow;
        }

        public async Task<OperationDetails> Create(RegisterViewModel userDto, string role)
        {
            ApplicationUser user = await _database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await _database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await _database.UserManager.AddToRoleAsync(user.Id, role );
                // создаем профиль клиента
                await _database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }
        public async Task<ClaimsIdentity> Authenticate(LoginViewModel userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await _database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


        // начальная инициализация бд
        public async Task SetInitialData(RegisterViewModel adminDto, List<string> roles, string admin)
        {
            foreach (string roleName in roles)
            {
                var role = await _database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await _database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto, admin);
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
