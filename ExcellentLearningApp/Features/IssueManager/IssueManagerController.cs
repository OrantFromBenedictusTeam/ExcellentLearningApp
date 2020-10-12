using ExcellentLearningApp.Features.IssueManager.Models;
using ExcellentLearningApp.Model.Entities;
using ExcellentLearningApp.Model.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ExcellentLearningApp.Features.IssueManager
{
    public class IssueManagerController : Controller
    {
        private readonly IRepository<Issue> _repository;

        public IssueManagerController(IRepository<Issue> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_repository.GetAll().Any())
            {
                _repository.Create(new Issue { Date = DateTime.Now, OrignalText = "Orginał", TranslatedText = "Tłumaczenie"});
            }
            
            return View(new IssueManagerModel
            {
                Issues = _repository.GetAll().Select(issue => new Model.Domain.IssueModel(issue))
            });
        }


    }
}
