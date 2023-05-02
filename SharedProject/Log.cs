using System;
using System.IO;

namespace SharedProject
{
    public static class Common
    {
        public const string OutputFolder = "c:\\temp";
    }

    public static class Log
    {
        public static void Info(string s)
        {
            try
            {
                File.AppendAllText($"{Common.OutputFolder}\\RenderTest_log.txt", $"{s}\n");
            }
            catch (Exception) { }
        }
    }
}
