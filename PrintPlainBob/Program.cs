using Bells;
using System;

namespace PrintPlainBob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlainBobMajor method = new PlainBobMajor();
            MethodTracker tracker = new MethodTracker(method);
            MethodRinger ringer = new MethodRinger(new PrintLineStriker(), tracker);
            ringer.GapLengthMilliseconds = 0;
            ringer.RingMethod();
            Console.ReadLine();
        }
    }
}
