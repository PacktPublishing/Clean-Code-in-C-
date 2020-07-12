using CH01_CodingStandardsAndPrinciples.BadCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// Example of badly named namespace. For one, the code
// contained in this example is bad code. So the namespace
// should be BadCode. The main factor that governs good
// namespaces, is that a good namespace is named after the 
// folder structure that it is placed in.
namespace CH01_CodingStandardsAndPrinciples.GoodCode
{
    /// <summary>
    /// MyClass is an example of bad class naming
    /// that has actually found its way into
    /// production code! Just by looking at the
    /// class name, can you discern what it does?
    /// </summary>
    public class MyClass
    {
        // Examples of bad names and bad comments
        // They are also missing an underscore prefix that
        // identifies member variables and differentiates them
        // from local variables.
        public string strMyString; // This stores text!
        public int i; // This stores integer values for indexes.
        private readonly byte[] Key;
        private readonly byte[] IV;

        public MyClass()
        {
            Key = Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            IV = Encoding.ASCII.GetBytes("a0b1c2d3e4f6gh78j9K0L1M2N3O4P5Q6R7S8T9U0V1W2X3Y4Z5");
        }

        // This is an example of a bad method name. The casing
        // should be Pascal Case not Camel Case.
        public int myMethod(int a, int b)
        {
            // Bad local variable naming.
            // Even though the name is okay, it should be in
            // Camel Case and not in Pascal Case.
            // Also, the local variable is unnecessary as it 
            // simply returns the result of an addition.
            // Therefore, the method can be a single line that
            // returns the result of the addition.
            var SumValue = a + b;
            return SumValue;
        }

        // This is an example of bad commenting. Your code 
        // should be under version control, and so have a
        // history associated with it. So instead of commenting
        // out code blocks that are no longer required, they 
        // should be deleted.
        /* Obsolete. Use Logger.LogText(string text) instead.
        public void LogText(string text)
        {
            // Implementation omitted.
        }*/

        // The method provides an example of a bad comment.
        // Okay, you may need to track the source down. But
        // at least add a TODO: comment so that it gets picked
        // up in the task list upon build. Or better still
        // Implement an ArgumentNullValidator that throws an
        // InvalidArgument exception if the denominator is 
        // zero.
        public double Divide(int numerator, int denominator)
        {
            // Sometimes this method causes a divide by zero.
            // Don't know why?
            return numerator / denominator;
        }

        // This methods is bad for two reasons:
        // [1] Not all code paths return a value.
        // [2] It does two things:
        //     [1] Encrypts a string
        //     [2] Decrypts a string
        // [3] Following naming conventsions, the name should be 
        //     Security not security.
        // [4] The name of the class is not explicit in what 
        //     work it does.
        public string security(string plainText)
        {
            try
            {
                byte[] encrypted;
                using (AesManaged aes = new AesManaged())
                {
                    ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
                Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                using (AesManaged aesm = new AesManaged())
                {
                    ICryptoTransform decryptor = aesm.CreateDecryptor(Key, IV);
                    using (MemoryStream ms = new MemoryStream(encrypted))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(cs))
                                plainText = reader.ReadToEnd();
                        }
                    }
                }
                Console.WriteLine($"Decrypted data: {plainText}");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadKey();
            return plainText;
        }

        public void BreFlowControlExample(BusinessRuleException bre)
        {
            switch (bre.Message)
            {
                case "OutOfAcceptableRange":
                    DoOutOfAcceptableRangeWork();
                    break;
                default:
                    DoInAcceptableRangeWork();
                    break;
            }
        }

        public void BetterFlowControlExample(bool isInAcceptableRange)
        {
            if (isInAcceptableRange)
                DoInAcceptableRangeWork();
            else
                DoOutOfAcceptableRangeWork();
        }

        private void DoOutOfAcceptableRangeWork()
        {
            Console.WriteLine("OutOfAcceptableRange()");
        }

        private void DoInAcceptableRangeWork()
        {
            Console.WriteLine("DoInAcceptableRangeWork()");
        }
    }
}
