
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain.DTOs;
using Domain.Queries;


namespace AccessData.Queries {

    public class PacienteQuery : IPacienteQuery {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public PacienteQuery(IDbConnection connection, Compiler sqlKataCompiler) {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<PacienteDto> SearchPaciente(string search_q) {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Pacientes")
                .Select("PacienteId",
                        "Nombre",
                        "Apellido",
                        "Email",
                        "ObraSocial",
                        "FechaNacimiento")
                .When(!string.IsNullOrWhiteSpace(search_q), q => q
                    .WhereLike("Nombre", $"%{search_q}%")
                    .OrWhereLike("Apellido", $"%{search_q}%")
                    );

            var result = query.Get<PacienteDto>();

            return result.ToList();
        }
        
        public List<PacienteDto> GetPacienteByEmail(string email) {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Pacientes")
                .Select("PacienteId",
                        "Nombre",
                        "Apellido",
                        "Email",
                        "ObraSocial",
                        "FechaNacimiento")
                .WhereLike("Email", $"%{email}%");

            var result = query.Get<PacienteDto>();

            return result.ToList();
        }

    }
}