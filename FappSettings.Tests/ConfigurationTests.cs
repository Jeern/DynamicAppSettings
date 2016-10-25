using NUnit.Framework;
using System;

namespace FappSettings.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Can_Load_StringAppSetting()
        {
            Assert.AreEqual("TestStringValue", AppSettings.ValueOf(a => a.TestString));
        }
        [Test]
        public void Can_Load_BoolAppSetting()
        {
            Assert.AreEqual(true, AppSettings<bool>.ValueOf(a => a.TestBool));
        }
        [Test]
        public void Can_Load_IntAppSetting()
        {
            Assert.AreEqual(7, AppSettings<int>.ValueOf(a => a.TestInt));
        }
        [Test]
        public void Can_Load_DoubleAppSetting()
        {
            Assert.AreEqual(6.7, AppSettings<double>.ValueOf(a => a.TestDouble));
        }
        [Test]
        public void Can_Load_FloatAppSetting()
        {
            Assert.AreEqual(7.6f, AppSettings<float>.ValueOf(a => a.TestFloat));
        }
        [Test]
        public void Can_Load_DecimalAppSetting()
        {
            Assert.AreEqual(5.60m, AppSettings<decimal>.ValueOf(a => a.TestDecimal));
        }
        [Test]
        public void Can_Load_DateTimeAppSetting()
        {
            Assert.AreEqual(new DateTime(2016, 8, 5), AppSettings<DateTime>.ValueOf(a => a.TestDateTime));
        }
        [Test]
        public void Can_Load_TimeSpanAppSetting()
        {
            Assert.AreEqual(new TimeSpan(10,7,30), AppSettings<TimeSpan>.ValueOf(a => a.TestTimeSpan));
        }
        [Test]
        public void Can_Load_Person()
        {
            Assert.AreEqual(new Person() { Name = "John", Age = 32 }, AppSettings<Person>.ValueOf(a => a.TestPerson));
        }
        [Test]
        public void Can_Load_TestEnum()
        {
            Assert.AreEqual(TestEnum.SecondValue, AppSettings<TestEnum>.ValueOf(a => a.TestEnum));
        }
    }
}
