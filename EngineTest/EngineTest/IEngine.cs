using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest
{
    interface IEngine
    {
        /// <summary> Метод для запуска двигателя. </summary>
        void Start();
        /// <summary> Метод для остановки двигателя. </summary>
        void Stop();

        /// <summary> Температура двигателя. </summary>
        double Temperature { get; set; }
        /// <summary> Ускорение коленвала. </summary>
        double CrankshaftAcceleration { get; }
        /// <summary> Момент инерции двигателя. </summary>
        double InertiaMoment { get; }
        /// <summary> Массив, содержащий значения крутящего момента, вырабатываемого двигателем. </summary>
        double[] Torques { get; }
        /// <summary> Массив, содержащий значения скоростей вращения коленвала. </summary>
        double[] CrankshaftRotationSpeeds { get; }
        /// <summary> Температура перегрева двигателя. </summary>
        double OverheatTemperature { get; }
        /// <summary> Коэффициент зависимости скорости нагрева от крутящего момента. </summary>
        double HeatCoefficientM { get; }
        /// <summary> Коэффициент зависимости скорости нагрева от скорости вращения коленвала. </summary>
        double HeatCoefficientV { get; }
        /// <summary> Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды. </summary>
        double C { get; }
    }
}
