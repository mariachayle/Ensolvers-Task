using System;
using System.Collections.Generic;

#nullable disable

namespace Ensolvers.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool? Done { get; set; }
    }
}
