using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class SurvayObserveTests: IClassFixture<HospitalTestFactory<Startup>>
    {
        private readonly HospitalTestFactory<Startup> _factory;
        IServiceScope scope;
        MyDbContext context;
        public SurvayObserveTests(HospitalTestFactory<Startup> factory)
        {
            _factory = factory;
            scope = _factory.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        }
        [Fact]
        public void Average_question_value()
        {
            //Arange
            var questionService = new QuestionService(new QuestionRepository(context));

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
            var questionService = new QuestionService(new QuestionRepository(context));

            //Act
            var result = questionService.GetAvgCategoryValues();
            double[] expectedResult = { 1.3, 1.0, 1.7 };

            //Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
