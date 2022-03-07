using System;
using System.Collections.Generic;

#nullable disable

namespace Ensolvers.Commands
{
    public class UpdateTask
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool? Done { get; set; }
    }
}