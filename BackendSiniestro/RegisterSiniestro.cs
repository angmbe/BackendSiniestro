using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BackendSiniestro.Models;
using System.Data.SqlClient;
using Dapper;

namespace BackendSiniestro
{
    public static class RegisterSiniestro
    {
        [FunctionName("CreateSiniestro")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "siniestro")] HttpRequest req,
            ILogger log)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Siniestro>(requestBody);
            var connectionString = Environment.GetEnvironmentVariable("SqlConnection");

            var sql = @"
                    INSERT INTO Siniestro(
                        IdSiniestro, NumeroIdentificacion, Nombres , Edad , FechaSiniestro , IdTipoSiniestro ,
                        IdParentesco, IdSexo ,IdDepartamento , IdEstadoSiniestro) VALUES (
                        @IdSiniestro, @NumeroIdentificacion, @Nombres , @Edad , @FechaSiniestro , @IdTipoSiniestro ,
                        @IdParentesco, @IdSexo , @IdDepartamento , @IdEstadoSiniestro)";

            using var connection = new SqlConnection(connectionString);
            var rows = await connection.ExecuteAsync(sql, data);
            return new OkObjectResult(new {mensaje = "Siniestro creado con exito", filas = rows});            
        }
    }
}
