using Comparator;

namespace SampleProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAreEqual()
        {
            Compare comparator = new();
            Assert.IsTrue(comparator.AreEqual(1, 1));
        }
    }
}