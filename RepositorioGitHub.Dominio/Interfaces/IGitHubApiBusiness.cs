
using RepositorioGitHub.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioGitHub.Business.Contract
{
   public interface IGitHubApiBusiness
   {
        ActionResult<GitHubRepositoryViewModel> Get();
        ActionResult<GitHubRepositoryViewModel> GetByName(string name);
        ActionResult<GitHubRepositoryViewModel> GetById(string id);
        ActionResult<GitHubRepositoryViewModel> GetRepository(string owner, string id);
        ActionResult<FavoriteViewModel> GetFavoriteRepository();
        ActionResult<FavoriteViewModel> SaveFavoriteRepository(FavoriteViewModel view);
   }
}
