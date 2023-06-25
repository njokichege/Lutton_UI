using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FimiAppLibrary.Models
{
    public class ClassFormStreamModel:ClassModel
    {
        public int FormId { get; set; }
        public FormModel ClassForm { get; set; }
    }
}
