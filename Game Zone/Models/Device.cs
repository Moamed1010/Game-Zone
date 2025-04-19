using System.ComponentModel.DataAnnotations;

namespace Game_Zone.Models
{
    public class Device : BaseModel
    {
      
        [MaxLength(50)]
        public string Icon { get; set; }


    }
}
