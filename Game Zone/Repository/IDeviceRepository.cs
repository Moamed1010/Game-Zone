namespace Game_Zone.Repository
{
    public interface IDeviceRepository
    {
        public List<Device> GetAll();
        public Device GetById(int id);
        public void Add(Device device);
        public void Remove(int id);
        public IEnumerable<SelectListItem> GetAllDevices();
    }
}
