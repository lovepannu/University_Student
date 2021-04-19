using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student.Models
{
    public class scholar
    {
        [Key]
        This is the primary key
        public int Id { get; set; }
         //This is the variable to store the student name
        public string student_Name { get; set; }
         //This is the variable to store the student email
        public string student_Email { get; set; }
         //This is the variable to store the student mobile
        public string student_Mobile { get; set; }
         //This is the variable to store the course name
        public string course_Name { get; set; }
    }
}
