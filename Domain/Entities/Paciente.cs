using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities {

    public class Paciente {
        public int PacienteId { get; set; }
        [StringLengthAttribute(64)]
        [Required]
        public string Nombre { get; set; }
        [StringLengthAttribute(64)]
        [Required]
        public string Apellido { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLengthAttribute(128)]
        public string ObraSocial { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
}