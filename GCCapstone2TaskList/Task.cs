using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCCapstone2TaskList
{
    class Task
    {
        private string memberName;
        private string taskDesc;
        private string dueDate;
        private bool complete;
        

        

        
        public string MemberName { get { return memberName; } set { memberName = value; } }
        public string TaskDesc { get { return taskDesc; } set { taskDesc = value; } }
        public string DueDate { get { return dueDate; } set { dueDate = value; } }
        public bool Complete { get { return complete;  }  set { complete = value;  } }
        
        

        public Task(string name, string desc, string dateDue)
        {
            this.memberName = name;
            this.taskDesc = desc;
            this.dueDate = dateDue;
            
        }

    }
}
