using Game_Zone.Data;


namespace Game_Zone.Repository
{
    public class DeviceRepository : IDeviceRepository
    {

        public ApplicationDbContext Context { get; }
        public DeviceRepository(ApplicationDbContext context)
        {
            Context = context;

        }

        public List<Device> GetAll()
        {

            return Context.Devices.ToList();
        }

        public Device GetById(int id)
        {
            return Context.Devices.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Device device)
        {
            Context.Devices.Add(device);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {

            var device = Context.Categories.FirstOrDefault(e => e.Id == id);
            if (device != null)
            {
                Context.Categories.Remove(device);
                Context.SaveChanges();
            }
        }
       
        public IEnumerable<SelectListItem> GetAllDevices()
        {
            return Context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text).AsNoTracking().ToList();
        }
    }
}


