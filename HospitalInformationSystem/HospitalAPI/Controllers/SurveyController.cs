using HospitalAPI.Dto;
using HospitalAPI.Validators;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.SurveyRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly SurveyService surveyService;
        private readonly PatientService patientService;
        private readonly QuestionService questionService;
        private readonly SurveyValidator validator = new();
        public SurveyController(SurveyService surveyService, QuestionService questionService, PatientService patientService)
        {
            this.surveyService = surveyService;
            this.questionService = questionService;
            this.patientService = patientService;
        }

        [HttpGet("{id?}")]
        public IActionResult GetSurvey(int id)
        {
            return Ok(surveyService.Get(id));
        }

        [HttpPost]
        public IActionResult AddSurvey(SurveyDto dto)
        {
            if (validator.Validate(dto).IsValid) 
            {
                Survey survey = new Survey(patientService.Get(dto.PatientId));
                surveyService.Create(survey);
                questionService.CreateMultipleQuestions(survey.Id, dto.Questions);
                return Ok(survey);
            }
            return BadRequest();
        }
    }
}
