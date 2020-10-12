using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcellentLearningApp.Infrastructure.Extensions
{
    public static class ReflectionExtension
    {
        public static IEnumerable<PropNames> GetPropNames(this Type type) =>
            type.GetProperties().Select(p => new PropNames
            {
                Name = p.Name,
                DisplayName = p.IsDefined(typeof(System.ComponentModel.DisplayNameAttribute), false) ?
                    p.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute),false)
                        .Cast<System.ComponentModel.DisplayNameAttribute>().Single().DisplayName : 
                    null
            });
    }

    public class PropNames
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
