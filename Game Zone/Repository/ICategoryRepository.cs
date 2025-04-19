namespace Game_Zone.Repository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();

        public Category GetById(int id);

        public void Add(Category category);
        public void Remove(int id);
        public IEnumerable<SelectListItem> GetAllCategories();

    }
}
