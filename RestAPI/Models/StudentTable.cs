using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class StudentTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Driverid { get; set; }
    }
}
