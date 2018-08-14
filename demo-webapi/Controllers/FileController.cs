using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_webapi.Controllers
{
    [Route("api/File")]
    public class FileController : Controller
    {
        // GET api/values
        [HttpPost]
        public string Post(IFormFile file)
        {
            return file.FileName;
        }
    }
}
