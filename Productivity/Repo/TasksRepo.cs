using Dapper;
using Productivity.Context;
using Productivity.Interface;
using Productivity.Models;

namespace Productivity.Repo
{
    //Implementation of the interface using Dapper
    public class TasksRepo : ITask
    {
        private readonly DapperContext _context;

        public TasksRepo(DapperContext ctx)
        {
            _context = ctx;
        }

        public async Task AddTask(Tasks task)
        {
            var q = "insert into task(todo, pending, date_day) values (@todo, @pending, @date_day)";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(q, task);
            }
        }

        public async Task<IEnumerable<TaskCount>> CountDoneTasks()
        {
            var q = "select count(*) as number, date_day from task where pending = 0 group by date_day;";
            using (var con = _context.CreateConnection())
            {
                var r = await con.QueryAsync<TaskCount>(q);
                return r.ToList();
            }
        }

        public async Task<IEnumerable<TaskCount>> CountPendingTasks()
        {
            var q = "select count(*) as number, date_day from task where pending = 1 group by date_day;";
            using (var con = _context.CreateConnection())
            {
                var r = await con.QueryAsync<TaskCount>(q);
                return r.ToList();
            }
        }

        public async Task<IEnumerable<TaskCount>> CountAllTasks()
        {
            var q = "select count(*) as number, date_day from task group by date_day;";
            using (var con = _context.CreateConnection())
            {
                var r = await con.QueryAsync<TaskCount>(q);
                return r.ToList();
            }
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            var q = "select * from task;";
            using (var con = _context.CreateConnection())
            {
                var l = await con.QueryAsync<Tasks>(q);
                return l.ToList();
            }
        }

        public async Task<IEnumerable<Tasks>> GetDoneTasks()
        {
            var q = "select * from task where pending = 0;";
            using (var con = _context.CreateConnection())
            {
                var l = await con.QueryAsync<Tasks>(q);
                return l.ToList();
            }
        }

        public async Task<IEnumerable<Tasks>> GetPendingTasks()
        {
            var q = "select * from task where pending = 1;";
            using (var con = _context.CreateConnection())
            {
                var l = await con.QueryAsync<Tasks>(q);
                return l.ToList();
            }
        }

        public async Task UpdateTask(int id)
        {
            var q = "update task set pending = 0 where id = @id;";
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(q, new { id });
            }
        }

        public async Task DeleteTask()
        {
            var q = "delete from task where pending = 0;";
            using ( var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(q);
            }
        }
    }
}
