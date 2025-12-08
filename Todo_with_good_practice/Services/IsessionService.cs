using Todo_with_good_practice.Models;

namespace Todo_with_good_practice.Services
{
    public interface IsessionService
    {
        // did not make it object type -> problm of ID ....  , it's better to use object type here ? for reuseability
        public void AddSession(ISession session, Todo todo, string key);
        public T GetSession<T>(string key, ISession session);
        public void DeleteSessionById(ISession session, int todoId, string key);
        public T GetTodoById<T>(ISession session, int todoId, string key);
        public void SetSession<T>(ISession session, string key, T value);
        public void EditSessionById(ISession session, Todo updatedTodo, string key);

        ////////////////////  auth ///////////////////////
        public void AddUserToSession(ISession session, object obj, string key);
        public void RemoveSession(ISession session, string key);




    }
}
