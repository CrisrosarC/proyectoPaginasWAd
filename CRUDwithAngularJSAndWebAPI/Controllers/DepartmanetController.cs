using CRUDwithAngularJSAndWebAPI.Models;
using CRUDwithAngularJSAndWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static CRUDwithAngularJSAndWebAPI.Models.EmployeeModel;

namespace CRUDwithAngularJSAndWebAPI.Controllers
{
    public class DepartmanetController : ApiController
    {

	
		DataAccessContext context = new DataAccessContext();

		//Get All department
		[HttpGet]
		public IEnumerable<EmployeeViewModel> GetAllDeparment()
		{

			var data = context.Department.ToList().OrderBy(x => x.DepartmentName);
			var result = data.Select(x => new EmployeeViewModel()
			{
				DepartmentID = x.DepartmentID,
				DepartmentName = x.DepartmentName
				
			});
			return result.ToList();
		}


		//Get the single department data
		[HttpGet]
		public EmployeeViewModel GetDeparment(int Id)
		{
			var data = context.Department.Where(x => x.DepartmentID == Id).FirstOrDefault();
			if (data != null)
			{
				EmployeeViewModel Department = new EmployeeViewModel();
				Department.DepartmentID = data.DepartmentID;
				Department.DepartmentName = data.DepartmentName;
				

				return Department;
			}
			else
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}
		}

		//Add new deparment

		[HttpPost]
		public HttpResponseMessage AddDeparment(EmployeeViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					DepartmentModel emp = new DepartmentModel();
					emp.DepartmentID = model.DepartmentID;
					emp.DepartmentName = model.DepartmentName;
					

					context.Department.Add(emp);
					var result = context.SaveChanges();
					if (result > 0)
					{
						return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
					}
					else
					{
						return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
					}
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
				}
			}
			catch (Exception ex)
			{

				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
			}
		}

		//Update the DEPARTMENT

		[HttpPut]
		public HttpResponseMessage UpdateDeparment(EmployeeViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					DepartmentModel emp = new DepartmentModel();
					emp.DepartmentID = model.DepartmentID;
					emp.DepartmentName = model.DepartmentName;


					context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
					var result = context.SaveChanges();
					if (result > 0)
					{
						return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
					}
					else
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
					}
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
				}
			}
			catch (Exception ex)
			{

				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
			}
		}

		//Delete the employee

		[HttpDelete]
		public HttpResponseMessage DeleteDeparment(int Id)
		{
			DepartmentModel emp = new DepartmentModel();
			emp = context.Department.Find(Id);
			if (emp != null)
			{
				context.Department.Remove(emp);
				context.SaveChanges();
				return Request.CreateResponse(HttpStatusCode.OK, emp);
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
			}
		}


	}
}
