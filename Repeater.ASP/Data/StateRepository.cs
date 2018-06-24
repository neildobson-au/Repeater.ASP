using System.Collections.Generic;
using System.Linq;
using Repeater.ASP.Models;

namespace Repeater.ASP.Data
{
    public class StateRepository : IRepository<State>
    {
        protected List<State> States;

        public StateRepository()
        {
            States = new List<State>();
        }

        public void Insert(State entity)
        {
            entity.StateId = States.Count > 0 ? States.Max(s => s.StateId) + 1 : 1;
            States.Add(entity);
        }

        public void Update(State entity)
        {
            var originalItem = GetById(entity.StateId);
            var index = States.IndexOf(originalItem);
            States[index] = entity;
        }

        public void DeleteById(int id)
        {
            States.Remove(GetById(id));
        }

        public IEnumerable<State> GetAll()
        {
            return States;
        }

        public State GetById(int id)
        {
            return States.Single(s => s.StateId == id);
        }
    }
}
