using Microsoft.AspNet.Http;
using System;
using System.Collections.Immutable;

namespace SinglePageApplication
{
	public partial class SinglePageAppOptions
	{
		public class Builder
		{
			public PathString Path { get; set; }

			public PathString AppRoot { get; set; }

			private readonly ImmutableArray<PathString>.Builder ignoredPaths;

			public Builder()
			{
				ignoredPaths = ImmutableArray<PathString>.Empty.ToBuilder();
			}

			public Builder(PathString path, PathString appRoot)
				: this()
			{
				this.Path = path;
				this.AppRoot = appRoot;
			}

			/// <summary>
			/// Ignores a path, so it's not rewritten
			/// </summary>
			/// <param name="path"></param>
			/// <returns></returns>
			public Builder IgnorePath(PathString path)
			{
				ignoredPaths.Add(path);

				return this;
			}

			/// <summary>
			/// Ignored the paths /lib and /content by default
			/// </summary>
			/// <param name="path"></param>
			/// <param name="appRoot"></param>
			/// <returns></returns>
			public static Builder WithDefaultOptions(PathString path, PathString appRoot)
			{
				return new Builder(path, appRoot)
					.IgnorePath("/lib")
					.IgnorePath("/Content");
			}

			/// <summary>
			/// Generates a new SimglePageAppOptions from this builder
			/// </summary>
			/// <returns></returns>
			public SinglePageAppOptions Build()
			{
				if(Path == null)
					throw new InvalidOperationException($"Cannot call build without setting the ${Path}");

				if(AppRoot == null)
					throw new InvalidOperationException($"Cannot call build without setting the ${AppRoot}");

				return new SinglePageAppOptions(Path, AppRoot, ignoredPaths.ToImmutable());
			}
		}
	}
}
