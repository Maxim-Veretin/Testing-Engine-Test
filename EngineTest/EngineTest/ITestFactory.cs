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

        /// <summary> Запускает симуляцию. </summary>
        void StartSimulation();
        /// <summary> Следит за температурой двигателя, если двигатель перегрелся - останавливает симуляцию. </summary>
        void Controller();
        /// <summary> Выводит в консоль длительность тестирования в секундах. </summary>
        void OverheatTime();
    }
}
