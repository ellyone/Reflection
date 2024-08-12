using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class F
    {
        [JsonProperty]
        int i1, i2, i3, i4, i5; 
        public F Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

        public override string ToString()
        {
            return string.Format("i1 = {0},\ni2 = {1},\ni3 = {2},\ni4= {3},\ni5 = {4}", i1, i2, i3, i4, i5);
        }
    }
}
