using System.ComponentModel.DataAnnotations;

namespace ExcellentLearningApp.Model.Entities
{
    public interface IIssue
    {
        public string OrignalText { get; set; }
        public string TranslatedText { get; set; }
    }
    public class Issue: Entity, IIssue
    {
        [Display(Name = "Awers")]
        public string OrignalText { get; set; }
        [Display(Name = "Rewers")]
        public string TranslatedText { get; set; }
    }
}
