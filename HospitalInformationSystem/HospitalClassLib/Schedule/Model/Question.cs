using HospitalClassLib.SharedModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class Question
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
        public QuestionCategory Category { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }

        public Question(int id) {}

        public Question() { }

        public Question(int id, string text, int value, QuestionCategory category) 
        {
            this.Id = id;
            this.Text = text;
            this.Value = value;
            this.Category = category;
        }

    }
}
