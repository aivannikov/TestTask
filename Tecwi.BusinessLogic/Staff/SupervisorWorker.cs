using System;
using System.Collections.Generic;
using System.Linq;

namespace Tecwi.BusinessLogic.Staff
{
    public abstract class SupervisorWorker : Worker
    {

        private List<Subordinate> subordinates;
     

        public SupervisorWorker(string wName, DateTime wStartDate) : base(wName, wStartDate)
        {
            subordinates = new List<Subordinate>();
        }

        
        public IList<Subordinate> Subordinates
        {
            get
            {                
                return subordinates;
            }
        }

        public void AddSubordinate(Subordinate subordinate)
        {
            subordinates.Add(subordinate);
        }
        public void AddSubordinates(IEnumerable<Subordinate> subordinatesList)
        {
            subordinates.AddRange(subordinatesList);
        }

        public void RemoveSubordinate(Subordinate subordinate)
        {
            subordinates.Remove(subordinate);
        }

       
        public void RemoveSubordinate(Predicate<Subordinate> predicate)
        {
            var subordinatesToRemove = subordinates.FindAll(predicate);
            foreach(var subordinate in subordinatesToRemove)
            {
                RemoveSubordinate(subordinate);
            }
        }

        public void RemoveAllSubordinates()
        {
            subordinates.Clear();
        }


    }
}
