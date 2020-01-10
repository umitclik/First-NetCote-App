using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogNews.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenericCreateController : ControllerBase
    {


        // GET api/values
        [HttpGet]
        public bool CreateCode()
        {
            string classModelName = "User";
            //CreateReadmeNotes(classModelName);
            //CreteBusinessAbstractRepository(classModelName);
            //CreteBusinessConcrateRepository(classModelName);
            //CreateController(classModelName);

            return true;
        }


        private bool CreateReadmeNotes(string classModelName)
        {

            var content = "\n\n1.Startup.cs > ConfigureServices  ekle: " +
                "\n\nservices.AddTransient<I" + classModelName + "Repository, Ef" + classModelName + "Repository>()";
            string path = Environment.CurrentDirectory;
            using (StreamWriter file = new StreamWriter(path + "\\Controllers\\" + "readme.txt"))
            {
                file.WriteLine(content);
            }

            return true;
        }

        private bool CreateController(string classModelName)
        {
            var content = CreateControllerContent(classModelName);
            string path = Environment.CurrentDirectory;
            using (StreamWriter file = new StreamWriter(path + "\\Controllers\\" + classModelName + "Controller.cs"))
            {
                file.WriteLine(content);// "Console.WriteLine(\"It worked\")");
            }
            return true;

        }

        private string CreateControllerContent(string classModelName)
        {

            string lowerTxt = classModelName.First().ToString().ToLower() + classModelName.Substring(1);
            string upperTxt = classModelName.First().ToString().ToUpper() + classModelName.Substring(1);
            String returnVal = string.Format(@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogNews.Api.Controllers
{{
    [Route(""api/[controller]/[action]"")]
    [ApiController]
    public class {0}Controller : ControllerBase
    {{
        private I{0}Repository {1}Repository;
        public {0}Controller(I{0}Repository _{1}Repository)
        {{
            {1}Repository = _{1}Repository;
        }}
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<{0}>>> Get()
        {{
            var query = {1}Repository.GetAll();
            var s = await query.ToAsyncEnumerable().ToList();
            return s;
        }}

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<{0}>> GetAllAsync()
        {{
            var s = await {1}Repository.GetAllAsync();
            return s;

        }}

        [HttpPost]
        public async Task<int> Add({0} {1})
        {{
            {1}Repository.Add({1});
            var res = await {1}Repository.Save();
            return res;
        }}



        [HttpPost]
        public async Task<int> Delete({0} {1})
        {{
            {1}Repository.Delete({1});
            var res = await {1}Repository.Save();
            return res;
        }}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<{0}>> GetByDeneme()
        {{
            var query = {1}Repository.GetAll();
            //var sonuc = await query.ToList();
            return {1}Repository.GetAll().ToList();
        }}
    }}
}}
 ", upperTxt, lowerTxt);

            return returnVal;
        }

        private bool CreteBusinessAbstractRepository(string classModelName)
        {
            var content = CreteBusinessAbstractRepositoryContent(classModelName);
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));


            using (StreamWriter file = new StreamWriter(newPath + "\\BlogNews.Business\\Abstract\\I" + classModelName + "Repository.cs"))
            {
                file.WriteLine(content);// "Console.WriteLine(\"It worked\")");
            }
            return true;
        }
        

        private bool CreteBusinessConcrateRepository(string classModelName)
        {
            var content = CreteBusinessConcrateRepositoryContent(classModelName);
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"..\"));


            using (StreamWriter file = new StreamWriter(newPath + "\\BlogNews.Business\\Concrete\\Ef" + classModelName + "Repository.cs"))
            {
                file.WriteLine(content);// "Console.WriteLine(\"It worked\")");
            }
            return true;
        }

        private string CreteBusinessAbstractRepositoryContent(string classModelName)
        {
            string lowerTxt = classModelName.First().ToString().ToLower() + classModelName.Substring(1);
            string upperTxt = classModelName.First().ToString().ToUpper() + classModelName.Substring(1);

            String returnVal = string.Format(@"using BlogNews.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNews.Business.Abstract
{{
    public interface I{0}Repository : IGenericRepository<{0}>
    {{
    }}
}}
", upperTxt);

            return returnVal;
        }

        private string CreteBusinessConcrateRepositoryContent(string classModelName)
        {
            string lowerTxt = classModelName.First().ToString().ToLower() + classModelName.Substring(1);
            string upperTxt = classModelName.First().ToString().ToUpper() + classModelName.Substring(1);

            String returnVal = string.Format(@"using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNews.Business.Concrete
{{
    public class Ef{0}Repository : EfGenericRepository<{0}>, I{0}Repository
    {{
        public Ef{0}Repository(blogContext context) : base(context)
        {{
        }}
    }}
}}
", upperTxt);

            return returnVal;
        }
    }
}