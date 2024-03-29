﻿namespace DesignPattern.Structural;

/// <summary>
/// The adapter pattern is a software design pattern that allows the interface of an existing class
/// to be used as another interface. It is often used to make existing classes work with others without
/// modifying their source code.
/// </summary>
public abstract class Adapter
{
    internal interface IPersianSocket
    {
        void Connect();
    }

    internal class EuropeanSocket
    {
        public void PlugIn()
        {
            Console.WriteLine("European device is plugged in.");
        }
    }

    internal class SocketAdapter : IPersianSocket
    {
        private readonly EuropeanSocket _europeanSocket;

        public SocketAdapter(EuropeanSocket europeanSocket)
        {
            _europeanSocket = europeanSocket;
        }

        public void Connect()
        {
            Console.WriteLine("Adapter: Converting European Socket to Persian Socket.");
            _europeanSocket.PlugIn();
        }
    }
}