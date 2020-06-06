using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Buoi08.Models
{
    public class Demo
    {
        public string Test01()
        {
            Thread.Sleep(3000);
            return "Nhất Nghệ";
        }

        public int Test02()
        {
            Thread.Sleep(5000);
            return new Random().Next(10000);
        }

        public void Test03()
        {
            Thread.Sleep(2000);
        }

        public async Task<string> Test01Async()
        {
            await Task.Delay(2000);
            return "Nhất Nghệ";
        }

        public async Task<int> Test02Async()
        {
            await Task.Delay(5000);
            return new Random().Next(10000);
        }

        public async Task Test03Async()
        {
            await Task.Delay(3000);
        }
    }
}
