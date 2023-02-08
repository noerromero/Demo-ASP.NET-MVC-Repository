using System.ComponentModel.DataAnnotations;

namespace AtencionClienteMVC.ViewModel
{
    public class PostCustomerSupportRequestViewModel
	{
        public Guid Id { get; set; }

		[Required(ErrorMessage ="Nombre es requerido")]
        [MaxLength(30, ErrorMessage ="El nombre debe tener 30 caracteres como máximo")]
		public string? Name { get; set; } 

        [Required(ErrorMessage ="Apellidos es requerido")]
        [MaxLength(60, ErrorMessage ="El apellido debe tener 60 caracteres como máximo")]
        public string? LastName { get; set; } 

        [Required(ErrorMessage ="Nro. celular es requerido")]
        public string? Mobile { get; set; } 

        [Required(ErrorMessage ="Email es requerido")]
        [EmailAddress(ErrorMessage ="Formato de email incorrecto")]
        [MaxLength(100, ErrorMessage ="El email debe tener 100 caracteres como máximo")]
        public string? Email { get; set; } 

        [Required(ErrorMessage ="Sexo es requerido")]
        public int? Gender { get; set; } 

        [Required(ErrorMessage = "Motivo es requerido")]
        public int? Reason { get; set; } 

        public DateTime? ContactDate { get; set; }
        
	}
}

