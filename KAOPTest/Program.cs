using KAOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAOP objAop = new TestAOP();
            try
            {
                objAop.Test2(1024);
                objAop.Test3(1024);

            }
            catch
            {
            }
            Console.ReadLine();
        }
    }
    [Kiba]
    public class TestAOP : ContextBoundObject
    {
        public void Test1()
        {
            Console.WriteLine("I'm Test1");
        }
        public int Test2(int para)
        {
            Console.WriteLine("I'm Test2");
            return para * 2;
        }
        public int Test3(int para)
        {
            Console.WriteLine("I'm Test3");
            //Action a = null;
            //a.GetType();

            return para + 1;
        }
    }
}
