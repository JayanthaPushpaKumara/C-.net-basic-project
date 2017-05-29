using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoProject.common.model
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EnrollmentModel> Enrollments { get; set; } //map primary key foring key 
    }
}