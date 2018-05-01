using System;
using System.Collections.Generic;
using System.Text;

namespace Tecwi.BusinessLogic.Staff
{
    /// <summary>
    /// Is used in classes derived from SupervisorWorker to keep the worker's subordinates.  
    /// </summary>
    public class Subordinate
    {
        private SubordinationLevel level;
        private Worker worker;

        public SubordinationLevel Level { get => level;  }
        public Worker Worker { get => worker; }

        public Subordinate(SubordinationLevel sLevel, Worker sWorker)
        {
            level = sLevel;
            worker = sWorker;
        }

    }
}
