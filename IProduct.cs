using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_12
{
    public interface IProduct
    {
        int ID {  get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Category {  get; set; }

    }
}
