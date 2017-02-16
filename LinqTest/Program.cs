using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new[] {
                new { Age = 25, Salary = 250 },
                new { Age = 25, Salary = 820 },
                new { Age = 32, Salary = 650 },
                new { Age = 40, Salary = 550 },
                new { Age = 65, Salary = 1050 },
                new { Age = 63, Salary = 950 },
            };

            var results = employees
                .GroupBy(e => (e.Age / 10) * 10) // 年代ごとにグルーピング
                .Select(x => new { Age = x.Key, MaxSalary = x.Max(y => y.Salary) }) // 年代ごとの最高の給料 Salary を抽出
                ;

            foreach (var result in results)
            {
                Console.WriteLine($"{result.Age}代の最高給料は{result.MaxSalary}万円です");
            }

            // 何かキーが押されるまでプログラムが終了しない
            Console.ReadKey();
        }
    }
}
