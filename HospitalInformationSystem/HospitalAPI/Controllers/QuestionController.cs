using HospitalAPI.Validators;
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

    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService questionService;
        private readonly QuestionValidator validator = new();
        public QuestionController(QuestionService questionService)
        {
            this.questionService = questionService;
        }



        [HttpGet("{id?}")]
        public IActionResult GetQuestion(int id)
        {
            return Ok(questionService.Get(id));
        }

        [HttpPost]
        public IActionResult AddQuestion(Question question)
        {
            if (validator.Validate(question).IsValid)
            {
                questionService.Create(question);
                return Ok(question);
            }
            else return BadRequest(question);
        }

        [HttpGet]
        [Route("byQuestion")]
        public IActionResult GetAvgQuestionValues()
        {
            return Ok(questionService.GetAvgQuestionValues());
        }

        [HttpGet]
        [Route("byCategory")]
        public IActionResult GetAvgCategoryValues()
        {
            return Ok(questionService.GetAvgCategoryValues());
        }


        [HttpGet]
        [Route("questionData")]
        public IActionResult GetQuestionData()
        {
            return Ok(questionService.GetQuestionData());
        }

        [HttpGet]
        [Route("categoryData")]
        public IActionResult GetCategoryData()
        {
            return Ok(questionService.GetCategoryData());
        }

    }
}
