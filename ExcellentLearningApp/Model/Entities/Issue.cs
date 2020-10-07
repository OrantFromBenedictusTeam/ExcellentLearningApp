using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellentLearningApp.Model.Entities
{
    public class Issue: Entity
    {
        public string OrignalText { get; set; }
        public string TranslatedText { get; set; }
    }
}
