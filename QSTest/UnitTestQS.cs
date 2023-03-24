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
            var classtest = new
            {
                name="测试",
                age=18,

            };

            //Act 
            var info =qs.Stringify(classtest);

            Output.WriteLine("转换后的内容:" + info);

            //Assert
            //Debug.Assert(info);
            Assert.NotEmpty(info);
        }
    }
}