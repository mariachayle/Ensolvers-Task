using System;
using System.Linq;
using Ensolvers.Commands;
using Ensolvers.Models;
using Ensolvers.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[EnableCors("Todo")]
public class todoController : ControllerBase
{
    private readonly toDoListContext db = new toDoListContext();


    ///NEW TASK
    [HttpPost]
    [Route("Task/NewTask")]
    public ActionResult<APIresults> NewTask([FromBody] CreateTask command)
    {
        var result = new APIresults();
        if (command.Task.Equals(""))
        {
            result.Ok = false;
            result.Error = "Task is requiered";
            result.CodeError = 2;
            return result;
        }

        if (command.Done.Equals(""))
        {
            result.Ok = false;
            result.Error = "Done status is requiered";
            result.CodeError = 2;
            return result;
        }

        var ta = new Tasks();
        ta.Task = command.Task;
        ta.Done=command.Done;



        db.Tasks.Add(ta);
        db.SaveChanges();

        result.Ok = true;
        result.Return = db.Tasks.ToList();

        return result;
    }

    //LIST TASKS
    [HttpGet]
        [Route("Task/GetList")]
        public ActionResult<APIresults> GetList()
        {
            var result = new APIresults();
            try
            {
                result.Ok = true;
                result.Return = db.Tasks.ToList();
                result.MoreInfo = "List loaded";
                result.CodeError = 200; 
                return result;
            }
            catch (Exception ex)
            {
                result.Ok = false;
                result.Error = "Error" + ex.Message;
                result.CodeError = 400;
                return result;
            }
        }
 
    //EDIT TASK
    [HttpPost]
    [Route("Task/UpdateTask/{id}")]

    public ActionResult<APIresults> UpdateTasks([FromBody] UpdateTask command)
    {
        var result = new APIresults();

        if (command.Task.Equals(""))
        {
            result.Ok = false;
            result.Error = "Task is requiered";
            return result;
        }

         if (command.Done.Equals(""))
        {
            result.Ok = false;
            result.Error = "Done status is requiered";
            return result;
        }


        var t = db.Tasks.Where(c => c.Id == command.Id).FirstOrDefault();
        if (t != null)
        {
            t.Task = command.Task;
            t.Done= command.Done;
            db.Tasks.Update(t);
            db.SaveChanges();
        }
        result.Ok = true;
        result.Return = db.Tasks.ToList();

        return result;
    }

    //DELETE
    [HttpDelete]
    [Route("Task/Delete/{id}")]
    public ActionResult<APIresults> DeleteTask(int id)
    {
        var result = new APIresults();
        var t = db.Tasks.Where(c => c.Id == id).FirstOrDefault();
        db.Tasks.Remove(t);
        db.SaveChanges();

        result.Ok = true;
        result.Return = db.Tasks.ToList();
        return result;
    }
}




    




