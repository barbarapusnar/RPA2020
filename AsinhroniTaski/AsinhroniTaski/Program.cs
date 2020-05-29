using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsinhroniTaski
{
    class Coffee
    { }  
    class Egg { } 
    class Bacon { }  
    class Toast { }
    class Juice { }
    class Program
    {    //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            //sinhrono
            //Coffee cup = PourCoffee();
            //Console.WriteLine("kava je pripravljena");
            //Egg eggs = FryEggs(2);
            //Console.WriteLine("jajca so cvrta");
            //Bacon bacon = FryBacon(3);
            //Console.WriteLine("slanina je cvrta");
            //Toast toast = ToastBread(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast je pečen");
            //Juice oj = PourOJ();
            //Console.WriteLine("sok je pripravljen");
            //Console.WriteLine("Zajtrk je pripravljen!");

            //1. asinhrono -nič ne spremenim
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Egg eggs = await FryEggsAsync(2);
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = await FryBaconAsync(3);
            //Console.WriteLine("bacon is ready");
            //Toast toast = await ToastBreadAsync(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");

            //Console.WriteLine("Breakfast is ready!");

            //2. asinhrono
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Task<Egg> eggsTask = FryEggsAsync(2);//shranimo opravilo, namesto, da ga čakamo
            //Task<Bacon> baconTask = FryBaconAsync(3);
            //Task<Toast> toastTask = ToastBreadAsync(2);
            //Toast toast = await toastTask;//tukaj počakamo, da konča
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Egg eggs = await eggsTask;
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = await baconTask;
            //Console.WriteLine("bacon is ready");
            //Console.WriteLine("Breakfast is ready!");

            //3. asinhrono - združi izdelavo toastov
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //var eggsTask = FryEggsAsync(2);
            //var baconTask = FryBaconAsync(3);
            //var toastTask = MakeToastWithButterAndJamAsync(2);
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //await Task.WhenAll(eggsTask, baconTask, toastTask);
            //Console.WriteLine("eggs are ready");
            //Console.WriteLine("bacon is ready");
            //Console.WriteLine("toast is ready");
            //Console.WriteLine("Breakfast is ready!");

            //4. asinhrono - združi taske, en klic
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //var eggsTask = FryEggsAsync(2);
            //var baconTask = FryBaconAsync(3);
            //var toastTask = MakeToastWithButterAndJamAsync(2);
            //await Task.WhenAll(eggsTask, baconTask, toastTask);
            //Console.WriteLine("eggs are ready");
            //Console.WriteLine("bacon is ready");
            //Console.WriteLine("toast is ready");
            //Console.WriteLine("Breakfast is ready!");

            //5. WhenAny
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Count > 0)
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finished == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                allTasks.Remove(finished);
            }
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");


            Console.ReadLine();
        }
        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Stiskanje soka iz pomaranč");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Dodajanje džema na toast");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Dodajanje masla na toast");

     // private static Toast ToastBread(int slices)
            private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Dodajam košček toasta v toaster");
            Console.WriteLine("Začenjam peči...");
            //Task.Delay(3000).Wait();
            await Task.Delay(3000);
            Console.WriteLine("Ostrani toast iz toasterja");
            return new Toast();
        }

        //  private static Bacon FryBacon(int slices)
        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"dodajanje {slices} kosov slanine v ponev");
            Console.WriteLine("pečenje ene strani slanine...");
             Task.Delay(3000).Wait();
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
                Console.WriteLine("Obračanje slanine");
            Console.WriteLine("pečenje druge strani slanine...");
            Task.Delay(3000).Wait();
            await Task.Delay(3000);
            Console.WriteLine("Daj slanino na krožnik");
            return new Bacon();
        }

       // private static Egg FryEggs(int howMany)
       private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Segrevanje ponve...");
            //Task.Delay(3000).Wait();
            await Task.Delay(3000);
            Console.WriteLine($"razbijanje {howMany} jajc");
            Console.WriteLine("cvretje jajc ...");
            //Task.Delay(3000).Wait();
            await Task.Delay(3000);
            Console.WriteLine("Daj jajca na krožnik");
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Kuhanje kave");
            return new Coffee();
        }
    }
}
