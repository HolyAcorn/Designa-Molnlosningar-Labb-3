using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsFFGBookAPI
{
    public class OutputBook
    {
        [SqlOutput("dbo.Books", connectionStringSetting: "SqlConnectionString")]
        public Book Book { get; set; }
        public  HttpResponseData HttpResponse { get; set; }
    }
}
