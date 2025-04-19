namespace Game_Zone.Attributes
{
    public class AllowedExtentions : ValidationAttribute
    {
        private readonly string _allowedExtentions;

        public AllowedExtentions(string alloedExtentions)
        {
            _allowedExtentions = alloedExtentions;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extention = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtentions.Split(',')
                    .Contains(extention, StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtentions} are allowed");


                }


            }
            return ValidationResult.Success;

        }
    }
}
