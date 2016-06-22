using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

// Demonstrates a basic producer and consumer pattern that uses dataflow.

class IntervalEvent : IDisposable
{
    public string WindowHandle { get; set; }
    public List<System.Windows.Forms.KeyEventArgs> KeyData { get; set; }
    public DateTime StartTime { get; set; }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
class Program
{
    // Demonstrates the production end of the producer and consumer pattern.
    static void Produce(ITargetBlock<string> target)
    {
        // Create a Random object to generate random data.
        Random rand = new Random();
        // In a loop, fill a buffer with random data and
        // post the buffer to the target block.
        //for (int i = 0; i < 100; i++)
        //{
        //    // Create an array to hold random byte data.
        //    byte[] buffer = new byte[1024];
        //    // Fill the buffer with random bytes.
        //    rand.NextBytes(buffer);
        //    // Post the result to the message block.
        //    target.Post(buffer);
        //}
        bool crazy = true;
        while (crazy)
        {
            string thing = Console.ReadLine();
            if (thing.ToString() == "hey")
            {
                crazy = false;
            }
            target.Post(thing.ToString());
            continue;
        }
        // Set the target to the completed state to signal to the consumer
        // that no more data will be available.
        target.Complete();
    }
    // Demonstrates the consumption end of the producer and consumer pattern.
    static async Task<int> ConsumeAsync(ISourceBlock<string> source)
    {
        // Initialize a counter to track the number of bytes that are processed.
        int bytesProcessed = 0;
        // Read from the source buffer until the source buffer has no 
        // available output data.
        while (await source.OutputAvailableAsync())
        {
            //byte[] data = source.Receive();
            //// Increment the count of bytes received.
            //bytesProcessed += data.Length;
            //Console.WriteLine(data[3].ToString());
            Console.WriteLine(source.Receive());
            bytesProcessed++;
        }
        return bytesProcessed;
    }
    static void Main(string[] args)
    {
        // Create a BufferBlock<byte[]> object. This object serves as the 
        // target block for the producer and the source block for the consumer.
        var buffer = new BufferBlock<string>();
        // Start the consumer. The Consume method runs asynchronously. 
        var consumer = ConsumeAsync(buffer);
        // Post source data to the dataflow block.
        Produce(buffer);
        // Wait for the consumer to process all data.
        consumer.Wait();
        // Print the count of bytes processed to the console.
        Console.WriteLine("Processed {0} bytes.", consumer.Result);
        Console.ReadKey();
    }
}


//#define TRACE
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CSScratch
//{
//    class Program
//    {
//        static string[] words1 = new string[] { "brown", "jumped", "the", "fox", "quick" };
//        static string[] words2 = new string[] { "dog", "lazy", "the", "over" };
//        static string solution = "the quick brown fox jumped over the lazy dog.";

//        static bool success = false;
//        static Barrier barrier = new Barrier(2, (b) =>
//        {
//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < words1.Length; i++)
//            {
//                sb.Append(words1[i]);
//                sb.Append(" ");
//            }
//            for (int i = 0; i < words2.Length; i++)
//            {
//                sb.Append(words2[i]);

//                if (i < words2.Length - 1)
//                    sb.Append(" ");
//            }
//            sb.Append(".");
//#if TRACE
//            System.Diagnostics.Trace.WriteLine(sb.ToString());
//#endif
//            Console.CursorLeft = 0;
//            Console.Write("Current phase: {0}", barrier.CurrentPhaseNumber);
//            if (String.CompareOrdinal(solution, sb.ToString()) == 0)
//            {
//                success = true;
//                Console.WriteLine("\r\nThe solution was found in {0} attempts", barrier.CurrentPhaseNumber);
//            }
//        });

//        static void Main(string[] args)
//        {

//            Thread t1 = new Thread(() => Solve(words1));
//            Thread t2 = new Thread(() => Solve(words2));
//            t1.Start();
//            t2.Start();

//            // Keep the console window open.
//            Console.ReadLine();
//        }

//        // Use Knuth-Fisher-Yates shuffle to randomly reorder each array.
//        // For simplicity, we require that both wordArrays be solved in the same phase.
//        // Success of right or left side only is not stored and does not count.       
//        static void Solve(string[] wordArray)
//        {
//            while (success == false)
//            {
//                Random random = new Random();
//                for (int i = wordArray.Length - 1; i > 0; i--)
//                {
//                    int swapIndex = random.Next(i + 1);
//                    string temp = wordArray[i];
//                    wordArray[i] = wordArray[swapIndex];
//                    wordArray[swapIndex] = temp;
//                }

//                // We need to stop here to examine results
//                // of all thread activity. This is done in the post-phase
//                // delegate that is defined in the Barrier constructor.
//                barrier.SignalAndWait();
//            }
//        }
//    }
//}