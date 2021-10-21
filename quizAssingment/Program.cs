using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace quizAssingment
{
    class quizData
    {
       public string Ques { get; set; }
       public string A { get; set; }
       public string B { get; set; }
       public string C { get; set; }
       public string D { get; set; }
       public string Ans { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int countRight = 0;
            int countWrong = 0;
            using(StreamReader sr = new StreamReader("qest.json"))
            {
               string result=sr.ReadToEnd();
                
                List<quizData> dataList = JsonSerializer.Deserialize<List<quizData>>(result);

                int index = 0;
                foreach(quizData q in dataList )
                {
                    index += 1;
                    Console.WriteLine(index + ". " + q.Ques);
                    Console.WriteLine("A." + q.A); 
                    Console.WriteLine("B." + q.B); 
                    Console.WriteLine("C." + q.C); 
                    Console.WriteLine("D." + q.D); 
                    Console.WriteLine("Enter your choice:");
                    string input = Console.ReadLine().ToUpper();
                    if(input == q.Ans)
                    {
                        Console.WriteLine("Right answer");
                        countRight++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer");
                        Console.WriteLine("Right answer" + ":" + q.Ans);
                        countWrong++;
                    }

                    Console.WriteLine("\n");
                }

                Console.WriteLine("Total Right Answers: " + countRight + "\n" + "Total Wrong Answers: " + countWrong);
            }
           
           
        }
    }
}
