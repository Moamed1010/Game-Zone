namespace Game_Zone.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }

    }
}
