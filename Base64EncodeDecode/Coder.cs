using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Base64EncodeDecode
{
    class Coder
    {
        public static bool Encode(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new ArgumentException("File '" + inputPath + "' does not exist or access is denided.");
            }

            byte[] bytes = null;

            try
            {
                bytes = File.ReadAllBytes(inputPath);
            }
            catch (Exception e)
            {
                throw new Exception("Exception in File.ReadAllBytes(path)", e);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.Write(Convert.ToBase64String(bytes));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception in StreamWriter.Write(string)", e);
            }

            return true;
        }

        public static bool Decode(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new ArgumentException("File '" + inputPath + "' does not exist or access is denided.");
            }

            string base64 = null;
            try
            {
                using (StreamReader reader = new StreamReader(inputPath))
                {
                    base64 = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Exception while opening/reading '" + inputPath + "' file.", e);
            }

            byte[] bytes = Convert.FromBase64String(base64);

            try
            {
                File.WriteAllBytes(outputPath, bytes);
            }
            catch (Exception e)
            {
                throw new Exception("Exception in File.WriteAllBytes(outputPath, bytes)", e);
            }

            return true;
        }
    }
}
