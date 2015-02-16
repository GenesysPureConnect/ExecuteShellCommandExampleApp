using System;
using System.Globalization;

namespace GetTimeMs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1)
                {
                    // Try to parse using the specified timestamp and a default format
                    DateTime timestamp;
                    if (DateTime.TryParse(args[0], out timestamp))
                    {
                        Environment.ExitCode = timestamp.Millisecond;
                        return;
                    }
                }
                else if (args.Length == 2)
                {
                    // Try to parse using the specified timestamp and format
                    DateTime timestamp;
                    if (DateTime.TryParseExact(args[0], args[1], CultureInfo.InvariantCulture, DateTimeStyles.None,
                        out timestamp))
                    {
                        Environment.ExitCode = timestamp.Millisecond;
                        return;
                    }
                }

                // Neither condition was valid/worked, return the current timestamp's MS
                Environment.ExitCode = DateTime.Now.Millisecond;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.ExitCode = -1;
            }
        }
    }
}
