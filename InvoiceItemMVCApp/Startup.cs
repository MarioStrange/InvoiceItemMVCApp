using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceItemMVCApp.Startup))]
namespace InvoiceItemMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
