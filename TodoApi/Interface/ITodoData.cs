using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface ITodoData
    {
         List<Todo> GetTodos();

         Todo GetTodo(int id);

         Todo AddTodo(Todo todo);

         void DeleteTodo(Todo todo);

         Todo EditTodo(Todo todo);


    }
}