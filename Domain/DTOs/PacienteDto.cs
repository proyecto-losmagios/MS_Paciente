using System;
using Domain.Entities;


namespace Domain.DTOs {

    public class PacienteDto {
        public string PacienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string ObraSocial { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}