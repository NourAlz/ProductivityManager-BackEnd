using Productivity.Models;

namespace Productivity.Interface
{
    public interface ITask
    {
        /*
         * Methods needed for the application:
         * 
         * GET:
         * all tasks
         * pending
         * done
         * 
         * ADD:
         * a task
         * 
         * REMOVE:
         * all done tasks
         * 
         * NOTE that the updating task, meaning its done, so we just change the bit of pending to 0
         * 
         * DONE bit 0, PENDING bit 1
         */

        public Task<IEnumerable<Tasks>> GetAllTasks();
        public Task<IEnumerable<Tasks>> GetPendingTasks();
        public Task<IEnumerable<Tasks>> GetDoneTasks();
        public Task AddTask(Tasks task);
        public Task UpdateTask(int id);
        public Task<IEnumerable<TaskCount>> CountAllTasks();
        public Task<IEnumerable<TaskCount>> CountDoneTasks();
        public Task<IEnumerable<TaskCount>> CountPendingTasks();
        public Task DeleteTask();

    }
}
