using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

class Sender
{
    static void Main(string[] args)
    {
        int senderPort = int.Parse(args[0]);
        string receiverIP = args[1];
        int receiverPort = int.Parse(args[2]);
        string filename = args[3];

        UdpClient client = new UdpClient(senderPort);
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(receiverIP), receiverPort);

        // 🔹 1️⃣ SYN
        Packet syn = new Packet(0, 1, 1);
        client.Send(syn.ToBytes(), syn.ToBytes().Length, remoteEP);

        var anyEP = new IPEndPoint(IPAddress.Any, 0);
        Packet synAck = Packet.FromBytes(client.Receive(ref anyEP));

        // 🔹 2️⃣ ACK
        Packet ack = new Packet(1, 0, 2);
        ack.AckNum = synAck.SeqNum + 1;
        client.Send(ack.ToBytes(), ack.ToBytes().Length, remoteEP);

        Console.WriteLine("Connection Established!");

        // 🔹 파일 전송
        byte[] fileBytes = File.ReadAllBytes(filename);

        int seq = 3;
        int chunkSize = 1000;

        for (int i = 0; i < fileBytes.Length; i += chunkSize)
        {
            int size = Math.Min(chunkSize, fileBytes.Length - i);
            byte[] chunk = new byte[size];
            Array.Copy(fileBytes, i, chunk, 0, size);

            Packet dataPkt = new Packet(0, 0, seq++, chunk);
            client.Send(dataPkt.ToBytes(), dataPkt.ToBytes().Length, remoteEP);

            Console.WriteLine($"Sent DATA seq={dataPkt.SeqNum}");
        }

        // 🔹 FIN
        Packet fin = new Packet(0, 2, seq);
        client.Send(fin.ToBytes(), fin.ToBytes().Length, remoteEP);

        Console.WriteLine("File Sent. Connection Closed.");
        client.Close();
    }
}
