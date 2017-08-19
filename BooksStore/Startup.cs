using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooksStore.Startup))]
namespace BooksStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
