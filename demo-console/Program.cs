using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace demo_console
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncJob().Wait();
        }

        #region 异步

        // 异步执行，耗时减少
        public static async Task AsyncJob()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("开始计时");
            var taskA = Task.Run(() => { DownLoadWebPage(); });
            var taskB = Task.Run(() => { LoadDatafromDB(); });
            await Task.WhenAll(taskA, taskB);
            Console.WriteLine("计时结束，总计耗时" + watch.ElapsedMilliseconds);
            Console.Read();
        }

        // 同步执行
        public static void SyncJob()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("开始计时");
            DownLoadWebPage();
            LoadDatafromDB();
            Console.WriteLine("计时结束，总计耗时" + watch.ElapsedMilliseconds);
            Console.Read();
        }

        public static void DownLoadWebPage()
        {
            Console.WriteLine("DownLoadWebPage on Thread:{0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("End downloading the page..");
        }

        public static void LoadDatafromDB()
        {
            Console.WriteLine("LoadDataFromDB on Thread:{0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            Console.WriteLine("End loading Data..");
        }

        #endregion
    }
}
