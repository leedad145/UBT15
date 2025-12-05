public class OperatorOverloadingExample
{
    static public void RunTest()
    {
        Point ptA = new Point(10, 5);
        Point ptB = new Point(3, 8);

        // 연산자 오버로딩 덕분에 객체끼리 직관적인 '+' 연산이 가능해짐
        Point ptC = ptA + ptB; 

        Console.WriteLine($"ptA: ({ptA.X}, {ptA.Y})"); // (10, 5)
        Console.WriteLine($"ptB: ({ptB.X}, {ptB.Y})"); // (3, 8)
        Console.WriteLine($"ptC (ptA + ptB): ({ptC.X}, {ptC.Y})"); // (13, 13)
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // 덧셈(+) 연산자 오버로딩
        public static Point operator +(Point p1, Point p2)
        {
            // p1의 X와 p2의 X를 더하고, p1의 Y와 p2의 Y를 더한 새로운 Point 객체를 생성하여 반환합니다.
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
    }
}