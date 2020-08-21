using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/


namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cup = await PourCoffee();
            Console.WriteLine("Coffee is ready");

            var eggs = FryEggs(2);
            var bacon = FryBacon(3);
            var toast = MakeBreadWithDressing(2);

            var allTasks = new List<Task> { eggs, bacon, toast };
            foreach (var tasks in allTasks)
            {
                Task finished = await Task.WhenAny(tasks);

                if (finished == eggs)
                {
                    Console.WriteLine("Eggs are ready");
                }
                else if (finished == bacon)
                {
                    Console.WriteLine("Bacon is ready");
                }
                else if (finished == toast)
                {
                    Console.WriteLine("toast is ready");
                }
            }
            var orange = await PourOJ();
            Console.WriteLine("Orange juice is ready");
            Console.WriteLine("Breakfast is ready!");

        }

        private static async Task<Toast> MakeBreadWithDressing(int slices)
        {
            var bread = await ToastBread(slices);
            ApplyButter(bread);
            ApplyJam(bread);

            return bread;
        }

        private static async Task<Juice> PourOJ()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Pouring orange juice");
            });
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);

            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static async Task<Coffee> PourCoffee()
        {
            await Task.Run(() => { 
                Console.WriteLine("Pouring coffee");
            });
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
