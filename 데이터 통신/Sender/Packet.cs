using System;
using System.Text;

public class Packet
{
    public int Type;   // 0=DATA, 1=ACK
    public int Flag;   // 0=NONE, 1=SYN, 2=FIN
    public int SeqNum;
    public int AckNum;
    public int Length;
    public byte[] Data;

    public Packet(int type, int flag, int seqNum, byte[] data = null)
    {
        Type = type;
        Flag = flag;
        SeqNum = seqNum;
        Data = data ?? new byte[0];
        Length = Data.Length;
        AckNum = 0;
    }

    public byte[] ToBytes()
    {
        string header = $"{Type}|{Flag}|{SeqNum}|{AckNum}|{Length}|";
        byte[] headerBytes = Encoding.UTF8.GetBytes(header);

        byte[] packet = new byte[headerBytes.Length + Data.Length];
        Buffer.BlockCopy(headerBytes, 0, packet, 0, headerBytes.Length);
        Buffer.BlockCopy(Data, 0, packet, headerBytes.Length, Data.Length);

        return packet;
    }

    public static Packet FromBytes(byte[] bytes)
    {
        string msg = Encoding.UTF8.GetString(bytes);
        string[] parts = msg.Split('|', 6);

        Packet pkt = new Packet(
            int.Parse(parts[0]),
            int.Parse(parts[1]),
            int.Parse(parts[2])
        );

        pkt.AckNum = int.Parse(parts[3]);
        pkt.Length = int.Parse(parts[4]);

        int headerLength = Encoding.UTF8.GetBytes(
            $"{parts[0]}|{parts[1]}|{parts[2]}|{parts[3]}|{parts[4]}|"
        ).Length;

        pkt.Data = new byte[pkt.Length];
        Buffer.BlockCopy(bytes, headerLength, pkt.Data, 0, pkt.Length);

        return pkt;
    }
}
