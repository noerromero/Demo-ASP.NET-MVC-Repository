
using System;
using System.ComponentModel.DataAnnotations;

namespace AtencionClienteMVC.ViewModel
{
	public class CustomerSupportViewModel
	{
        public Guid Id { get; set; }

		[Required(ErrorMessage ="Nombre es requerido")]
        [MaxLength(30, ErrorMessage ="El nombre debe tener 30 caracteres como máximo")]
		public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Apellidos es requerido")]
        [MaxLength(60, ErrorMessage ="El apellido debe tener 60 caracteres como máximo")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Nro. celular es requerido")]
        public string Mobile { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email es requerido")]
        [EmailAddress(ErrorMessage ="Formato de email incorrecto")]
        [MaxLength(100, ErrorMessage ="El email debe tener 100 caracteres como máximo")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Sexo es requerido")]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Motivo es requerido")]
        public String Reason { get; set; } = string.Empty;

        public DateTime ContactDate { get; set; }
        
	}
}

