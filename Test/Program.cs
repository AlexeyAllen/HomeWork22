using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading;

using System.Threading.Tasks;

namespace HomeWork22

{

    //Сформировать массив случайных целых чисел.

    class Program

    {

        static void GetSum(object arrayIn)

        {

            int[] array = (int[])arrayIn;

            int sum = array.Sum();

            Console.WriteLine("Cумма значений элементов масcива: {0}", sum);

        }

        static void GetMax(Task task, object arrayIn)

        {

            int[] array = (int[])arrayIn;

            int max = array.Max();

            Console.WriteLine("Максимальное значение элемента масcива: {0}", max);

        }

        static void Main(string[] args)

        {

            Console.Write("Введите размер одномерного массива: ");

            int arraySize = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)

            {

                array[i] = random.Next(0, 100);

            }

            Console.WriteLine("Значения элементов массива: ");

            foreach (int val in array)

            {

                Console.WriteLine(val + " ");

            }

            Console.WriteLine("");

            object[] array1 = array.Cast<object>().ToArray();

            Action<object> action1 = new Action<object>(GetSum);

            Task task1 = new Task(action1, array);

            Action<Task, object> action2 = new Action<Task, object>(GetMax);

            Task task2 = task1.ContinueWith((Action<Task, object>)action2, array);

            task1.Start();

            Console.ReadKey();

        }

    }

}