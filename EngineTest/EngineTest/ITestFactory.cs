using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest
{
    interface ITestFactory
    {
        /// <summary>
        /// Двигатель, который проходит тестирование.
        /// </summary>
        IEngine Engine { get; }
        /// <summary>
        /// Счётчик времени, в течении которого проходит тестирование.
        /// </summary>
        double Time { get; }
        /// <summary>
        /// Метод, возвращающий длительность тестирования в секундах.
        /// </summary>
        double OverheatTime();
    }
}
