using ExcellentLearningApp.Model.Domain;
using System.Collections.Generic;

namespace ExcellentLearningApp.Features.IssueManager.Models
{
    public class IssueManagerModel
    {
        public IssueManagerModel()
        {
            Issue = new IssueModel();
            Issues = new List<IssueModel>();
        }

        public IEnumerable<IssueModel> Issues { get; set; }
        public IssueModel Issue { get; set; }
    }
}
