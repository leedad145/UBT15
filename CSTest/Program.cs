//교과서
//https://thebook.io/006890/
//노션
//https://aquatic-care-bc3.notion.site/Unity-15th-2b0715f54fd48008bcb4f25c2bb6f983
//구글드라이브
//https://drive.google.com/drive/folders/1xP_gRcH-dhrZyV2zBjc1f_eEOVFrEOrF?dmr=1&ec=wgc-drive-globalnav-goto

using System.ComponentModel;
using System.Runtime.InteropServices;

class Program
{   
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
        string inputStr = sr.ReadLine();
        int M = int.Parse(sr.ReadLine());//명령어의 수
        List<char> outPut = new List<char>();
        outPut.AddRange(inputStr);
        int cusser = outPut.Count;
        for(int i = 0; i < M; i++)
        {
            string[] input = sr.ReadLine().Split(" ");
            switch (input[0])
            {
                case "L":
                    cusser = Math.Max(0,cusser-1);
                    break;
                case "D":
                    cusser = Math.Min(cusser+1,outPut.Count);
                    break;
                case "B":
                    if(cusser != 0)
                    {
                        outPut.RemoveAt(cusser-1);
                        cusser--;
                    }
                    break;
                case "P":
                    outPut.Insert(cusser, char.Parse(input[1]));
                    cusser++;
                    break;
            }
        }
        foreach(char c in outPut)
        {
            sw.WriteLine(c);
        }
    }   
}
