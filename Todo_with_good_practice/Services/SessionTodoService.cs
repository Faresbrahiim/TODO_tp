using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;

namespace Todo_with_good_practice.Services
{
    public class SessionTodoService : IsessionService
    {
        // did not make it object type -> problm of IDentity  when deserializing.....
        public void AddSession(ISession session, Todo todo, string key)
        {
            var json = session.GetString(key);
            List<Todo> todos;
            if (json != null)
            {
                todos = JsonConvert.DeserializeObject<List<Todo>>(json);
            }
            else
            {
                todos = new List<Todo>();
            }
            // we did it here and not in controller to respect single responsibility principle
            todo.Id = todos.Count > 0 ? todos.Max(t => t.Id) + 1 : 1;
            todos.Add(todo);
            session.SetString("todos", JsonConvert.SerializeObject(todos));
        }

        public T GetSession<T>(string key, ISession session)
        {
            var json = session.GetString(key);
            // careful it can be null
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void DeleteSessionById(ISession session, int todoId, string key)
        {
            // get all todos from session
            var todos = GetSession<List<Todo>>(key, session);
            // find the todo to remove
            var todoToRemove = todos.FirstOrDefault(t => t.Id == todoId);
            if (todoToRemove != null)
            {
                // remove it from the list
                todos.Remove(todoToRemove);
                // update the session with the modified list
                session.SetString("todos", JsonConvert.SerializeObject(todos));
            }
        }


        public T GetTodoById<T>(ISession session, int todoId, string key)
        {
            var todos = GetSession<List<Todo>>(key, session);
            // return when match id
            return (T)(object)todos.FirstOrDefault(t => t.Id == todoId);
        }

        public void SetSession<T>(ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public void EditSessionById(ISession session, Todo updatedTodo, string key)
        {
            // get all todos from session
            var todos = GetSession<List<Todo>>(key, session);
            if (todos == null) return;
            // find the todo to update 
            // todo is reference type so when we modify it we modify the object in the list directly....
            var todo = todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
            if (todo != null)
            {
                // update its properties exept the id
                TodoMapper.MapTodoToExisting(updatedTodo, todo);
                session.SetString(key, JsonConvert.SerializeObject(todos));
            }
        }
        //////////////////////  auth ///////////////////////
  
        public void AddUserToSession(ISession session, object obj, string key)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj));
        }

        public void RemoveSession(ISession session, string key)
        {
            session.Remove(key);
        }

    }
}
