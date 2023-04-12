using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoItems.Common
{
    public class ToDoItem
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string ItemType { get; set; } = "Shopping";
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpriryDate { get; set; } = DateTime.Now.AddDays(4);

        public override string ToString()
        {
            return $"Id: {id} , PartKey: {ItemType}, Name:{Name}"; 
        }
    }
}
