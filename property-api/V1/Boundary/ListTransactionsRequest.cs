

using System.ComponentModel.DataAnnotations;

namespace property_api.V1.Boundary
{
    public class ListTransactionsRequest
    {
        [Required] public string PropertyRef { get; set; }
    }
}
