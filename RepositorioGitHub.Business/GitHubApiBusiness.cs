using Newtonsoft.Json;
using RepositorioGitHub.Business.Contract;
using RepositorioGitHub.Dominio;
using RepositorioGitHub.Dominio.Interfaces;
using RepositorioGitHub.Infra.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace RepositorioGitHub.Business
{
    public class GitHubApiBusiness : IGitHubApiBusiness
    {
        private readonly IContextRepository _context;
        private readonly IGitHubApi _gitHubApi;
        public GitHubApiBusiness(IContextRepository context, IGitHubApi gitHubApi)
        {
            _context = context;
            _gitHubApi = gitHubApi;
        }

        public ActionResult<GitHubRepositoryViewModel> Get()
        {
            var listaRepositorios = new List<GitHubRepositoryViewModel>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.github.com/users/heitorsoares12/repos");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.UserAgent = "request";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var retorno = JsonConvert.DeserializeObject<List<GitHubRepositoryViewModel>>(reader.ReadToEnd());
                listaRepositorios = retorno;
            }

            return new ActionResult<GitHubRepositoryViewModel>(listaRepositorios);
        }

        public ActionResult<GitHubRepositoryViewModel> GetById(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.github.com/repos/heitorsoares12/{id}");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.UserAgent = "request";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var retorno = JsonConvert.DeserializeObject<GitHubRepositoryViewModel>(reader.ReadToEnd());

                return new ActionResult<GitHubRepositoryViewModel>(retorno);

            }
        }

        public ActionResult<GitHubRepositoryViewModel> GetByName(string name)
        {
            var listaRepositorios = new List<GitHubRepositoryViewModel>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.github.com/users/{name}/repos");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.UserAgent = "request";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var retorno = JsonConvert.DeserializeObject<List<GitHubRepositoryViewModel>>(reader.ReadToEnd());
                listaRepositorios = retorno;
            }

            return new ActionResult<GitHubRepositoryViewModel>(listaRepositorios);
        }

        public ActionResult<FavoriteViewModel> GetFavoriteRepository()
        {
            return new ActionResult<FavoriteViewModel>();
        }

        public ActionResult<GitHubRepositoryViewModel> GetRepository(string owner, string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.github.com/repos/{owner}/{id}");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.UserAgent = "request";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var retorno = JsonConvert.DeserializeObject<GitHubRepositoryViewModel>(reader.ReadToEnd());

                return new ActionResult<GitHubRepositoryViewModel>(retorno);
            }
        }

        public ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view)
        {
            return new ActionResult<FavoriteViewModel>();
        }
    }
}
