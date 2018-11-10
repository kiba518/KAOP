using KAOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOPTest
{
    [Kiba]
    public class AOPTest : ContextBoundObject
    { 
        public string  KibaName { get; set; }

        public string Test(int para)
        {
            Console.WriteLine(para);
            return "数字为：" + para;
        }
    }
}
