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
            Assert.AreEqual(AppSettings.ValueOf(a => a.TestString), "TestStringValue");
        }
        [Test]
        public void Can_Load_BoolAppSetting()
        {
            Assert.AreEqual(AppSettings<bool>.ValueOf(a => a.TestBool), true);
        }
        [Test]
        public void Can_Load_IntAppSetting()
        {
            Assert.AreEqual(AppSettings<int>.ValueOf(a => a.TestInt), 7);
        }
        [Test]
        public void Can_Load_DoubleAppSetting()
        {
            Assert.AreEqual(AppSettings<double>.ValueOf(a => a.TestDouble), 6.7);
        }
        [Test]
        public void Can_Load_FloatAppSetting()
        {
            Assert.AreEqual(AppSettings<float>.ValueOf(a => a.TestFloat), 7.6f);
        }
        [Test]
        public void Can_Load_DecimalAppSetting()
        {
            Assert.AreEqual(AppSettings<decimal>.ValueOf(a => a.TestDecimal), 5.60);
        }
        [Test]
        public void Can_Load_DateTimeAppSetting()
        {
            Assert.AreEqual(AppSettings<DateTime>.ValueOf(a => a.TestDateTime), new DateTime(2016, 8, 5));
        }
        [Test]
        public void Can_Load_TimeSpanAppSetting()
        {
            Assert.AreEqual(AppSettings<TimeSpan>.ValueOf(a => a.TestTimeSpan), new TimeSpan(10,7,30));
        }
        [Test]
        public void Can_Load_Person()
        {
            Assert.AreEqual(AppSettings.ValueOf<Person>(a => a.TestPerson), new Person("John", 32));
        }
    }
}
