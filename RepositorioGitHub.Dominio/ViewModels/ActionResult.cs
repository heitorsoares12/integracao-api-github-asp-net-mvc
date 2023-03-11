using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Dominio
{
    public class ActionResult<TModel> where TModel: class
    {
        public ActionResult()
        {

        }

        public ActionResult(IList<TModel> results = null)
        {
            Results = results;
        }

        public ActionResult(TModel result = null)
        {
            Result = result;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
        public IList<TModel> Results { get; set; }

        public TModel Result { get; set; }
    }
}
