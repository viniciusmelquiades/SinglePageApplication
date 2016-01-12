using Microsoft.AspNet.Http;
using System.Collections.Immutable;

namespace SinglePageApplication.AspNet
{
	public partial class SinglePageAppOptions
	{

		private SinglePageAppOptions(PathString path, PathString appRoot, ImmutableArray<PathString> ignoredPaths)
		{
			Path = path;
			AppRoot = appRoot;
			IgnoredPaths = ignoredPaths;
		}

		public PathString Path
		{ get; }

		public PathString AppRoot
		{ get; }

		public ImmutableArray<PathString> IgnoredPaths
		{ get; }
	}
}
