namespace Domain.Entities
{
    public class DeviceInfo
    {
        public int id { get; set; }
        public int entities_id { get; set; }
        public string itemtype { get; set; }
        public int items_id { get; set; }
        public string name { get; set; }
        public string device { get; set; }
        public string mountpoint { get; set; }
        public int filesystems_id { get; set; }
        public int totalsize { get; set; }
        public int freesize { get; set; }
        public int is_deleted { get; set; }
        public int is_dynamic { get; set; }
        public int encryption_status { get; set; }
        public string encryption_tool { get; set; }
        public string encryption_algorithm { get; set; }
        public object encryption_type { get; set; }
        public string date_mod { get; set; }
        public string date_creation { get; set; }
      
    }
}
