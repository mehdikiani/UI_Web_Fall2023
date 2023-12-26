using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticketing
{
    public class DisableTestActionFilterAttribute
        :Attribute,IFilterMetadata
    {
    }
}
