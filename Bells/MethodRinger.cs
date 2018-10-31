using System.Threading;

namespace Bells
{
    public class MethodRinger
    {
        public IStrikeable Striker { get; set; }

        public MethodTracker Tracker { get; set; }

        public int GapLengthMilliseconds { get; set; } = 250;

        public bool IsOpenHandstroke { get; set; } = true;

        public bool IsHandstroke { get; private set; } = true;

        public MethodRinger(IStrikeable striker, MethodTracker tracker)
        {
            this.Striker = striker;
            this.Tracker = tracker;
        }

        public void RingMethod()
        {
            Change change = new Change(Tracker.Method.NumberOfBells);

            StrikeChange(change);
            StrikeChange(change);

            for (int i = 0; i < Tracker.Method.PlainCourseLength; i++)
            {
                Tracker.ApplyNextChange(change);
                StrikeChange(change);
            }
        }

        private void StrikeChange(Change change)
        {
            AddHandstrokeGap();

            for (int i = 0; i < change.Count; i++)
            {
                Striker.Strike(change[i]);
                Thread.Sleep(GapLengthMilliseconds);
            }
            
            IsHandstroke = !IsHandstroke;
        }

        /// <summary>
        /// Adds an additional gap length every 2 full changes.
        /// </summary>
        private void AddHandstrokeGap()
        {
            if (IsOpenHandstroke && IsHandstroke)
            {
                Thread.Sleep(GapLengthMilliseconds);
            }
        }
    }
}
