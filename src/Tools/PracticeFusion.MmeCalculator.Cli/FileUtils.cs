using System;
using System.IO;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal static class FileUtils
    {
        internal static TextReader GetInputStream(FileInfo input)
        {
            return input is not { Exists: true } ? Console.In : input.OpenText();
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