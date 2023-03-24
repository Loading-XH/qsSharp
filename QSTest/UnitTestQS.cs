using QueryString;
using System.Diagnostics;
using System.Text;
using Xunit.Abstractions;

namespace QSTest
{
    public class UnitTestQS
    {
        public ITestOutputHelper Output { get; }
        private QueryString.QS qs = new QS();
        public UnitTestQS(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public async Task TtoString()
        {
            //Arrange
            var classtest = new Person();

            //Act 
            var info =qs.Stringify(classtest);

            Output.WriteLine("转换后的内容:" + info);

            //Assert
            //Debug.Assert(info);
            Assert.NotEmpty(info);
        }
        private class Person
        {
            public string name { get; set; } = "测试";
            public int age { get; set; } = 18;
            public string sex { get; set; } = "女";
        }
    }
}