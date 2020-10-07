using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellentLearningApp.Infrastructure
{
    public class FeatureLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            // The old locations are /Views/{1}/{0}.cshtml and /Views/Shared/{0}.cshtml where {1} is the controller and {0} is the name of the View
            // Replace /Views with /Features

            var expandViewLocations = new List<string>
            {
                "/Features/{1}/Views/{0}/{0}.cshtml",
                "/Features/Shared/{0}.cshtml",
            };

            return expandViewLocations;
        }
    }
}
