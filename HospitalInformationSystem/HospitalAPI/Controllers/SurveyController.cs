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
    public class SurveyController : ControllerBase
    {
        private readonly SurveyService surveyService;
        private readonly SurveyRepository surveyRepository;
        public SurveyController(SurveyService surveyService, SurveyRepository surveyRepository)
        {
            this.surveyService = surveyService;
            this.surveyRepository = surveyRepository;
        }



        [HttpGet("{id?}")]
        public IActionResult GetSurvey(int id)
        {
            return Ok(surveyService.Get(id));
        }

        [HttpPost]
        public IActionResult AddSurvey(Survey survey)
        {
            return Ok(surveyService.Create(survey));
        }
    }
}
