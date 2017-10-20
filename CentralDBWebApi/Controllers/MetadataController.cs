using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Belgrade.SqlClient;
using System.IO;
using System.Data.SqlClient;

namespace CentralDBWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Metadata")]
    public class MetadataController : Controller
    {
        private readonly IQueryPipe SqlPipe;
        private readonly ICommand SqlCommand;

        public MetadataController(ICommand sqlCommand, IQueryPipe sqlPipe)
        {
            this.SqlCommand = sqlCommand;
            this.SqlPipe = sqlPipe;
        }

        //Tutorial: https://www.codeproject.com/Articles/1106622/Building-REST-services-with-ASP-NET-Core-Web-API-a

        // PUT api/Metadata/{searchTerm}
        [HttpGet("{searchTerm}")]
        public async Task Get(string searchTerm)
        {
            var cmd = new SqlCommand(
                @"INSERT INTO SearchTerms([Search Term]) VALUES (@searchTerm)"
            );
            cmd.Parameters.AddWithValue("searchTerm", searchTerm);

            await SqlCommand.ExecuteNonQuery(cmd);
        }
        
        // POST api/Metadata
        [HttpPost]
        public async Task Post()
        {
            string data = new StreamReader(Request.Body).ReadToEnd();

            var cmd = new SqlCommand("InsertSearchTermsJSON");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@data", data));

            await SqlCommand.ExecuteNonQuery(cmd);
        }
    }
}