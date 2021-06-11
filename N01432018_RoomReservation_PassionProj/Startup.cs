using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(N01432018_RoomReservation_PassionProj.Startup))]
namespace N01432018_RoomReservation_PassionProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
