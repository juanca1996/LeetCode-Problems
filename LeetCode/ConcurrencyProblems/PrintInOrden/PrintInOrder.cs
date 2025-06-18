using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ConcurrencyProblems.PrintInOrden
{
    public class PrintInOrder
    {

        public async Task ExecuteMethods()
        {
            var fooclass = new Foo();

            await Task.Run(async () =>
            {
                fooclass.Third(() =>
                {
                    Console.WriteLine($"third");
                });
            });

            await Task.Run(() =>
            {
                fooclass.Second(() =>
                {
                    Console.WriteLine($"second");
                });
            });

            await Task.Run(async () =>
            {
                fooclass.First(() =>
                {
                    Console.WriteLine("firts");
                });
            });
            
         }


        internal class Foo
        {
            public ManualResetEventSlim slimEvent { get; set; }
            public ManualResetEventSlim secondslimEvent { get; set; }

            internal Foo()
            {
                slimEvent = new ManualResetEventSlim(false);
                secondslimEvent = new ManualResetEventSlim(false);
            }

            public void First(Action printFirst)
            {

                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                slimEvent.Set();
            }

            public void Second(Action printSecond)
            {
                slimEvent.Wait();
                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                secondslimEvent.Set();
            }

            public void Third(Action printThird)
            {
                secondslimEvent.Wait();
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
                
            }
        }
    }
}
