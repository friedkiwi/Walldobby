using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            LightwaveRF.API.sendRaw(":202D4D,100,!F*p", 0);
            LightwaveRF.API.sendRaw(":202D4D,100,!F*p", 0);
            LightwaveRF.API.sendRaw(":202D4D,100,!F*p", 0);
        }
    }
}
