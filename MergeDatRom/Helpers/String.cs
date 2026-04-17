using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MergeDatRom.Helpers
{
    internal class String
    {
        private static readonly HashSet<string> WindowsReservedNames = new HashSet<string>(
            new[]
            {
                "CON", "PRN", "AUX", "NUL",
                "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            },
            System.StringComparer.OrdinalIgnoreCase);

        internal static string ToFileSafe(string input, char replacement = '-')
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "unnamed";
            }

            var invalidChars = Path.GetInvalidFileNameChars();
            var builder = new StringBuilder(input.Length);

            foreach (char c in input)
            {
                if (char.IsControl(c) || invalidChars.Contains(c) || c == '/')
                {
                    builder.Append(replacement);
                }
                else
                {
                    builder.Append(c);
                }
            }

            var safe = builder.ToString().Trim().TrimEnd('.', ' ');
            if (safe.Length == 0)
            {
                safe = "unnamed";
            }

            if (WindowsReservedNames.Contains(safe))
            {
                safe = $"{safe}{replacement}";
            }

            return safe;
        }
    }
}