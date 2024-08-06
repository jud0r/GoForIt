
namespace Application
{
    // Interface for database access
    public interface IDatabaseAccess
    {
        Device GetDevice(string deviceId);
    }

    // Concrete implementation of IDatabaseAccess
    public class DatabaseAccess : IDatabaseAccess
    {
        public DatabaseAccess() { }

        public Device GetDevice(string deviceId)
        {
            // Database retrieval logic
            return new Device();
        }
    }

    // Interface for monitoring behavior
    public interface IMonitor
    {
        bool IsMonitorNeeded(string deviceId);
    }

    // Abstract base class for monitors
    public abstract class MonitorBase : IMonitor
    {
        public readonly IDatabaseAccess Database;

        protected MonitorBase(IDatabaseAccess database)
        {
            Database = database;
        }

        public abstract bool IsMonitorNeeded(string deviceId);
    }

    // Concrete monitor for DeviceA
    public class MonitorDeviceA : MonitorBase
    {
        public MonitorDeviceA(IDatabaseAccess database) : base(database) { }

        public override bool IsMonitorNeeded(string deviceId)
        {
            var device = Database.GetDevice(deviceId);
            var lastUsage = DateTime.Now - device.LastUsage;
            return lastUsage.Seconds < 3000;
        }
    }

    // Concrete monitor for DeviceB
    public class MonitorDeviceB : MonitorBase
    {
        public MonitorDeviceB(IDatabaseAccess database) : base(database) { }

        public override bool IsMonitorNeeded(string deviceId)
        {
            var device = Database.GetDevice(deviceId);
            var lastUsage = DateTime.Now - device.LastUsage;
            return lastUsage.Seconds < 7000 && device.IsConnected;
        }
    }

    // Example device class
    public class Device
    {
        public string DeviceId { get; set; }
        public DateTime LastUsage { get; set; }
        public bool IsConnected { get; set; }
    }
}
