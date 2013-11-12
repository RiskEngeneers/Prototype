using System;
using Moq;
using NUnit.Framework;
using RiskEngine.Contracts.Runtime;

namespace RiskEngine.Contracts.Tests.Runtime
{
    [TestFixture]
    public class ConditionEvaluatorIronPythonTests
    {
        private IConditionEvaluator _conditionEvaluator;
        private Mock<IWorkflowRuntime> _runtimeMock;

        [SetUp]
        public void SetupEvaluator()
        {
            _conditionEvaluator = new ConditionEvaluatorIronPython();
            _runtimeMock = new Mock<IWorkflowRuntime>();
            var testObject1 = new TestObject
            {
                Bool = true,
                Number = 1,
                Str = "A"
            };
            var testObject2 = new TestObject
            {
                Bool = false,
                Number = 2,
                Str = "B"
            };
            _runtimeMock.Setup(m => m.Input).Returns(testObject1);
            _runtimeMock.Setup(m => m.ProviderResults).Returns(new[]
            {
                new ProviderRuntimeResult
                {
                    ProviderName = "Provider1",
                    Result = testObject2,
                    ProviderStatus = EWorkflowProviderRuntimeStatus.Success
                }
            });
        }

        [Test]
        public void SuccesTest()
        {
            var result = _conditionEvaluator.Evaluate("input.Bool and input.Str == 'A' and input.Number == 1 and Provider1.Str == 'B'", _runtimeMock.Object);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void FailureTest()
        {
            var result = _conditionEvaluator.Evaluate("input.Bool and input.Number == 1 and input.Str == 'A' and Provider1.Bool;", _runtimeMock.Object);
            Assert.AreEqual(false, result);
        }

        [Test, Explicit]
        public void PerformanceEvaluate()
        {
            const int iterations = 100;
            var elapsed = PerformanceUtils.MeasureIterations(SuccesTest, iterations);
            Console.WriteLine("Total time {0} for {1} iterations single iteration ms: {2}", elapsed, iterations, elapsed.TotalMilliseconds/iterations);
        }
        
        public class TestObject
        {
            public string Str { get; set; }
            public int Number { get; set; }
            public bool Bool { get; set; }
        }
    }

}
