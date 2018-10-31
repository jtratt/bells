using Bells;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TransformTests
    {
        /// <summary>
        /// Apply the identity transform to rounds (12345678), expect rounds.
        /// </summary>
        [TestMethod]
        public void IdentityTransformTest()
        {
            Change rounds = new Change(8);
            Transform identity = Transform.Identity(8);
            rounds.ApplyTransform(identity);
            Assert.IsTrue(rounds.Equals(new Change(8)));
        }

        /// <summary>
        /// Apply the simple transform (2,1) to rounds, the reapply the transform to swap back.
        /// </summary>
        [TestMethod]
        public void SimpleTransformTest()
        {
            Change change = new Change(8);
            Transform transform = new Transform(new int[] { 2, 1 });

            change.ApplyTransform(transform);
            Assert.IsTrue(change[0] == 2 && change[1] == 1);

            change.ApplyTransform(transform);
            Assert.IsTrue(change[0] == 1 && change[1] == 2);
        }
    }
}
