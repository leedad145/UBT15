using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

class Receiver
{
    static void Main(string[] args)
    {
        int port = int.Parse(args[0]);

        UdpClient server = new UdpClient(port);
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

        Console.WriteLine("Receiver started...");

        // 🔹 SYN 수신
        Packet syn = Packet.FromBytes(server.Receive(ref remoteEP));

        Packet synAck = new Packet(1, 1, 1000);
        synAck.AckNum = syn.SeqNum + 1;
        server.Send(synAck.ToBytes(), synAck.ToBytes().Length, remoteEP);

        Packet ack = Packet.FromBytes(server.Receive(ref remoteEP));

        Console.WriteLine("Connection Established!");

        // 🔹 파일 생성 (덮어쓰기)
        using (FileStream fs = new FileStream("received_file", FileMode.Create))
        {
            while (true)
            {
                Packet pkt = Packet.FromBytes(server.Receive(ref remoteEP));

                if (pkt.Flag == 2) // FIN
                {
                    Console.WriteLine("FIN received. Closing.");
                    break;
                }

                if (pkt.Type == 0)
                {
                    fs.Write(pkt.Data, 0, pkt.Length);
                    Console.WriteLine($"Received DATA seq={pkt.SeqNum}");
                }
            }
        }

        server.Close();
    }
}
