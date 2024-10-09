using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepeat.Models
{
    public class UserCustom : User
    {
        public bool IsCanseled { get; set; } = true;
    }
}
