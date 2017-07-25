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
        public static bool Encode(string input, string output)
        {
            string resultStr = String.Empty;

            byte[] bytes = null;

            if (File.Exists(input))
            {
                try
                {
                    bytes = File.ReadAllBytes(input);
                }
                catch (Exception e)
                {
                    throw new Exception("Exception in File.ReadAllBytes(path)", e);
                }
            }
            else
            {
                bytes = Encoding.Unicode.GetBytes(input);
            }

            resultStr = Convert.ToBase64String(bytes);

            if (output != null)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(output))
                    {
                        writer.Write(resultStr);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Exception in StreamWriter.Write(string)", e);
                }
            }
            else
            {
                Console.WriteLine(resultStr);
            }

            return true;
        }

        public static bool Decode(string input, string output)
        {
            string base64 = null;

            if (File.Exists(input))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(input))
                    {
                        base64 = reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Exception while opening/reading '" + input + "' file.", e);
                }
            }
            else
            {
                base64 = input;
            }

            byte[] bytes = Convert.FromBase64String(base64);

            if (output != null)
            {
                try
                {
                    File.WriteAllBytes(output, bytes);
                }
                catch (Exception e)
                {
                    throw new Exception("Exception in File.WriteAllBytes(outputPath, bytes)", e);
                }
            }
            else
            {
                Console.WriteLine(Encoding.Unicode.GetString(bytes));
            }

            return true;
        }
    }
}
