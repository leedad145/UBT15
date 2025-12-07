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
    static void Main()
    {
        MyList<int> ints = new MyList<int>();

        ints.Add(1);
        ints.Add(2);
        ints.Add(3);
        ints.Add(4);
        ints.Add(5);
        ints.RemoveAt(2);
        ints.RemoveAt(2);
        ints.Add(2);
        ints.Add(4);
        Console.WriteLine(ints[0]);
        Console.WriteLine(ints[1]);
        Console.WriteLine(ints[2]);
        Console.WriteLine(ints[3]);
        Console.WriteLine(ints[4]);
        Console.WriteLine(ints[5]);
        Console.WriteLine(ints[6]);
        Console.WriteLine(ints[7]);
        Console.WriteLine(ints[8]);
    }
}
