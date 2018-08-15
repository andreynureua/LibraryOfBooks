using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using LibraryofBooks.BLL.Services;
using Microsoft.AspNet.Identity;
using LibraryofBooks.BLL.Interfaces;

[assembly: OwinStartup(typeof(LibraryofBooks.Startup))]
namespace LibraryofBooks
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DbConnect");
        }

    }
}
