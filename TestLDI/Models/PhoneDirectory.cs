using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestLDI.Models
{
    public class PhoneDirectory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El {0} es requerido.")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [StringLength(160, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [Display(Name = "Nombre", Prompt = "Nombre")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El {0} es requerido.")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [StringLength(160, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [Display(Name = "Apellidos", Prompt = "Apellidos")]
        public string SurNames { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El {0} es requerido.")]
        [StringLength(260, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 2)]
        [EmailAddress(ErrorMessage = "El {0}, no es un email valido.")]
        [Display(Name = "Email", Prompt = "Email")]
        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El {0} es requerido.")]
        [Range(1, 9999)]
        [Phone(ErrorMessage = "El {0}, no es un Teléfono Fijo valido.")]
        [Display(Name = "Teléfono Fijo", Prompt = "Teléfono Fijo")]
        [DataType(dataType: DataType.Text)]
        public int Phone { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "El {0} es requerido.")]
        [Range(1, 9999)]
        [Phone(ErrorMessage = "El {0}, no es un Teléfono Fijo valido.")]
        [Display(Name = "Teléfono Fijo", Prompt = "Teléfono Fijo")]
        [DataType(dataType: DataType.Text)]
        public int CellPhone { get; set; }
    }
}
