using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SinglePageApplication.AspNet;
using System.Linq;

namespace Microsoft.AspNetCore.Builder
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