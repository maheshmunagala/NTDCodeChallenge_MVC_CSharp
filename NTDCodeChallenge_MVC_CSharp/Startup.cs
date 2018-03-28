using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NTDCodeChallenge_MVC_CSharp.Startup))]
namespace NTDCodeChallenge_MVC_CSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
