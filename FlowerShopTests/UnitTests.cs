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

        [Test]
        public void Test2()
        {
            //ARRANGE
            IOrderDAO od = Substitute.For<IOrderDAO>();
            IClient c = Substitute.For<IClient>();
            IOrder o = new Order(od, c);
            IFlower first = Substitute.For<IFlower>();
            first.Cost.Returns(5.5);
            IFlower second = Substitute.For<IFlower>();
            second.Cost.Returns(8.2);
            o.AddFlowers(first, 3);
            o.AddFlowers(second, 6);

            //ACT
            double v = o.Price;

            //ASSERT
            Assert.That(v, Is.EqualTo((5.5 * 3 + 8.2 * 6) * 1.2));

        }
    }
}