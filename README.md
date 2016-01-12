# SinglePageApplication.AspNet
ASP.NET 5 middleware to serve files for a single page application

## Installation

Add the package SinglePageApplication.AspNet from Nuget to your project, or to your project.json. And you're done.

## Usage

```C#
// add the following using directives
using Microsoft.AspNet.Builder;
using SinglePageApplication.AspNet;

// in your Startup.cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // other middlewares you may have...
    var options = new SinglePageAppOptions.Builder("/app", "/content/app/index.html")
        .IgnorePath("/content")
        .IgnorePath("/lib")
        .Build();

    app.UseSinglePageApp(options);
}
```

The code above will change the path (**NOT A BROWSER REDIRECT**) of the request to `/content/app/index.html`, if it starts with `/app` and doesn't start with `/content` or `/lib`, and let the request continue so it can be handled by your file server middleware.

- The requests `/`, `/index.html`, `/anything.html`, will NOT be changed.
- The requests `/app`, `/app/settings`, `/app/anything` will have it's path changed.
- The requests `/content/css`, `/lib/angular`, `/lib/jquery` and sub-path passed to `IgnoredPaths` will NOT be changed.