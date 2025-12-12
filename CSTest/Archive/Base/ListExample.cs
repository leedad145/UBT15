public class ListExample
{
    static ListExample()
    {
        List<int> ints = new List<int>();

        ints.Add(1);
        ints.Add(2);
        ints.Add(3);
        ints.Add(4);
        ints.Add(5);
        ints.RemoveAt(2); // 인덱스가 당겨짐 (Node를 쓰는 듯?)

        Console.WriteLine(ints[2]);
    }
    public int count; // 실제로 사용중인 데이터 개수
    public int capacity; // 메모리에 예약된 배열의 실제 크기
    int[] _data = new int[1];

    public void Add(int item)
    {
        // 방이 충분히 남았는니 확인
        if (count >= capacity)
        {
            // 방이 남지 않았으면 이사
            //  > 공간을 새로 만들고
            int[] newArr = new int[count * 2];

            //  > 새공간에 기존 데이터 복사
            for (int i = 0; i < count; i++)
                newArr[i] = _data[i];

            // 새 배열로 주소 덮어 쓰기
            _data = newArr;
        }

        // 새공간에 대에터 넣어주기
        _data[count] = item;
        // count == 5
        // _data[0] _data[1] _data[2] _data[3] _data[4] _data[count == 5]
        //   [0]      [1]      [2]      [3]      [4]         [item]

        count++;
    }

    public int this[int index]
    {
        get { return _data[index]; }
        set { _data[index] = value; }
    }

    public void RemoveAt(int index)
    {
        // 삭제하려는 대상 뒤에서 한칸씩 앞으로 떙겨주기
        for (int i = index; i < count - 1; i++)
        {
            _data[i] = _data[i + 1];
        }

        count--;
    }
}