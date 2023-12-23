using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Services
{
    public interface ILandingPageService
    {
        List<LandingPage> GetAllLandingPageSections();
        LandingPage GetSectionById(int id);
        LandingPage AddLandingPageSections(string section1, string section2);
        LandingPage GetLandingPageSectionsById(int id);
        int UpdateLandingPageSections(LandingPage sections);
        int DeleteLandingPageSections(LandingPage sections);

        Task<List<LandingPage>> LoadRandomSectionsAsync(int count);
        Task<List<LandingPage>> GetAllLandingPageSectionsAsync(CancellationToken cancellationToken = default);
        Task<LandingPage> GetSectionByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<LandingPage> AddLandingPageSectionsAsync(string section1, string section2, CancellationToken cancellationToken = default);
        Task<LandingPage> GetLandingPageSectionsByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> UpdateLandingPageSectionsAsync(LandingPage sections, CancellationToken cancellationToken = default);
        Task<int> DeleteLandingPageSectionsAsync(LandingPage sections, CancellationToken cancellationToken = default);
    }
}
