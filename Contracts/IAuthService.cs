using BackendExam.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendExam.Contracts
{
    public interface IAuthService
    {
        Task<Boolean> Register([FromBody] RegisterModel model);
        string Authenticate(string email, string password);
    }
}
