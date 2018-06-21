using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBusTicketManagement.Startup))]
namespace OnlineBusTicketManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
