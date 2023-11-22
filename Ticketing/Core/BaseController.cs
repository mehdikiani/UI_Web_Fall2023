using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ticketing.Core.Models;
using Ticketing.Core.Models;

namespace Ticketing.Core
{
    public class BaseController : Controller
    {
        //public
        //private
        //protected
        //internal
        //protected internal
        protected void AddMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            var msg = JsonConvert.SerializeObject(message);
            TempData["Message"] = msg;
        }
        protected void AddError(string content)
            => AddMessage(Message.Error(content));
        protected void AddWarning(string content)
           => AddMessage(Message.Warning(content));
        protected void AddSuccess(string content)
           => AddMessage(Message.Success(content));
        protected void AddInfo(string content)
           => AddMessage(Message.Info(content));
    }

}
