using NUnit.Framework;
using FlowerShop;
using NSubstitute;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //ARRANGE
            IOrderDAO od = Substitute.For<IOrderDAO>();
            IClient c = Substitute.For<IClient>();
            IOrder o = new Order(od, c);

            // ACT

            o.Deliver();

            //ASSERT
            od.Received().SetDelivered(Arg.Is(o));
        }
    }
}