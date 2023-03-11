using RepositorioGitHub.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Dominio
{
    public class RepositoryViewModel
    {     
        public long TotalCount { get; set; }

        public GitHubRepository[] Repositories { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Full_name { get; set; }

        public Owner Owner { get; set; }

        public string Description { get; set; }
    }
}
