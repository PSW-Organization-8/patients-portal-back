using HospitalAPI.Dto;
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
        private readonly SurveyRepository surveyRepository;
        private readonly QuestionService questionService;
        public SurveyController(SurveyService surveyService, SurveyRepository surveyRepository, QuestionService questionService, PatientService patientService)
        {
            this.surveyService = surveyService;
            this.surveyRepository = surveyRepository;
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
            List<Question> questions = new List<Question>();
            Survey survey = new Survey(patientService.Get(dto.PatientId));
            surveyService.Create(survey);

            foreach (Question q in dto.Questions) {
                q.SurveyId = survey.Id;
                questions.Add(q);
                questionService.CreateQuestion(q);
            }

            return Ok();//(surveyService.Create(dto));
        }
    }
}
