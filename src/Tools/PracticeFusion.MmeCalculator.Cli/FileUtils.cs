using System;
using System.IO;

namespace PracticeFusion.MmeCalculator.Cli
{
    static class FileUtils
    {
        internal static TextReader GetInputStream(FileInfo input)
        {
            if (input == null || !input.Exists)
            {
                return Console.In;
            }

            return input.OpenText();
        }

        internal static TextWriter GetOutputStream(FileInfo output, bool overwrite)
        {
            if (output == null)
            {
                return Console.Out;
            }

            if (output.Exists && !overwrite)
            {
                throw new Exception($"{output.Name} exists, use --overwrite to overwrite an existing file");
            }

            return output.CreateText();
        }
    }
}
