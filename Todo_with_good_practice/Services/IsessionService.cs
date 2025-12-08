using Todo_with_good_practice.Models;

namespace Todo_with_good_practice.Services
{
    public interface IsessionService
    {
        public void AddSession(ISession session, Todo todo);
        public T GetSession<T>(string key, ISession session);
        public void DeleteSessionById(ISession session, int todoId, string key);
        public T GetTodoById<T>(ISession session, int todoId, string key);
        public void SetSession<T>(ISession session, string key, T value);
        public void EditSessionById(ISession session, Todo updatedTodo, string key);


    }
}
