using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LesAsynchrones
{
    class Program
    {
        static void Main(string[] args)
        {
            TraitementAsynchroneParTache();

            TraitementAsynchroneAvecAsync();
        }

        private static void TraitementAsynchroneParTache()
        {
            //Définition d'un Action (paramètre d'une TASK)
            Console.WriteLine("Mon traitement initial dans " + Thread.CurrentThread.ManagedThreadId);
            Action monActionComplexe = new Action(HardCalcul);
            Task task1 = new Task(monActionComplexe);
            Task task2 = new Task(SimpleCalcul);
            Task<long> task3 = new Task<long>(HardCalculLong);

            task1.Start();//tâche 1
            task2.Start();//tâche 2
            task3.Start();//tâche 3
            Console.WriteLine("Tâches lancées");

            //Attention, ici task3.Result n'étant disponible qu'à la fin du traitement, la suite des instructions est en fait synchrone
            //Pour garder le comportement asynchrone, on peut utiliser ContinueWith et indiquer la tâche qui succèdera pour l'affichage de la donnée
            /*Console.WriteLine("task3.val = "+ task3.Result);*/

            long myLong;
            task3.ContinueWith(prevTask => { myLong = prevTask.Result; Console.WriteLine("task3.val = " + prevTask.Result); });
            /* OU : task3.ContinueWith(ShowTaskInformation); */
            Console.WriteLine("Toutes les insctructions sont terminées");
            Console.ReadLine();
        }

        private static async void TraitementAsynchroneAvecAsync()
        {
            Console.WriteLine("Traitement asynchrone dans " + Thread.CurrentThread.ManagedThreadId);
            //long resultat= await Task<long>.Run(()=>
            //{
            //    long monLong = 0;
            //    return monLong;
            //});

            Task task1 = new Task(HardCalcul);
            Task task2 = new Task(SimpleCalcul);
            //Task<long> task3 = new Task<long>(HardCalculLong);
            Console.WriteLine("Task5 initialisé");
            Task<long> task5 = HardReturnLong();

            task1.Start();//Ma Tache1
            Console.WriteLine("(HardCalcul(6)" + HardCalcul(6));//Ma Tache6
            task2.Start();//Ma tâche 2
            long resultat1 = await HardCalculAsync();//Ma tâche 4

            Func<long> maFunc = new Func<long>(HardCalculLong);
            long resultat2 = await Task<long>.Run(maFunc);//Ma tâche 3

            Console.WriteLine("Résultat de la Task5 en ATTENTE de récupération");
            //long resultat3 = await SimpleCalculLong();//tache 5
            long resultat4 = await task5;//tache 5
            Console.WriteLine("Résultat de la Task5 récupéré");

            //Console.WriteLine("res3 :" + resultat3);
            Console.WriteLine("res4 :" + resultat4 + " : Fin Traitement asynchrone");
        }

        private static async Task<long> HardCalculAsync()
        {
            long val = 0;
            for (int i = 0; i < 900000000; i++)
                val += i;

            Console.WriteLine("Ma tâche 4 dans " + Thread.CurrentThread.ManagedThreadId);
            return val;
        }

        private static void ShowTaskInformation(Task<long> task)
        {
            Console.WriteLine("task3.val = " + task.Result);
        }

        private static long HardCalcul(int tacheNumer = 6)
        {
            int val = 0;
            for (int i = 0; i < 80000000; i++)
                val += i;

            Console.WriteLine("Ma tâche " + tacheNumer + " dans " + Thread.CurrentThread.ManagedThreadId);
            return val;
        }

        private static long HardCalculLong()
        {
            int val = 0;
            for (int i = 0; i < 80000000; i++)
                val += i;

            Console.WriteLine("Ma tâche 3 HardCalculLong() dans " + Thread.CurrentThread.ManagedThreadId);
            return val;
        }

        private static void HardCalcul()
        {
            int val;
            for (int i = 0; i < 80000000; i++)
                val = i;

            Console.WriteLine("Ma tâche 1 dans " + Thread.CurrentThread.ManagedThreadId);
        }
        private static void SimpleCalcul()
        {
            int val;
            for (int i = 0; i < 100; i++) val = i;
            Console.WriteLine("Ma tâche 2 dans " + Thread.CurrentThread.ManagedThreadId);
        }

        private static async Task<long> SimpleCalculLong()
        {
            long val = 0;

            for (int i = 0; i < 10; i++)
                val = i;

            Console.WriteLine("Ma tâche 5 dans " + Thread.CurrentThread.ManagedThreadId);
            return val;
        }

        private static async Task<long> HardReturnLong()
        {
            //Task<long> task = new Task<long>(() =>
            //{
            long val = 50;
            Console.WriteLine("Ma tâche HardReturnLong dans " + Thread.CurrentThread.ManagedThreadId);

            Task<long> task1 = new Task<long>(HardCalculLong);
            task1.Start();
            val = task1.Result;

            return val;
            //}
            //);
            //return task;
        }
    }
}
