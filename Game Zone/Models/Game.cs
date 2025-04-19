namespace Game_Zone.Models
{
    public class Game : BaseModel
    {
        
        [MaxLength(2500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Cover { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }



        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
