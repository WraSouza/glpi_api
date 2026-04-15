namespace Domain.ViewModel
{
    public class DeviceInfoViewModel
    {
        public DeviceInfoViewModel()
        {
            
        }

        public DeviceInfoViewModel(int totalsize, int freesize)
        {
            this.totalsize = totalsize;
            this.freesize = freesize;
        }

        public int totalsize { get; set; }
        public int freesize { get; set; }
    }
}
