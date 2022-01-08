using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.Schedule.Model
{
    public class FeedbackProperties
    {
        public bool IsApproved { get; set; }
        public bool IsPublishable { get; set; }
        public bool IsAnonymous { get; set; }

        public FeedbackProperties() { }
        public FeedbackProperties(bool isApproved, bool isPublishable, bool isAnonymous)
        {
            IsApproved = isApproved;
            IsPublishable = isPublishable;
            IsAnonymous = isAnonymous;
        }
    }
}
