using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib.SharedModel
{

    
    public class Shift
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public String ShiftType { get; set; }
        public String ShiftStart { get; set; }
        public String ShiftEnd { get; set; }

    }
}
