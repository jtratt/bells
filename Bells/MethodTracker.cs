namespace Bells
{
    public class MethodTracker
    {
        private int changeCount = 1;

        public IMethod Method { get; set; }

        public MethodTracker(IMethod method, int startingChangeOffset = 0)
        {
            this.Method = method;
            this.changeCount = changeCount + startingChangeOffset;
        }

        public void ApplyNextChange(Change currentChange)
        {
            currentChange.ApplyTransform(Method.GetTransform(changeCount));
            changeCount++;
        }

        public void ResetChangeCount()
        {
            this.changeCount = 0;
        }
    }
}
