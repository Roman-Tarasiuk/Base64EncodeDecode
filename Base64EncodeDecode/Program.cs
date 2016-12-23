using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Base64EncodeDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!CheckAttributes(args))
            {
                ShowProgramUsage();
                Console.WriteLine("Exit.");
                return;
            }

            bool completeSuccessfully = false;

            if (args[0] == "-encode")
            {
                completeSuccessfully = Coder.Encode(args[1], args[2]);
            }
            else // "-decode"
            {
                completeSuccessfully = Coder.Decode(args[1], args[2]);
            }

            if (completeSuccessfully)
            {
                Console.WriteLine("Success " + args[0].Substring(1) + ".");
            }
            else
            {
                Console.WriteLine("Failed " + args[0].Substring(1) + ".");
                ShowProgramUsage();
            }
        }


        #region ** Helper Methods

        static bool CheckAttributes(string[] args)
        {
            if (args.Length != 3)
            {
                return false;
            }

            if (args[0] != "-encode" && args[0] != "-decode")
            {
                return false;
            }

            if (!File.Exists(args[1]))
            {
                return false;
            }

            return true;
        }

        static void ShowProgramUsage()
        {
            Console.WriteLine(
@"Program usage:
 Base64EncodeDecode.exe -encode|-decode input_file_path output_file_path"
                );
        }

        #endregion


        #region ** Methods

        static void Encode(string inputPath, string outputPath)
        {
             //Coder.Encode(inputPath)
        }

        #endregion
    }
}
