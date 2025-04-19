

namespace Game_Zone.ViewModel
{
    public class CreateVM: GameFormVM
    {
        

        [AllowedExtentions(FileSettings.AllowedExtentions),
          MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; }



    }
}
