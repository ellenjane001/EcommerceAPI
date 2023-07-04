using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EcommerceAPI.Data.Misc
{
    public class CustomHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            var authAttributes = context.MethodInfo
              .GetCustomAttributes(true)
              .OfType<AuthorizeAttribute>()
              .Distinct();

            if (authAttributes.Any())
            {
                var header = new OpenApiParameter
                {
                    Name = "x-user-id",
                    In = ParameterLocation.Header,
                    Description = "Enter User ID",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                };
                operation.Parameters.Add(header);
            }


        }
    }
}
