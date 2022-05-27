using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinetApp.Models
{
    public abstract class Document
    {
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
