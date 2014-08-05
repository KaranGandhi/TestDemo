using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICompleteLearning.Models;

namespace WebAPICompleteLearning.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> list = new List<Employee>()
        {
            new Employee()
            {
                Id = 12345, FirstName = "John", LastName = "Human", Department = 2, Compensation = 45678.12M
            },

            new Employee()
            {
                Id = 12346, FirstName = "Jane", LastName = "Public", Department = 3
            },

            new Employee()
            {
                Id = 12347, FirstName = "Joseph", LastName = "Law", Department = 2
            }
        };

        //// GET api/employees

        //public IEnumerable<Employee> Get()
        //{
        //    return list;
        //}

        //// GET api/employees/12345

        //public Employee Get(int id)
        //{
        //    return list.First(e => e.Id == id);
        //}


        //public void Post(Employee employee)
        //{
        //    int maxId = list.Max(e => e.Id);
        //    employee.Id = maxId + 1;
        //    list.Add(employee);
        //}

        //// PUT api/employees/12345

        //public void Put(int id, Employee employee)
        //{
        //    int index = list.ToList().FindIndex(e => e.Id == id);
        //    list[index] = employee;
        //}

        //// DELETE api/employees/12345

        //public void Delete(int id)
        //{
        //    Employee employee = Get(id);
        //    list.Remove(employee);
        //}

        //[AcceptVerbs("GET")]
        //public Employee RetriveEmployeeByID(int id)
        //{
        //    return list.First(e => e.Id == id);
        //}

        //[HttpGet]
        //public Employee RetriveEmployeeByID(int id)
        //{
        //    return list.First(e => e.Id == id);
        //}

        //[HttpPut]
        //public void UpdateEmployee(int id, Employee employee)
        //{
        //    int index = list.ToList().FindIndex(e => e.Id == id);
        //    list[index] = employee;
        //}

        //RPC Style
        //[HttpGet]
        //public IEnumerable<Employee> RpcStyleGet()
        //{
        //    return list;
        //}
        //public Employee GetEmployeeRpcStyle(int id)
        //{
        //    return list.First(e => e.Id == id);
        //}

        //public Employee Get(int orgid, int id)
        //{
        //    return list.First(e => e.Id == id);
        //}

        //Handle Not found for not passing or wrong passing parameter
        //public Employee Get(int id)
        //{
        //    var employee = list.FirstOrDefault(e => e.Id == id);
        //    if (employee == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return employee;
        //}

        //[HttpGet]
        //public IEnumerable<Employee> Get([FromUri]Filter fileter)
        //{
        //    int[] validDepartments = { 1, 2, 3, 5, 8, 13 };
        //    int department = fileter.Department;
        //    if (!validDepartments.Any(d => d == department))
        //    {
        //        var response = new HttpResponseMessage()
        //        {
        //            StatusCode = (HttpStatusCode)422, // Unprocessable Entity
        //            ReasonPhrase = "Invalid Department"
        //        };
        //        throw new HttpResponseException(response);
        //    }
        //    return list.Where(e => e.Department == department);
        //}

        //public HttpResponseMessage Post(Employee employee)
        //{
        //    int maxId = list.Max(e => e.Id);
        //    employee.Id = maxId + 1;
        //    list.Add(employee);
        //    var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);
        //    string uri = Url.Link("DefaultApi", new { id = employee.Id });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        //public HttpResponseMessage Put(int id, Employee employee)
        //{
        //    if (!list.Any(e => e.Id == id))
        //    {
        //        list.Add(employee);
        //        var response = Request.CreateResponse<Employee>
        //        (HttpStatusCode.Created, employee);
        //        string uri = Url.Link("DefaultApi", new { id = employee.Id });
        //        response.Headers.Location = new Uri(uri);
        //        return response;
        //    }
        //    return Request.CreateResponse(HttpStatusCode.NoContent);
        //}

        //public HttpResponseMessage Put(int id, Employee employee)
        //{
        //    int index = list.ToList().FindIndex(e => e.Id == id);
        //    if (index >= 0)
        //    {
        //        list[index] = employee; // overwrite the existing resource
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    else
        //    {
        //        list.Add(employee);
        //        var response = Request.CreateResponse<Employee>
        //        (HttpStatusCode.Created, employee);
        //        string uri = Url.Link("DefaultApi", new { id = employee.Id });
        //        response.Headers.Location = new Uri(uri);
        //        return response;
        //    }
        //}

        //public HttpResponseMessage Patch(int id, Delta<Employee> deltaEmployee)
        //{
        //    var employee = list.FirstOrDefault(e => e.Id == id);
        //    if (employee == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    deltaEmployee.Patch(employee);
        //    return Request.CreateResponse(HttpStatusCode.NoContent);
        //}

        //public HttpResponseMessage Get()
        //{
        //    var values = list.Select(e => new
        //    {
        //        Identifier = e.Id,
        //        Name = e.FirstName + " " + e.LastName
        //    });
        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ObjectContent(values.GetType(),
        //        values,
        //        Configuration.Formatters.JsonFormatter)
        //    };
        //    return response;
        //}

        public Employee Get(int id)
        {
            var employee = list.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound,
                new HttpError(Resources.Messages.NotFound));
                throw new HttpResponseException(response);
            }
            return employee;
        }
    }
}
