**API Versioning**

Summary:
It's a technique without breaking the existing API functionality

1. URL-Based Versioning: ex: api/v1/vendor
2. Header-Based Versioning
3. Query String Based Versioning
4. Media type versioning

Prerequisites:
1. Visual Studio 2022
2. .NET >=6 SDK

Implementation:
1. Go to Nuget package Manager -> install Asp.Versioning.Mvc and Asp.Versioning.Mvc.ApiExplorer
   
   Use shortcut Alt V E O (View → Other windows → Package Manager Console)
   dotnet add package Asp.Versioning.Mvc
   dotnet add package Asp.Versioning.Mvc.ApiExplorer

2. In program.cs file add below code before (var app = builder.Build();)
````
builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true; //This ensures if client doesn't specify an API version. The default version should be considered. 
    option.DefaultApiVersion = new ApiVersion(1, 0); //This we set the default API version
    option.ReportApiVersions = true; //The allow the API Version information to be reported in the client  in the response header. This will be useful for the client to understand the version of the API they are interacting with.
    
    //------------------------------------------------//
    option.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver")
     ); //This says how the API version should be read from the client's request, 3 options are enabled 1.Querystring, 2.Header, 3.MediaType. 
                                               //"api-version", "X-Version" and "ver" are parameter name to be set with version number in client before request the endpoints.
}).AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV"; //The say our format of our version number “‘v’major[.minor][-status]”
    options.SubstituteApiVersionInUrl = true; //This will help us to resolve the ambiguity when there is a routing conflict due to routing template one or more end points are same.
});
````
3. Implement in end points (Two important steps)    
     1.  Api versions that Controller supports, with the help of [ApiVersion(“1.0”)],[ApiVersion(“2.0”)] and decorate at Controller level.
     2.  Define the method map to the Api Version at action method level with help of [MapToApiVersion(“1.0”)],[MapToApiVersion(“2.0”)] attributes respectively.


Reference: 
1. https://medium.com/@softsusanta/net-core-api-versioning-implementation-step-by-step-92107e447798
2. https://github.com/9susanta/Articles/tree/219432bab6f59153bd4e6c6b398a6f34526a4c80/APIVersioning
3. https://weblogs.asp.net/ricardoperes/asp-net-core-api-versioning