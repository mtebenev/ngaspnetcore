# NgAspNetCore

This is set of packages and utilities for building Angular applications with ASP.Net Core. Find more information at http://tebenev.com/technical/asp-net-core-angular-apps-ngaspnetcore/

## Step by step usage guide

First, add NgAspNetCore feed <strong>https://www.myget.org/F/ngaspnetcore/api/v3/index.json</strong> either in Visual Studio or using NuGet.config file in your solution.

### Creating client application:

1. Create class library project for the client application using 'Class Library (.NET Core)' template
2. You may want to add the following property group to prevent compiling TypeScript by IDE:
```xml
  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <TypeScriptCompileBlocked>true</TypeScriptCompileBlocked>
    <TypeScriptToolsVersion>Latest</TypeScriptToolsVersion>
  </PropertyGroup>
```

3. Create angular application in the class library with Angular-CLI:

```bash
ng new ClientAppPackage1 --skip-commit --skip-git --style scss --directory .
```

This will set up the NPM package and the Angular application.

4. Optionally add property group in csproj file to not show node_modules in Visual Studio solution explorer - that will greatly speed up projects loading in the IDE.

```xml
<PropertyGroup>
  <DefaultItemExcludes>node_modules/**;$(DefaultItemExcludes)</DefaultItemExcludes>
</PropertyGroup>
```

5. Add package reference to **NgAspNetCore.Client.Targets** package
</ol>

### Creating the host app (server):

1. Create project for the server using ASP.Net Core Web application template
2. Add package reference to **NgAspNetCore.Server.Targets**
3. Add reference to the client project (that you have created using steps above)

After that you can start building your solution. Note that client application built automatically and normally you will see the following in Build Output:
```bash
2>Performing client application build: ClientAppPackage1...
4>[0mDate: [1m[37m2017-11-21T14:40:13.434Z[39m[22m[0m
4>[0mHash: [1m[37m47844129580702182c18[39m[22m[0m
4>[0mTime: [1m[37m11429[39m[22mms[0m
4>[0mchunk {[1m[33minline[39m[22m} [1m[32minline.bundle.js, inline.bundle.js.map[39m[22m (inline) 5.83 kB [1m[33m[entry][39m[22m[1m[32m [rendered][39m[22m[0m
....
```

### Rendering client application in Razor view

When you build your host project with NgAspNetCore.Server.Targets package, it copies client app files in wwwroot/dist/%ClientAppName%. In the steps above it would be located in wwwroot/dist/ClientAppPackage1 folder. Remember that the client app eventually is just built WebPack bundle files. All we need to render the client app is to include the scripts in our Razor view like this:

```xml
<app-root></app-root>
<script src="~/dist/ClientAppPackage1/inline.bundle.js"></script>
<script src="~/dist/ClientAppPackage1/polyfills.bundle.js"></script>
<script src="~/dist/ClientAppPackage1/vendor.bundle.js"></script>
<script src="~/dist/ClientAppPackage1/styles.bundle.js"></script>
<script src="~/dist/ClientAppPackage1/main.bundle.js"></script>
```