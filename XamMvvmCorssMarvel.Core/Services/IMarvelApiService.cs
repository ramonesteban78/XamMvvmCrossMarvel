using System;
using XamMvvmCorssMarvel.Core.Models;
using System.Threading.Tasks;

namespace XamMvvmCorssMarvel.Core.Services
{
	public interface IMarvelApiService
	{
		Task<MarvelApiData<Characters>> GetCharacters (string filter = null, int limit = 0, int offset = 0);
	}
}

