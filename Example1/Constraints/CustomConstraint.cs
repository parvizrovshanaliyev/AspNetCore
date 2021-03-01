using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Example1.Constraints
{
    public class CustomConstraint : IRouteConstraint
    {
        #region Implementation of IRouteConstraint

        public bool Match(
            HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return true;
        }

        #endregion
    }
}
