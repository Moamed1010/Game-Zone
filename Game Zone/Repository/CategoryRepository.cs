using Game_Zone.Data;


namespace Game_Zone.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        public ApplicationDbContext Context { get; }
        public CategoryRepository(ApplicationDbContext context)
        {
            Context = context;

        }

        public List<Category> GetAll()
        {
            
           return  Context.Categories.ToList();
        }

        public Category GetById(int id)
        {
           return Context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {

            var category = Context.Categories.FirstOrDefault(e => e.Id == id);
            if (category != null)
            {
                Context.Categories.Remove(category);
                Context.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetAllCategories() {


            return Context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text).AsNoTracking().ToList();
        }
        
    }
}
