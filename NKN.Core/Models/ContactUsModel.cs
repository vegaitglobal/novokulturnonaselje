using System.ComponentModel.DataAnnotations;

namespace NKN.Core.Models
{
    // TODO: multilingual support for error message. Hint: custom attrbiute
    public struct ContactUsModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}