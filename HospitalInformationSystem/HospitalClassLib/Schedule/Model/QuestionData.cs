using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class QuestionData
    {
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public QuestionData() {}
        public QuestionData(int ones, int twos, int threes, int fours, int fives)
        {
            this.Ones = ones;
            this.Twos = twos;
            this.Threes = threes;
            this.Fours = fours;
            this.Fives = fives;
        }
    }
}
