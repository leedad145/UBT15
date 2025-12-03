using System;
using System.Runtime.CompilerServices;
//교과서
//https://thebook.io/006890/
//노션
//https://aquatic-care-bc3.notion.site/Unity-15th-2b0715f54fd48008bcb4f25c2bb6f983
//구글드라이브
//https://drive.google.com/drive/folders/1xP_gRcH-dhrZyV2zBjc1f_eEOVFrEOrF?dmr=1&ec=wgc-drive-globalnav-goto
class Program
{   
    enum Season
    {
        Spring,
        Sommer,
        Automn,
        Winter
    }
    static void Main()
    {
        //FloatDouble.RunTest();
        //CharString.RunTest();
        //Read.RunTest();
        //Homework1.RunTest();
        //RPS.RunTest();
        //StarTree.RunTest();
        //OddEven.RunTest();
        //EnumDonversionExample.RunTest();
        //Console.WriteLine($"{Season.Spring}, {Season .Automn}");
        int a = 10;
        int b = 20;
        Console.Write($"{a}, {b} -(Swap)-> ");

        Swap(ref a, ref b);

        Console.WriteLine($"{a}, {b}");
    }
    static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
}