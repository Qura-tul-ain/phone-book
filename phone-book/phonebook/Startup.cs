using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(phonebook.Startup))]
namespace phonebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
