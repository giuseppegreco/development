#region Header
//+ <source name="ThermometerConsole.cs" language="C#" begin="2-Jan-2012">
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
using Thermota.Core;
#endregion

namespace Thermota
{
    /// <summary>
    /// Implements the thermometer console.
    /// </summary>
    public class ThermometerConsole
    {
        #region Fields
        private const string Prompt = "[thermota ~]$";

        private static readonly string CommandAverage;
        private static readonly string CommandCurrent;
        private static readonly string CommandExit;
        private static readonly string CommandHelp;

        private static readonly string MessageWelcome;
        private static readonly string MessageAverage;
        private static readonly string MessageCurrent;
        private static readonly string MessageExit;
        private static readonly string MessageHelp;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members.
        /// </summary>
        static ThermometerConsole()
        {
            // Commands
            CommandAverage = Resources.Command_Average;
            CommandCurrent = Resources.Command_Current;
            CommandExit = Resources.Command_Exit;
            CommandHelp = Resources.Command_Help;

            // Messages
            MessageWelcome = Resources.Message_Welcome;
            MessageAverage = Resources.Message_Average;
            MessageCurrent = Resources.Message_Current;
            MessageExit = Resources.Message_Exit;
            MessageHelp = Resources.Message_Help;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            Thermometer thermometer = new Thermometer();

            Console.WriteLine(MessageWelcome);

            string command;
            bool exit = false;

            do {
                Console.Write("\n" + Prompt + " ");
                command = Console.ReadLine();

                if (command == CommandAverage) {
                    Console.WriteLine(thermometer.AverageTemperature);
                } else if (command == CommandCurrent) {
                    Console.WriteLine(thermometer.Temperature);
                } else if (command == CommandExit) {
                    exit = true;
                } else {
                    Console.WriteLine(CommandAverage + "\t\t" + MessageAverage);
                    Console.WriteLine(CommandCurrent + "\t\t" + MessageCurrent);
                    Console.WriteLine(CommandExit + "\t\t" + MessageExit);
                    Console.WriteLine(CommandHelp + "\t\t" + MessageHelp);
                }
            } while (!exit);
        }
        #endregion
    }
}
