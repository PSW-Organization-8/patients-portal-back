using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class SurvayObserveTests
    {
        [Fact]
        public void Average_question_value()
        {
            //Arange
            var questionService = new QuestionService(new QuestionRepository(new MyDbContext()));

            //Act
            var result = questionService.GetAvgQuestionValues();
            double[] expectedResult = { 1.0, 2.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 4.5 };

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void Average_category_value()
        {
            //Arange
            var questionService = new QuestionService(new QuestionRepository(new MyDbContext()));

            //Act
            var result = questionService.GetAvgCategoryValues();
            double[] expectedResult = { 1.3, 1.0, 1.7 };

            //Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
