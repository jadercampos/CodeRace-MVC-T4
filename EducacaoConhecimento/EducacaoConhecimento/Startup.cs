using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EducacaoConhecimento.Startup))]
namespace EducacaoConhecimento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
