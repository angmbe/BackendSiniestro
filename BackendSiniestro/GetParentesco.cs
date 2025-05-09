using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BackendSiniestro.Interface;
using BackendSiniestro.Models;

namespace BackendSiniestro
{
    public class GetParentesco
    {
        private readonly IRepository<Parentesco> _repo;

        public GetParentesco (IRepository<Parentesco> repo)
        {
            _repo = repo;
        }

        [FunctionName("GetParentesco")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "parentesco")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var list = await _repo.GetAllAsync("Parentesco");
                return new OkObjectResult(list);
            }catch(Exception ex)
            {
                return new BadRequestObjectResult($"Error al obtener el tipo de Prentesco: {ex.Message}");
            }
        }
    }
}
