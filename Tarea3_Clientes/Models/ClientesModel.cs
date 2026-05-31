using System;
using System.ComponentModel.DataAnnotations;

namespace Tarea3_Clientes.Models
{
    // Opcional pero recomendado: Enum para restringir el tipo de identificación
    public enum TipoIdentificacion
    {
        Cedula,
        RUC,
        Pasaporte
    }

    public class ClientesModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de identificación")]
        [Required(ErrorMessage = "El tipo de identificación es requerido")]
        public TipoIdentificacion Id_Tributaria { get; set; }

        [Display(Name = "Número de cédula o RUC")]
        [Required(ErrorMessage = "El número de identificación es requerido")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "El número de identificación debe tener entre 10 y 13 dígitos")]
        [RegularExpression(@"^[0-7:\d]*$", ErrorMessage = "El campo solo permite dígitos numéricos")]
        public string Num_Identificacion { get; set; }

        [Display(Name = "Nombre del cliente o Razón Social")]
        [Required(ErrorMessage = "El nombre o razón social es requerido")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres")]
        public string Razon_Social { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(200, ErrorMessage = "La dirección es muy larga")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?[\d\s-]+$", ErrorMessage = "El formato del teléfono no es válido")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public string Correo { get; set; }

        [Display(Name = "Código Postal")]
        [StringLength(10, ErrorMessage = "El código postal no puede exceder los 10 caracteres")]
        public string Codigo_Postal { get; set; }

        [Display(Name = "¿Tiene Crédito?")]
        public bool Tiene_Credito { get; set; } 

        [Display(Name = "Fecha de Creación")]
        public DateTime Creacion { get; set; } = DateTime.Now;
    }
}