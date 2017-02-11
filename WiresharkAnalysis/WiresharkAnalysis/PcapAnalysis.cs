using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanAirdrop
{
    public static class PcapAnalysis
    {
        static int m_packetNumber = 0;

        public static void ReadFile(string fileLocation)
        {
            // Create the offline device
            OfflinePacketDevice selectedDevice = new OfflinePacketDevice(fileLocation);


            int readWholePacket = 65536;            // 65536 guarantees that the whole packet will be captured on all the link layers
            int readTimeOut = 1000;                 // read timeout

            using (PacketCommunicator communicator = selectedDevice.Open(readWholePacket, PacketDeviceOpenAttributes.Promiscuous, readTimeOut))
            {
                communicator.ReceivePackets(0, IncommingPacketHandler);
            }

        }

        private static void IncommingPacketHandler(Packet packet)
        {
            // This function will get called for every packet in the .pcap file! 

            m_packetNumber++;

            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);

            ////////////////////////////////////////////////////////////////////////////////////////////
            // Example filtering and inspection of each packet goes here!

            var testIP = new IpV4Address("10.1.1.1");

            if (packet.Ethernet.IpV4.Tcp.IsReset == true)
            {
                // do something   
            }

            if (packet.Ethernet.IpV4.Tcp.ControlBits.HasFlag(PcapDotNet.Packets.Transport.TcpControlBits.Acknowledgment) == true &&
                packet.Ethernet.IpV4.Tcp.ControlBits.HasFlag(PcapDotNet.Packets.Transport.TcpControlBits.Push) == true)
            {

            }

            if (packet.Ethernet.IpV4.Tcp.IsReset == false)
            {

            }


            if (packet.Ethernet.IpV4.Source == testIP)
            {

            }

            Console.WriteLine();
        }
    }



}
