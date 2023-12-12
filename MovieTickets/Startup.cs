using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieTickets.Startup))]
namespace MovieTickets
{
    public partial class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}

