using System.ComponentModel.DataAnnotations;

namespace Game_Zone.Models
{
    public class Category:BaseModel
    {
       
        public ICollection<Game> Games { get; set; } = new List<Game>();

    }
}
