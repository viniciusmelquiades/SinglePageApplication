using Microsoft.AspNet.Http;
using SinglePageApplication.AspNet;
using System.Linq;

namespace Microsoft.AspNet.Builder
{
	public static class SinglePageAppMiddlewareExtensions
	{
		public static IApplicationBuilder UseSinglePageApp(this IApplicationBuilder builder, PathString path, PathString appRoot, params PathString[] ignorePaths)
		{
			var options = ignorePaths.Aggregate(new SinglePageAppOptions.Builder(path, appRoot), (x, y) => x.IgnorePath(y));

			return UseSinglePageApp(builder, options.Build());
		}

		public static IApplicationBuilder UseSinglePageApp(this IApplicationBuilder builder, SinglePageAppOptions.Builder options)
		{
			return UseSinglePageApp(builder, options.Build());
		}

		public static IApplicationBuilder UseSinglePageApp(this IApplicationBuilder builder, SinglePageAppOptions options)
		{
			return builder.UseMiddleware<SinglePageAppMiddleware>(options);
		}
	}
}