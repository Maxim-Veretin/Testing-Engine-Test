using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest.Engines
{
    class InternalCombustionEngine : IEngine // двигатель внутреннего сгорания
    {
        public double Temperature { get; set; }
        public double CrankshaftAcceleration { get; } = 0;
        public double InertiaMoment { get; } = 10;
        public double[] Torques { get; } = { 20, 75, 100, 105, 75, 0 };
        public double[] CrankshaftRotationSpeeds { get; } = { 0, 75, 150, 200, 250, 300 };
        public double OverheatTemperature { get; } = 110;
        public double HeatCoefficientM { get; } = 0.01;
        public double HeatCoefficientV { get; } = 0.0001;
        public double C { get; } = 0.1;

        public InternalCombustionEngine(double temp/*, double ca, double im, double[] torques, double[] crs, double overTemp, double heatM, double heatV, double c*/)
        {
            this.Temperature = temp;
            //this.CrankshaftAcceleration = ca;
            //this.InertiaMoment = im;
            //this.Torques = new double[6];
            //this.CrankshaftRotationSpeeds = new double[6];

            //for (int i = 0; i < torques.Length; i++)
            //{
            //    this.Torques[i] = torques[i];
            //    this.CrankshaftRotationSpeeds[i] = crs[i];
            //}

            //this.OverheatTemperature = overTemp;
            //this.HeatCoefficientM = heatM;
            //this.HeatCoefficientV = heatV;
            //this.C = c;
        }

        public void Start()
        {
            Console.WriteLine("Двигатель запущен");
        }

        public void Stop()
        {
            Console.WriteLine("Двигатель остановлен");
        }
    }
}
