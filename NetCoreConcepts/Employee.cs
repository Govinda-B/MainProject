using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreConcepts
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Id")]
        public EmployeeDetail EmployeeDetail { get; set; }
    }

    [Table("Employee")]
    public class EmployeeDetail
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateNumber { get; set; }
        public Employee Employee { get; set; }
    }
}
