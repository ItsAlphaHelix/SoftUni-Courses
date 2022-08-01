
namespace TeisterMask.Data.Models
{
    using System;
    public class EmployeeTask
    {
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
