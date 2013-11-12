using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using RiskEngine.Contracts.Definition;
using RiskEngine.Contracts.Runtime;

namespace RiskEngine.Contracts.Tests.Runtime
{
    [TestFixture]
    public class ProviderSchedulerTests
    {
        private DataProviderScheduler _scheduler;

        [Test, Explicit]
        public void TestMulithreading()
        {
            const int callCount = 100;
            _scheduler = new DataProviderScheduler();
            var dataProviderAsync = new WebDataProviderAsync();
            var dataProvider = new WebDataProvider();
            Console.WriteLine("Async data provider: {0}",  MeasureScheduled(() => _scheduler.Schedule(dataProviderAsync, ""), callCount));
            Console.WriteLine("Blocking data provider: {0}", MeasureScheduled(() => _scheduler.Schedule(dataProvider, ""), callCount));
            Console.WriteLine("Sequential async data provider: {0}", MeasureSequential(() =>
            {
                var task = dataProviderAsync.ProvideData("");
                task.Wait();
            }, callCount));
            Console.WriteLine("Sequential blocking data provider: {0}", MeasureSequential(() => dataProvider.ProvideData(""), callCount));

        }

        private TimeSpan MeasureScheduled(Action action, int callCount)
        {
            var stopwatch = new Stopwatch();
            int completed = 0;
            stopwatch.Start();
            _scheduler.DataReceived += (s, e) => completed++;
            for (int i = 0; i < callCount; i++)
                action();
            while (completed < callCount)
                Thread.Sleep(10);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        private TimeSpan MeasureSequential(Action action,int callCount)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < callCount; i++)
                action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        class TestDataProviderAsync : DataProviderBaseAsync<string, string>
        {
            public override string Name
            {
                get { return "TestDataProviderAsync"; }
            }
            public async override Task<string> ProvideData(string input)
            {
                await Task.Delay(1000);
                return "";
            }
        }

        class WebDataProviderAsync : DataProviderBaseAsync<string, string>
        {
            public override string Name
            {
                get { return "WebDataProviderAsync"; }
            }
            public override Task<string> ProvideData(string input)
            {
                using (var client = new WebClient())
                {
                    return client.DownloadStringTaskAsync("http://www.yahoo.com/");
                }
            }
        }

        class TestDataProvider : DataProviderBase<string, string>
        {
            public override string Name
            {
                get { return "TestDataProvider"; }
            }
            public override string ProvideData(string input)
            {
                Thread.Sleep(1000);
                return "";
            }
        }

        class WebDataProvider : DataProviderBase<string, string>
        {
            public override string Name
            {
                get { return "WebDataProvider"; }
            }
            public override string ProvideData(string input)
            {
                using (var client = new WebClient())
                {
                    var webResult = client.DownloadString("http://www.yahoo.com/");
                    return webResult;
                }
            }
        }
    }
}
