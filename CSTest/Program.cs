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
        Console.Write(Solution.solution("3141592", "271"));

    }
public class Solution {
    static public int solution(string t, string p) {
        int answer = 0;
        
        for(int i = 0; i < t.Length - p.Length; i++)
        {
            if (int.Parse(p) >= int.Parse(t[i..(i+p.Length)]))
                answer++;
        }
        return answer;
    }
}
}
