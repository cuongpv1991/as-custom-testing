using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using EPiServer.Personalization;

namespace cms.Business.Customs
{
    /// <summary>
    /// refer: https://www.patrickvankleef.com/2015/06/07/using-dojo-when-creating-a-custom-visitor-group/
    /// </summary>
    public class CustomClientIPAddressResolver : IClientIPAddressResolver
    {
        public IPAddress ResolveAddress(HttpContextBase httpContext)
        {
            IPAddress pAddress;
            if (httpContext.Request.UserHostAddress.Equals("::1"))  // Website is running localhost so define hardcoded a valid IP address
            {
                return IPAddress.Parse("0.0.0.0");
            }
            else if (IPAddress.TryParse(httpContext.Request.UserHostAddress, out pAddress))
            {
                return pAddress;
            }
            return IPAddress.None;
        }
    }
}
