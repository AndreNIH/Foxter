using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Utils
{
    public class ListToString<T>
    {
        
        public static string Convert(List<T> list)
        {
            string res = "";
            list.ForEach(e => { res += $"{{{e.ToString()}}},"; } );
            if (res.Length != 0) res = res.Remove(res.Length - 1);
            return res;
        }
    }
}
