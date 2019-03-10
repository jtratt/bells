using Bells;
using PrintPlainBob;
using System;

namespace PlayPlainBobDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PlainBob method = new PlainBob(6);
            MethodTracker tracker = new MethodTracker(method);

            using (var striker = new Keyboard())
            {
                striker.BaseNote = 80;
                MethodRinger ringer = new MethodRinger(striker, tracker);
                ringer.RingMethod();
            }
            Console.ReadLine();
        }
    }
}
