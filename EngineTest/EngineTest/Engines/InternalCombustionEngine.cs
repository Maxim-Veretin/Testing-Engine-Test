using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EngineTest.Engines
{
    class InternalCombustionEngine : IEngine // двигатель внутреннего сгорания
    {
        public bool IsWorking { get; set; } = false;
        public double TEngine { get; set; }
        public int I { get; } = 10;
        public int[] M { get; } = { 20, 75, 100, 105, 75, 0 };
        public int[] V { get; } = { 0, 75, 150, 200, 250, 300 };
        public int TOverheat { get; } = 110;
        public double Hm { get; } = 0.01;
        public double Hv { get; } = 0.0001;
        public double C { get; } = 0.1;
        public double Time { get; set; } = 0;
        private double TAmbient { get; set; }

        /// <summary> Структура, хранящая скорость вращения коленвала, крутящий момент и ускорение в момент времени и время перехода в это состояние из предыдущего. </summary>
        struct PointsOfTime
        {
            public double V;
            public double M;
            public double A;
            public double Time;
        }

        private readonly List<PointsOfTime> points = new List<PointsOfTime>();

        public InternalCombustionEngine(double TAmbient)
        {
            TEngine = TAmbient;
            this.TAmbient = TAmbient;
        }

        public void Start()
        {
            Console.WriteLine("\nДвигатель запущен");

            IsWorking = true;
            
            int currentPoint = 0; // текущая вершина графика
            double offset = 0; // смещение по оси X относительно текущей вершины графика
            int x1, x2, y1, y2; // координаты, интерполируемых точек
            double currentX, currentY; // координаты текущей точки

            while (IsWorking)
            {
                x1 = V[currentPoint];
                x2 = V[currentPoint + 1];
                y1 = M[currentPoint];
                y2 = M[currentPoint + 1];
                currentX = x1 + offset;
                currentY = ((currentX - x1) * (y2 - y1) / (x2 - x1)) + y1;

                PointsOfTime point = new PointsOfTime
                {
                    V = currentX,
                    M = currentY,
                    A = currentY / I
                };

                int lenght = points.ToArray().Length;

                if (points.Count() > 0) // если в списке содержится не одна точка, вычисляем время перехода
                {
                    if (currentY == M[M.Length-1])
                        point.Time = (point.V - points.ToArray()[lenght - 1].V) / points.ToArray()[lenght - 1].A;
                    else
                        point.Time = (point.V - points.ToArray()[lenght - 1].V) / point.A;
                }
                else // иначе приравниваем время к нулю, т.к. очевидно что это первая точка
                    point.Time = 0;

                points.Add(point);

                // вычисляем изменения температуры двигателя
                double Vh = GetHeatingRate(points.ToArray()[lenght].V, points.ToArray()[lenght].M);
                double Vc = GetCoolingRate(TAmbient);
                TEngine += Vh + Vc;

                Time += points.ToArray()[lenght].Time; // высчитываем сколько секунд уже проработал двигатель

                if (Math.Round(TEngine, 2) >= TOverheat)
                {
                    Stop();
                }

                if (currentX == x2) // если координата X текущей точки равна координате X следующей точки
                {
                    if (currentX != V[V.Length-1]) // и если текущая точка - не последняя в массиве заданных параметров
                    {
                        currentPoint++; // то смещаем текущую вершину
                        offset = 0; // и обнуляем смещение
                    }
                    else
                    {
                        Stop(); // иначе останавливаем симуляцию
                    }
                }
                else
                    offset+=5; // если следующая вершина не была достигнута - увеличиваем смещение
            }
        }

        public void Stop()
        {
            IsWorking = false;

            Console.WriteLine("\nДвигатель остановлен");
        }

        /// <summary>
        /// Возвращает ускорение коленвала при заданном крутящем моменте двигателя.
        /// </summary>
        public double GetCrankshaftAcceleration(double torques)
        {
            return torques / this.I;
        }

        /// <summary>
        /// Возвращает скорость нагрева двигателя при заданных крутящем моменте двигателя и скорости вращения коленвала
        /// </summary>
        /// <param name="torques"> Крутящий момент двигателя. </param>
        /// <param name="crankshaftRotationSpeeds"> Скорость вращения коленвала. </param>
        public double GetHeatingRate(double crankshaftRotationSpeeds, double torques)
        {
            return torques * this.Hm + Math.Pow(crankshaftRotationSpeeds, 2) * this.Hv;
        }

        /// <summary>
        /// Возвращает скорость охлаждения двигателя при заданной температуре окружающей среды.
        /// </summary>
        /// <param name="TAmbient"> Температура окружающей среды. </param>
        /// <returns></returns>
        public double GetCoolingRate(double TAmbient)
        {
            return C * (TAmbient - this.TEngine);
        }
    }
}
