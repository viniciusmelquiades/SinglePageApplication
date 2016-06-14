using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageApplication.AspNet
{
	public class SinglePageAppMiddleware
	{
		private readonly SinglePageAppOptions options;
		private readonly RequestDelegate next;

		public SinglePageAppMiddleware(RequestDelegate next, SinglePageAppOptions options)
		{
			this.next = next;
			this.options = options;
		}

		public async Task Invoke(HttpContext context)
		{
			if(
				context.Request.Path.StartsWithSegments(options.Path) &&
				!options.IgnoredPaths.Any(path => context.Request.Path.StartsWithSegments(path)))
			{
				context.Request.Path = options.AppRoot;
			}


			await next.Invoke(context);
		}
	}
}
