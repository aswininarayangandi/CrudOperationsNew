using Microsoft.OpenApi.Models;

namespace CrudOperations
{
    internal class ApiKeyScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
    }
}