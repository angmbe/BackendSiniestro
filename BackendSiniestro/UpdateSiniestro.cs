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
    public static class UpdateSiniestro
    {
        [FunctionName("UpdateSiniestro")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "siniestro/{id}")] HttpRequest req,
            ILogger log, int id)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Siniestro> (requestBody);
            data.IdSiniestro = id;
            var sql = @"UPDATE Siniestro SET                        
                        NumeroIdentificacion = @NumeroIdentificacion, 
                        Nombres = @Nombres, 
                        Edad =@Edad, 
                        FechaSiniestro = @FechaSiniestro , 
                        IdTipoSiniestro = @IdTipoSiniestro,
                        IdParentesco = @IdParentesco, 
                        IdSexo = @IdSexo ,
                        IdDepartamento = @IdDepartamento, 
                        IdEstadoSiniestro = @IdEstadoSiniestro
                    WHERE IdSiniestro = @IdSiniestro";
            var connectionString = Environment.GetEnvironmentVariable("SqlConnection");
            using var connection = new SqlConnection(connectionString);
            var affected = await connection.ExecuteAsync(sql, data);
            return new OkObjectResult(new { mensaje = "Siniestro Actualizado", filas = affected });
        }
    }
}
