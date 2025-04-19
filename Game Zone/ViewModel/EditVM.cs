namespace Game_Zone.ViewModel
{
    public class EditVM: GameFormVM
    {
        public int Id { get; set; }
        public string? CurrentCover {  get; set; } 
        
        [AllowedExtentions(FileSettings.AllowedExtentions),
          MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; }
    }
}
