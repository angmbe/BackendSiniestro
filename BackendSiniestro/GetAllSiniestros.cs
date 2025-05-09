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
using System.Linq;

namespace BackendSiniestro
{
    public static class GetAllSiniestros
    {
        [FunctionName("GetSiniestros")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "siniestro")] HttpRequest req,
            ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlConnection");
            using var connection = new SqlConnection(connectionString);
            var query = "SELECT * FROM Siniestro";
            var siniestros = (await connection.QueryAsync<Siniestro>(query)).ToList();
            return new OkObjectResult(siniestros);
        }
    }
}
