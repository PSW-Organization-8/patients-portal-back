using HospitalAPI.Controllers;
using HospitalAPI.Dto;
using HospitalClassLib;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Repository.SurveyRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class SurveyTests
    {
        [Fact]
        public void Create_new_survey()
        {
            //Arange
            var db = new MyDbContext();
            var surveyController = new SurveyController(new SurveyService(new SurveyRepository(db)), new QuestionService(new QuestionRepository(db)), 
                new PatientService(new PatientRepository(db)));
            var question1 = new Question(1, "TEST", 2, QuestionCategory.doctor);
            var question2 = new Question(2, "TEST", 2, QuestionCategory.doctor);
            List<Question> questionList = new List<Question>();
            questionList.Add(question1);
            questionList.Add(question2);
            var surveyDto = new SurveyDto(1, questionList);

            //Act
            var result = surveyController.AddSurvey(surveyDto);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
