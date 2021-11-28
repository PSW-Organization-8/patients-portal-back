using HospitalAPI.Controllers;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    
    public class QuestionTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Question_value_between_one_and_five(Question question, int code)
        {
            var questionController = new QuestionController(new QuestionService(CreateStudRepository()));

            var result = questionController.AddQuestion(question);
            var okResult = result as ObjectResult;

            Assert.Equal(code, okResult.StatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new Question(2, "Pitanje 1", 4, QuestionCategory.doctor), 200 },
            new object[] { new Question(2, "Pitanje 1", 7, QuestionCategory.doctor), 400 }
        };

        private static IQuestionRepository CreateStudRepository()
        {
            var stubRepository = new Mock<IQuestionRepository>();
            var questions = new List<Question>();
            Question question1 = new Question(1, "Pitanje 1", 2, QuestionCategory.doctor);
            Question question2 = new Question(2, "Pitanje 1", 3, QuestionCategory.doctor);
            Question question3 = new Question(3, "Pitanje 1", 1, QuestionCategory.hospital);
            Question question4 = new Question(4, "Pitanje 1", 2, QuestionCategory.hospital);
            Question question5 = new Question(5, "Pitanje 1", 5, QuestionCategory.medicalStuff);
            Question question6 = new Question(6, "Pitanje 1", 1, QuestionCategory.medicalStuff);
            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);
            questions.Add(question4);
            questions.Add(question5);
            questions.Add(question6);

            stubRepository.Setup(q => q.GetAll()).Returns(questions);
            stubRepository.Setup(q => q.Create(question1)).Returns(question1);

            return stubRepository.Object;
        }

    }
}
