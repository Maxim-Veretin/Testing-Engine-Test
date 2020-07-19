using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest
{
    interface IEngine
    {
        /// <summary> Указывает, находится ли данный двигатель в работе. </summary>
        bool IsWorking { get; set; }
        /// <summary> Температура двигателя. </summary>
        double TEngine { get; set; }
        /// <summary> Момент инерции двигателя. </summary>
        int I { get; }
        /// <summary> Массив, содержащий значения крутящего момента, вырабатываемого двигателем. </summary>
        int[] M { get; }
        /// <summary> Массив, содержащий значения скоростей вращения коленвала. </summary>
        int[] V { get; }
        /// <summary> Температура перегрева двигателя. </summary>
        int TOverheat { get; }
        /// <summary> Коэффициент зависимости скорости нагрева от крутящего момента. </summary>
        double Hm { get; }
        /// <summary> Коэффициент зависимости скорости нагрева от скорости вращения коленвала. </summary>
        double Hv { get; }
        /// <summary> Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды. </summary>
        double C { get; }
        /// <summary> Счётчик времени, в течении которого проходит тестирование. </summary>
        double Time { get; set; }

        /// <summary> Метод для запуска двигателя. </summary>
        void Start();
        /// <summary> Метод для остановки двигателя. </summary>
        void Stop();
    }
}
