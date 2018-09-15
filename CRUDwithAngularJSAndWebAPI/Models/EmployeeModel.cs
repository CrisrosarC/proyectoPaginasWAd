using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CRUDwithAngularJSAndWebAPI.Models
{
    [Table("Employees")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="First Name Required")]
        [StringLength(maximumLength:20, MinimumLength =3, ErrorMessage ="Name should be between 3 to 20 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public DateTime DOB { get; set; }
		
		//relacional
		public DepartmentModel DepartmentID { get; set; }
	}

	[Table("Department")]
	public class DepartmentModel
	{
		[Key]
		public int DepartmentID { get; set; }

		[Required(ErrorMessage = "Departament Required")]
		[StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Name should be between 3 to 20 characters")]
		public string DepartmentName { get; set; }


	}

}