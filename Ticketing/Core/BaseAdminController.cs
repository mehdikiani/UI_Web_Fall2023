using Microsoft.AspNetCore.Authorization;

namespace Ticketing.Core

{
    [Authorize]
    public class BaseAdminController :BaseController
    {

    }
}
