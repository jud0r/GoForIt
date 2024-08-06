namespace GoForIt
{
    public interface IDataBaseAccess
    {
        Device GetDevice(string deviceId);
    }

    public class DataBaseAccess : IDataBaseAccess
    {
        public DataBaseAccess() { }

        public Device GetDevice(string deviceId)
        {
            return new Device();
        }
    }

    public enum MonitorType
    {
        DeviceA,
        DeviceB
    }

    public class Device
    {
        public string? DeviceId { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastUsage { get; set; }
    }

    public interface IMonitor
    {
        bool IsMonitorNeeded(Device device);
    }

    public class DeviceAMonitor : IMonitor
    {
        public bool IsMonitorNeeded(Device device)
        {
            var lastUsage = DateTime.Now - device.LastUsage;
            return lastUsage.Seconds < 3000;
        }
    }

    public class DeviceBMonitor : IMonitor
    {
        public bool IsMonitorNeeded(Device device)
        {
            var lastUsage = DateTime.Now - device.LastUsage;
            return lastUsage.Seconds < 7000 && device.IsConnected;
        }
    }

    public static class MonitorFactory
    {
        public static IMonitor CreateMonitor(MonitorType monitorType)
        {
            switch (monitorType)
            {
                case MonitorType.DeviceA:
                    return new DeviceAMonitor();
                case MonitorType.DeviceB:
                    return new DeviceBMonitor();
                default:
                    throw new ArgumentException("MonitorType not supported");
            }
        }
    }

    public class MonitoringHelper
    {
        private readonly IDataBaseAccess _dataBaseAccess;

        public MonitoringHelper(IDataBaseAccess dataBaseAccess)
        {
            _dataBaseAccess = dataBaseAccess;
        }

        public bool IsMonitorNeeded(string deviceId, MonitorType monitorType) 
        { 
            var device = _dataBaseAccess.GetDevice(deviceId);
            var deviceMonitor = MonitorFactory.CreateMonitor(monitorType);
            return deviceMonitor.IsMonitorNeeded(device);
        }
    }
}
