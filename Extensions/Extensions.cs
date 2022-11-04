namespace ProductsProject.Extensions;

public static class Extensions
{
    public static string PathAndQuery(this HttpContext Context) =>
        Context.Request.QueryString.HasValue
            ? Context.Request.Path + "/" + Context.Request.QueryString.ToString()
            : Context.Request.Path;

}
