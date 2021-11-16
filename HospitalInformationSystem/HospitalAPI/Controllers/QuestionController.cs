using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService questionService;
        private readonly QuestionRepository questionRepository;
        public QuestionController(QuestionService questionService, QuestionRepository questionRepository)
        {
            this.questionService = questionService;
            this.questionRepository = questionRepository;
        }



        [HttpGet("{id?}")]
        public IActionResult GetSurvey(int id)
        {
            return Ok(questionService.Get(id));
        }

        [HttpPost]
        public IActionResult AddSurvey(Question question)
        {
            return Ok(questionService.Create(question));
        }

    }
}
