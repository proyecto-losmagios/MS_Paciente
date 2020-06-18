
using System.Collections.Generic;
using Domain.DTOs;


namespace Domain.Queries {

    public interface IPacienteQuery {
        List<PacienteDto> SearchPaciente(string q); 
    }

}