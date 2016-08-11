using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
			IWebHost host = new WebHostBuilder()
				.UseStartup<Startup>()
				.UseKestrel()
				.UseUrls(new[] { "http://localhost:1234" })
				.Build();

			host.Run();
        }
    }

	public class Startup
	{
		public void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddRouting();
		}

		public void Configure(IApplicationBuilder app)
		{
			RouteHandler testRouteHandler = new RouteHandler(ctx =>
			{
				return ctx.Response.WriteAsync(string.Empty);
			});

			RouteBuilder routeBuilder = new RouteBuilder(app, testRouteHandler);
			routeBuilder.MapGet("", ctx =>
			{
				return ctx.Response.WriteAsync(System.Guid.NewGuid().ToString());
			});
			routeBuilder.MapPost("", ctx =>
			{
				return ctx.Response.WriteAsync(System.Guid.NewGuid().ToString());
			});

			app.UseRouter(routeBuilder.Build());

		}
	}
}
