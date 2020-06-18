using Domain.Commands;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Queries;


namespace Application.Services {

    public interface IPacienteServices {
        Paciente CreatePaciente(PacienteDto paciente);
        List<PacienteDto> SearchPaciente(string q);
    }

    public class PacienteServices : IPacienteServices {

        private readonly IGenericsRepository _repository;
        private readonly IPacienteQuery _query;

        public PacienteServices(IGenericsRepository repository, IPacienteQuery query) {
            _repository = repository;
            _query = query;
            
        }

        public Paciente CreatePaciente(PacienteDto paciente) {
            var entity = new Paciente {
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Email = paciente.Email,
                ObraSocial = paciente.ObraSocial,
                FechaNacimiento = paciente.FechaNacimiento

            };

            _repository.Add<Paciente>(entity);

            return entity;
        }
               
        public List<PacienteDto> SearchPaciente(string q) {
           return  _query.SearchPaciente(q);
        }
    }
}