﻿namespace DesignPattern.Structural;

/// <summary>
///  A proxy is a wrapper or agent object that is being called by the client to
/// access the real serving object behind the scenes. Use of the proxy can simply be
/// forwarding to the real object, or can provide additional logic.
/// </summary>
public abstract class Proxy
{
    internal interface ISensitiveData
    {
        void AccessData();
    }

    private class RealSensitiveData : ISensitiveData
    {
        public void AccessData()
        {
            Console.WriteLine("Accessing sensitive data...");
        }
    }

    internal class SensitiveDataProxy : ISensitiveData
    {
        private readonly RealSensitiveData _realSensitiveData;
        private readonly string _userRole;

        internal SensitiveDataProxy(string userRole)
        {
            _userRole = userRole;
            _realSensitiveData = new RealSensitiveData();
        }

        public void AccessData()
        {
            if (_userRole == "Admin")
            {
                _realSensitiveData.AccessData();
            }
            else
            {
                Console.WriteLine("Access denied. Insufficient privileges.");
            }
        }
    }
}