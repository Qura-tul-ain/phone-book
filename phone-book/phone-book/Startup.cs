using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(phone_book.Startup))]
namespace phone_book
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
