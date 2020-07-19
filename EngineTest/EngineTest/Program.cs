using EngineTest.Engines;
using EngineTest.Tests;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> enginesID = new Dictionary<int, string>();
            enginesID.Add(1, "1. ДСВ");

            Dictionary<int, string> testsID = new Dictionary<int, string>();
            testsID.Add(1, "1. Рассчёт времени перегрева двигателя");

            int tAmbient; // температура окружающей среды в градусах °C
            int selectedEngineID; // номер выбранного двигателя
            int selectedTestID; // номер выбранного теста
            IEngine engine = null;
            ITestFactory testStand = null;

            Console.Write("Введите температуру окружающей среды в градусах °C: ");

            // проверка на корректность ввода температуры
            while (true)
            {
                try
                {
                    tAmbient = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Введено некорректное значение! Введите число: ");
                }
            }

            Console.WriteLine("\nВыберите тип двигателя, для проведения тестирования:");

            foreach(var eng in enginesID)
            {
                Console.WriteLine(eng.Value);
            }

            // проверка на корректность ввода и наличие двигателя в словаре
            while (true)
            {
                try
                {
                    selectedEngineID = Convert.ToInt32(Console.ReadLine());
                    
                    foreach (int ind in enginesID.Keys)
                    {
                        if (selectedEngineID == ind)
                        {
                            switch (selectedEngineID)
                            {
                                case 1:
                                    engine = new InternalCombustionEngine(tAmbient);
                                    break;
                            }
                        }
                        else
                            throw new Exception("Такого двигателя не существует!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Введено некорректное значение! Введите число: ");
                }
                catch (Exception)
                {
                    Console.Write("Такого двигателя не существует! Попробуйте снова: ");
                }
            }

            Console.WriteLine("\nВыберите тип теста:");

            foreach (var eng in testsID)
            {
                Console.WriteLine(eng.Value);
            }

            // проверка на корректность ввода и наличие теста в словаре
            while (true)
            {
                try
                {
                    selectedTestID = Convert.ToInt32(Console.ReadLine());

                    foreach (int ind in testsID.Keys)
                    {
                        if (selectedTestID == ind)
                        {
                            switch (selectedTestID)
                            {
                                case 1:
                                    testStand = new OverheatTimeTest(engine);
                                    break;
                            }
                        }
                        else
                            throw new Exception("Такого теста не существует!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Введено некорректное значение! Введите число: ");
                }
                catch (Exception)
                {
                    Console.Write("Такого теста не существует! Попробуйте снова: ");
                }
            }

            Test(testStand);

            Console.ReadKey();
        }

        static void Test(ITestFactory test)
        {
            test.StartSimulation();
            test.Controller();
        }
    }
}
