using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Data;
using static System.Collections.Specialized.BitVector32;

namespace Ticketing.Services
{
    public class LandingPageService : ILandingPageService
    {
        private readonly IRepository<LandingPage> _repository;
        private readonly ILogSerivce logSerivce;

        public LandingPageService(IRepository<LandingPage> repository, ILogSerivce logSerivce)
        {
            this._repository = repository;
            this.logSerivce = logSerivce;
        }
        public async Task<List<LandingPage>> LoadRandomSectionsAsync(int count)
        {
            return await _repository.GetRandomRow(count).ToListAsync();
        }
        public List<LandingPage> GetAllLandingPageSections()
        {
            return _repository.GetAll().ToList();
        }
        public async Task<List<LandingPage>> GetAllLandingPageSectionsAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetAll().ToListAsync();
        }
        public LandingPage GetSectionById(int id)
        {
            return _repository.GetAll()
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<LandingPage> GetSectionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetAll()
                 .FirstOrDefaultAsync(p => p.Id == id);
        }
        public LandingPage AddLandingPageSections(string section1, string section2)
        {
            if (string.IsNullOrWhiteSpace(section1))
                throw new ArgumentNullException(nameof(section1));
            if (string.IsNullOrWhiteSpace(section2))
                throw new ArgumentNullException(nameof(section2));

            var landingPage = new LandingPage
            {
                Section1 = section1,
                Section2 = section2
            };
            _repository.Insert(landingPage);
            return landingPage;
        }
        public async Task<LandingPage> AddLandingPageSectionsAsync(string section1, string section2, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(section1))
                throw new ArgumentNullException(nameof(section1));
            if (string.IsNullOrWhiteSpace(section2))
                throw new ArgumentNullException(nameof(section2));

            var landingPage = new LandingPage
            {
                Section1 = section1,
                Section2 = section2
            };
            var rowsAffected = await _repository.InsertAsync(landingPage);
            return landingPage;
        }
        public LandingPage GetLandingPageSectionsById(int id)
        {
            return _repository.GetAll()
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<LandingPage> GetLandingPageSectionsByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetAll()
                 .FirstOrDefaultAsync(p => p.Id == id);
        }
        public int UpdateLandingPageSections(LandingPage sections)
        {;
            var result = _repository.Update(sections);
            if (result > 0)
            {
                logSerivce.LogInfo($"Landing Page with {sections.Section1} and {sections.Section2} was updatd at {DateTime.Now}");
            }
            return result;
        }

        public async Task<int> UpdateLandingPageSectionsAsync(LandingPage sections, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateAsync(sections);
            if (result > 0)
            {
                logSerivce.LogInfo($"Landing Page with {sections.Section1} and {sections.Section2} was updatd at {DateTime.Now}");
            }
            return result;
        }
        public int DeleteLandingPageSections(LandingPage sections)
        {
            if (sections == null)
                throw new ArgumentNullException(nameof(sections));
            return _repository.Delete(sections);
        }

        public async Task<int> DeleteLandingPageSectionsAsync(LandingPage sections, CancellationToken cancellationToken = default)
        {
            if (sections == null)
                throw new ArgumentNullException(nameof(sections));
            return await _repository.DeleteAsync(sections);
        }
    }
}
