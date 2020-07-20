using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EngineTest.Tests
{
    class OverheatTimeTest : ITestFactory
    {
        public IEngine Engine { get; }

        public OverheatTimeTest(IEngine engine)
        {
            this.Engine = engine;
        }

        public void StartSimulation()
        {
            Engine.Start();
        }

        public void Controller()
        {
            if (Engine.IsWorking == false)
            {
                if (Math.Round(Engine.TEngine, 2) >= Engine.TOverheat)
                    OverheatTime();
                else
                    Console.WriteLine("Двигатель отработал без перегрева");
            }
        }

        /// <summary>
        /// Возвращает время, за которое перегреется двигатель.
        /// </summary>
        public void OverheatTime()
        {
            Console.WriteLine($"Время до перегрева двигателя: {Math.Round(this.Engine.Time, 2)} секунд");
        }
    }
}
