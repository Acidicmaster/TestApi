using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Infastructure;
using TestApi.Models;

namespace TestApi.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }


        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            var command = _context.Commands.FirstOrDefault(x => x.Id == Id);
            return command;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }
            _context.Commands.Add(command);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCommand(Command command)
        {
           // throw new NotImplementedException();
        }
    }
}
