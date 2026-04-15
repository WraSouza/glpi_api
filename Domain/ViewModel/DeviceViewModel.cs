namespace Domain.ViewModel
{
    public class DeviceViewModel(int id, string name, string serial, string otherserial)
    {
        public int Id { get; } = id;
        public string Name { get;  } = name;
        public string Serial { get;  } 
        public string Otherserial { get; } = otherserial;
    }
}
