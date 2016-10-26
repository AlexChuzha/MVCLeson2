using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCLesson2.Filters
{
    public class OverrideFilterAttribute : FilterAttribute, IOverrideFilter
    {
        public Type FiltersToOverride
        {
            get { return typeof(IAuthorizationFilter); }
        }
    }
}