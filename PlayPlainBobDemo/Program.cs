using Bells;
using PrintPlainBob;
using System;

namespace PlayPlainBobDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PlainBob method = new PlainBob(4);
            MethodTracker tracker = new MethodTracker(method);

            using (var striker = new Keyboard())
            {
                MethodRinger ringer = new MethodRinger(striker, tracker);
                ringer.RingMethod();
            }
            Console.ReadLine();
        }
    }
}
