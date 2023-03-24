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
                name="����",
                age=18,

            };

            //Act 
            var info =qs.Stringify(classtest);

            Output.WriteLine("ת���������:" + info);

            //Assert
            //Debug.Assert(info);
            Assert.NotEmpty(info);
        }
    }
}