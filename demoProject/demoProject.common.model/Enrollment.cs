using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoProject.common.model
{
    public enum Grade
    {
        A, B, C, D, E
    }

    public class EnrollmentModel
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual CouresModel Course { get; set; }
        public virtual StudentModel Student { get; set; }
    }
}