using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Ticketing.Core.Models;

namespace Ticketing.Core
{
    public static class TempDataExtensions
    {
        public static Message GetMessage(this ITempDataDictionary tempData)
        {

            var msg = tempData["Message"]?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(msg))
                return null;
            try
            {
                return JsonConvert.DeserializeObject<Message>(msg);
            }
            catch
            {

                return null;
            }

        }
    }
}
