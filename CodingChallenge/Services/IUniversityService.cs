using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public interface IUniversityService
    {
        Task<IList<University>> GetUniversitiesAsync();
    }
}
