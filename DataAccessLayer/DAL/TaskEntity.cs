using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Model
{
    public class TaskEntity
    {
        public const string CT_TASK_TYPE_HANGFIRE = "HF";
        public const string CT_TASK_TYPE_QUARTZ = "QA";


        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string TaskType { get; set; }
        public DateTime ExecutionDT { get; set; }
        public string Details { get; set; }
        public string Worker { get; set; }
    }
}
