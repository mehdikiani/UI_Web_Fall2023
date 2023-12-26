using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Services
{
    public interface ISectionService
    {
        List<Section> GetAllSections();
        Section AddSection(string title, bool isActive);
        Section GetSectionById(int id);
        int UpdateSection(Section section);
        int DeleteSection(Section section);

        Task<List<Section>> GetAllSectionsAsync(CancellationToken cancellationToken =default);
        Task<Section> AddSectionAsync(string title, bool isActive,CancellationToken cancellationToken=default);
        Task<Section> GetSectionByIdAsync(int id,CancellationToken cancellationToken=default);
        Task<int> UpdateSectionAsync(Section section,CancellationToken cancellationToken =default);
        Task<int> DeleteSectionAsync(Section section,CancellationToken cancellationToken =default);
    }
}
