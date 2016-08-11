using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Nancy;
using Nancy.Owin;

namespace NancyRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
			IWebHost host = new WebHostBuilder()
				.UseKestrel()
				.Configure(conf =>
				{
					conf.UseOwin(o => o.UseNancy());
				})
				.UseUrls(new[] { "http://localhost:1234" })
				.Build();

			host.Run();
        }
    }

	public class TestRoute : NancyModule
	{
		public TestRoute()
		{
			Get("/", _ =>
			{
				return System.Guid.NewGuid().ToString();
			});

			Post("/", _ =>
			{
				return System.Guid.NewGuid().ToString();
			});
		}
	}
}
