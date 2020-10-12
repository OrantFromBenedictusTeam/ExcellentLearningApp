using ExcellentLearningApp.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace ExcellentLearningApp.Model.Domain
{
    public class IssueModel
    {
        public IssueModel() 
        {
            OrignalText = "";
            TranslatedText = "";
        }

        public IssueModel(IIssue issueEntity)
        {
            OrignalText = issueEntity.OrignalText;
            TranslatedText = issueEntity.TranslatedText;
        }

        [System.ComponentModel.DisplayName("Awers")]
        public string OrignalText { get; set; }
        public string TranslatedText { get; set; }
    }
}
