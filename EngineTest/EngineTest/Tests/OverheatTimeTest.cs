using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest.Tests
{
    class OverheatTimeTest : ITestFactory
    {
        public IEngine Engine { get; }
        public double Time { get; } = 0;

        public OverheatTimeTest(IEngine engine)
        {
            this.Engine = engine;
        }

        /// <summary>
        /// Возвращает время, за которое перегреется двигатель.
        /// </summary>
        public double OverheatTime()
        {
            Console.WriteLine($"Время до перегрева двигателя: {this.Time} секунд");

            return Time;
        }

        /// <summary>
        /// Возвращает ускорение коленвала при заданном крутящем моменте двигателя.
        /// </summary>
        public double GetCrankshaftAcceleration(double torques)
        {
            return torques / Engine.InertiaMoment;
        }
    }
}
