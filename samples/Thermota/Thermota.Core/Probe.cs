#region Header
//+ <source name="Probe.cs" language="C#" begin="2-Jan-2012">
//+ <author href="mailto:giuseppe.greco@agamura.com">Giuseppe Greco</author>
//+ <copyright year="2012">
//+ <holder web="http://www.agamura.com">Agamura, Inc.</holder>
//+ </copyright>
//+ <legalnotice>All rights reserved.</legalnotice>
//+ </source>
#endregion

#region References
using System;
using System.Threading;
#endregion

namespace Thermota.Core
{
    /// <summary>
    /// Implements a virtual probe for simulating temperature detections.
    /// </summary>
    public class Probe
    {
        #region Fields
        private const int AbsoluteZero = -273;
        private const int MaxTemperature = 100;
        private const int DetectionInterval = 5000;
        private Thread detector;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when a temperature detection is performed.
        /// </summary>
        public event EventHandler<DetectTemperatureEventArgs> DetectTemperature;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Probe"/> class.
        /// </summary>
        public Probe() { }
        #endregion

        #region Methods
        /// <summary>
        /// Starts temperature detections.
        /// </summary>
        public void Start()
        {
            detector = new Thread(new ThreadStart(Detect));
            detector.Start();
            detector.IsBackground = true;
        }

        /// <summary>
        /// Stops temperature detections.
        /// </summary>
        public void Stop()
        {
            detector.Join(0);
        }

        /// <summary>
        /// Simulates temperature detections.
        /// </summary>
        private void Detect()
        {
            int temperature;
            Random random = new Random();

            while (true) {
                try {
                    temperature = random.Next(AbsoluteZero, MaxTemperature);
                } catch (ArgumentOutOfRangeException) {
                    temperature = MaxTemperature;
                }

                if (DetectTemperature != null) {
                    DetectTemperature(this, new DetectTemperatureEventArgs(temperature));
                }

                Thread.Sleep(DetectionInterval);
            }
        }
        #endregion
    }
}
