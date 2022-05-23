using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class DbData : ITodoData
    {
        private readonly DataContext dataContext;

        public DbData(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Todo AddTodo(Todo todo)
        {
            dataContext.Todos.Add(todo);
            dataContext.SaveChanges();
            return todo;
        }

        public void DeleteTodo(Todo todo)
        {
            dataContext.Todos.Remove(todo);
            dataContext.SaveChanges();
        }

        public Todo EditTodo(Todo todo)
        {
            var existingTodo = dataContext.Todos.Find(todo.Id);
            if(existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.Body = todo.Body;
                dataContext.Todos.Update(existingTodo);
                dataContext.SaveChanges();
            }
            return todo;

        }

        public Todo GetTodo(int id)
        {
            return dataContext.Todos.SingleOrDefault(x => x.Id == id);
        }

        public List<Todo> GetTodos()
        {
            return dataContext.Todos.ToList();
        }
    }
}