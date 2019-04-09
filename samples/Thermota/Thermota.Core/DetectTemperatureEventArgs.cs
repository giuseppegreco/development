#region Header
//+ <source name="DetectTemperatureEventArgs.cs" language="C#" begin="2-Jan-2012">
//+ <author href="mailto:giuseppe.greco@agamura.com">Giuseppe Greco</author>
//+ <copyright year="2012">
//+ <holder web="http://www.agamura.com">Agamura, Inc.</holder>
//+ </copyright>
//+ <legalnotice>All rights reserved.</legalnotice>
//+ </source>
#endregion

#region References
using System;
#endregion

namespace Thermota.Core
{
    /// <summary>
    /// Provides data for the <see cref="Probe.DetectTemperature"/> event.
    /// </summary>
    public class DetectTemperatureEventArgs : EventArgs
    {
        #region Fields
        private int temperature;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the detected temperature.
        /// </summary>
        /// <value>
        /// The detected temperature in degrees Celsius.
        /// </value>
        public int Temperature
        {
            get { return temperature; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DetectTemperatureEventArgs"/> class with the specified
        /// temperature.
        /// </summary>
        /// <param name="temperature">
        /// The detected temperature in degrees Celsius.
        /// </param>
        public DetectTemperatureEventArgs(int temperature)
        {
            this.temperature = temperature;
        }
        #endregion
    }
}
