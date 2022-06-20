using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using suneelkmfunapp1.Models;

namespace suneelkmfunapp1
{
    public static class Students
    {
        [FunctionName("GetStudents")]
        public static async Task<IActionResult> GetStudents(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(MyStudents());
        }

        [FunctionName("GetStudent")]
        public static IActionResult GetStudent(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route =null)] HttpRequest req, ILogger log)
        {
            try
            {
                int studentID = Int32.Parse(req.GetQueryParameterDictionary()["id"]?.ToString() ?? "0");
                return new OkObjectResult(MyStudents().Find(obj1 => obj1.ID == studentID));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public static List<Student> MyStudents()
        {
            List<Student> students;
            students = new List<Models.Student>();
            students.Add(new Student { ID = 1, Name = "Student1", Age = 9, Gender = 'F', Class = 4, Section = 'A' });
            students.Add(new Student { ID = 2, Name = "Student2", Age = 10, Gender = 'F', Class = 4, Section = 'A' });
            students.Add(new Student { ID = 3, Name = "Student3", Age = 22, Gender = 'M', Class = 4, Section = 'O' });
            students.Add(new Student { ID = 4, Name = "Student4", Age = 13, Gender = 'M', Class = 14, Section = 'B' });
            students.Add(new Student { ID = 5, Name = "Student5", Age = 43, Gender = 'M', Class = 5, Section = 'A' });
            students.Add(new Student { ID = 6, Name = "Student6", Age = 23, Gender = 'F', Class = 2, Section = 'C' });
            return students;
        }
    }
}
