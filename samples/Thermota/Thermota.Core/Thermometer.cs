#region Header
//+ <source name="Thermometer.cs" language="C#" begin="2-Jan-2012">
//+ <author href="mailto:giuseppe.greco@agamura.com">Giuseppe Greco</author>
//+ <copyright year="2012">
//+ <holder web="http://www.agamura.com">Agamura, Inc.</holder>
//+ </copyright>
//+ <legalnotice>All rights reserved.</legalnotice>
//+ </source>
#endregion

#region References
using System;
using System.Collections;
#endregion

namespace Thermota.Core
{
    /// <summary>
    /// Models a thermometer.
    /// </summary>
    public class Thermometer
    {
        #region Fields
        private const int MaxCapacity = 50;

        private Probe probe;
        private int temperature;
        private ArrayList temperatures;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        /// <value>
        /// The current temperature in degrees Celsius.
        /// </value>
        public int Temperature
        {
            get { return temperature; }
        }

        /// <summary>
        /// Gets the average temperature.
        /// </summary>
        /// <value>
        /// The average temperature in degrees Celsius.
        /// </value>
        public int AverageTemperature
        {
            get {
                int temperatureSum = 0;

                foreach (int temperature in temperatures) {
                    temperatureSum += temperature;
                }

                int averageTemperature;

                if (temperatureSum > 0) {
                    averageTemperature = temperatureSum / temperatures.Count;
                } else {
                    averageTemperature = this.Temperature;
                }

                return averageTemperature;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Thermometer"/> class.
        /// </summary>
        public Thermometer()
        {
            temperatures = ArrayList.Synchronized(new ArrayList(MaxCapacity));
            probe = new Probe();

            probe.DetectTemperature +=
                new EventHandler<DetectTemperatureEventArgs>(OnDetectTemperature);

            probe.Start();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handles the <see cref="Probe.DetectTemperature"/> event.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="Probe"/> that generated the event.
        /// </param>
        /// <param name="args">
        /// A <see cref="DetectTemperatureEventArgs"/> that contains the last
        /// detected temperature.
        /// </param>
        private void OnDetectTemperature(
            Object sender, DetectTemperatureEventArgs args)
        {
            temperature = args.Temperature;

            if (temperatures.Count == MaxCapacity) {
                temperatures.RemoveAt(0);
            }

            temperatures.Add(temperature);
        }
        #endregion
    }
}
