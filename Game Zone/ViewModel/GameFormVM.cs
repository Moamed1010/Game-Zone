namespace Game_Zone.ViewModel
{
    public class GameFormVM
    {


        public string Name { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public List<int> SelectedDevices { get; set; }

        [Display(Name = "Categories")]
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();


        public IEnumerable<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
    }
}
