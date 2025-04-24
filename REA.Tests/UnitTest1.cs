using REA;
namespace REA.Tests {

    public class UnitTest1 {
        [Fact]
        public void Test1() {

            int a = 2;
            int b = 3;
            

            Assert.Equal(5, a + b);
        }
    }
}