using System;
using System.Threading.Tasks;

namespace FawzyApp.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetListAsync<TResult>(string uri, string token = "");
        Task<TResult> GetOneAsync<TResult>(string uri, Guid id, string token = "");
        Task<TResult> PostOneAsync<TResult, Take>(Take data, string uri, string token = "");
        Task<TResult> DeleteOneAsync<TResult>(Guid id, string uri, string token = "");
    }
}