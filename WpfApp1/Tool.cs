using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace WpfApp1
{
    public class Tool
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
       
        public Tool()
        {
            Name = "";
            Description = "";
            Price = 0;
            Quantity = 0;
        }
    }
}
