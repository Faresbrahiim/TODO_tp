using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Todo_with_good_practice.Mappers;
using Todo_with_good_practice.Models;
using Todo_with_good_practice.ViewModels;

namespace Todo_with_good_practice.Services
{
    public class SessionTodoService : IsessionService
    {
        public void AddSession(ISession session, Todo todo)
        {
            var json = session.GetString("todos");
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

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void DeleteSessionById(ISession session, int todoId , string key)
        {

            var todos = GetSession<List<Todo>>(key, session);

            var todoToRemove = todos.FirstOrDefault(t => t.Id == todoId);
            if (todoToRemove != null)
            {
                todos.Remove(todoToRemove);
                session.SetString("todos", JsonConvert.SerializeObject(todos));
            }
        }


        public T GetTodoById<T>(ISession session, int todoId, string key)
        {
            var todos = GetSession<List<Todo>>(key, session);
            return (T)(object)todos.FirstOrDefault(t => t.Id == todoId);
        }
        public void SetSession<T>(ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public void EditSessionById(ISession session, Todo updatedTodo, string key)
        {
            var todos = GetSession<List<Todo>>(key, session);
            if (todos == null) return;
            var todo = todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
            if (todo != null)
            {
                TodoMapper.MapTodoToExisting(updatedTodo, todo);
                session.SetString(key, JsonConvert.SerializeObject(todos));
            }
        }
    }
}
