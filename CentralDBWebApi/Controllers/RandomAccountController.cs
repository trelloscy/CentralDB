using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Belgrade.SqlClient;

namespace CentralDBWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/RandomAccount")]
    public class RandomAccountController : Controller
    {
        private readonly IQueryPipe SqlPipe;
        private readonly ICommand SqlCommand;

        public RandomAccountController(ICommand sqlCommand, IQueryPipe sqlPipe)
        {
            this.SqlCommand = sqlCommand;
            this.SqlPipe = sqlPipe;
        }

        // GET api/Todo
        [HttpGet]
        public async Task Get()
        {
            //await SqlPipe.Stream("select * from CommonAccounts FOR JSON PATH", Response.Body, "[]");
            await SqlPipe.Stream("GetRandomCommonAccount", Response.Body, "[]");
        }
    }
}