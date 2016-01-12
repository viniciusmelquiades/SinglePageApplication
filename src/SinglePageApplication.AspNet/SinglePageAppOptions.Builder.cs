using Microsoft.AspNet.Http;
using System;
using System.Collections.Immutable;

namespace SinglePageApplication.AspNet
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
