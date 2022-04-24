﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domino_55
{
    internal class Z21
    {
        private static Z21 instance = null;
        private static readonly object padlock = new object();

        public static Z21 Instance { 
            get 
            { 
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Z21();
                    }
                    return instance;
                }
            } 
        }

        private string host = "192.168.1.30";
        private const int port = 21105;

        private void sendMessage(byte[] message)
        {
            try
            {
                using (var client = new UdpClient())
                {
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(host), port);
                    client.Connect(ep);
                    client.Send(message, message.Length);
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private byte[] addXOR(byte[] data)
        {
            byte[] result = new byte[data.Length + 1];
            Array.Copy(data, result, data.Length);
            byte xor = 0;
            foreach (byte item in data)
            {
                xor = (byte)(xor ^ item);
            }
            result[result.Length - 1] = xor;
            return result;
        }

        public void loconetSetSensor(byte address, bool sensor)
        {
            byte IN2;
            //byte[] loconetData = { 0xb2, 0x01, 0b01010000, 0xe3 };
            if (sensor)
                IN2 = 0b01010000;
            else
                IN2 = 0b01000000;
            byte[] data = { 0x04 + 4, 0x00, 0xa2, 0x00, 0xb2, (byte)(address), IN2, 0xe3 };
            sendMessage(data);
        }

        public void setSpeed(int address, byte speed, bool forward)
        {
            byte speedbyte;
            if (forward)
                speedbyte = (byte)(0x80 + speed);
            else
                speedbyte = speed;
            byte[] data = { 0x0a, 0x00, 0x40, 0x00, 0xe4, 0x13, 0x00, (byte)address, speedbyte };
            data = addXOR(data);
            sendMessage(data);
        }

        public void setTurnoutStraight(byte address)
        {
            byte[] data = { 0x09, 0x00, 0x40, 0x00, 0x53, 0x00, (byte)(address - 1), 0b10001001, 0x00 };
            data = addXOR(data);
            sendMessage(data);

            Thread.Sleep(200);

            byte[] data2 = { 0x09, 0x00, 0x40, 0x00, 0x53, 0x00, (byte)(address - 1), 0b10000001, 0x00 };
            data2 = addXOR(data2);
            sendMessage(data2);
        }

        public void setTurnoutBranch(byte address)
        {
            byte[] data = { 0x09, 0x00, 0x40, 0x00, 0x53, 0x00, (byte)(address - 1), 0b10001000, 0x00 };
            data = addXOR(data);
            sendMessage(data);

            Thread.Sleep(200);

            byte[] data2 = { 0x09, 0x00, 0x40, 0x00, 0x53, 0x00, (byte)(address - 1), 0b10000000, 0x00 };
            data2 = addXOR(data2);
            sendMessage(data2);
        }

        public void stop()
        {
            byte[] data = { 0x06, 0x00, 0x40, 0x00, 0x80, 0x80 };
            sendMessage(data);
        }
    }
}
