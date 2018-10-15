


namespace WebApi2Book.Web.Api.Controllers.V2
{
    using System.Net.Http;
    using System.Web.Http;
    using WebApi2Book.Web.Api.MaintenanceProcessing;
    using WebApi2Book.Web.Api.Models;
    using WebApi2Book.Web.Common;

    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
        /// <summary>
        /// TaskController from V2
        /// </summary>
        /// <param name="addTaskMaintenanceProcessor"></param>
        public TasksController (IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
        }

        public IAddTaskMaintenanceProcessor AddTaskMaintenanceProcessor => _addTaskMaintenanceProcessor;


        //[Route("", Name = "AddTaskRouteV2")]
        //[HttpPost]
        //public Task AddTask(HttpRequestMessage requestMessage, Models.Task newTask)
        //{
        //    return new Task
        //    {
        //        Subject = "In v2, newTask.Subject = " + newTask.Subject
        //    };
        //}

        [Route("", Name = "AddTaskRouteV2")]
        [HttpPost]
        public IHttpActionResult AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            var task = AddTaskMaintenanceProcessor.AddTask(newTask);
            var result = new TaskCreatedActionResult(requestMessage, task);
            return result;
            
        }
    }
}
