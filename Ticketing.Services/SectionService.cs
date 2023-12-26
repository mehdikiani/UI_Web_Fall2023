﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Data;

namespace Ticketing.Services
{
    public class SectionService : ISectionService
    {
        private readonly ILogSerivce logSerivce;
        private readonly IRepository<Section> sectionRepository;

        public SectionService(
             ILogSerivce logSerivce
            , IRepository<Section> sectionRepository)
        {
            this.logSerivce = logSerivce;
            this.sectionRepository = sectionRepository;
        }

        public Section AddSection(string title, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            var now = DateTime.Now;
            var section = new Section
            {
                Title = title,
                IsActive = isActive,
                CreateDate = now,
                ModifyDate = now,
                Deleted = false
            };
            sectionRepository.Insert(section);
            return section;
        }
        //async await
        public async Task<Section> AddSectionAsync(string title, bool isActive, CancellationToken cancellationToken=default)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            var now = DateTime.Now;
            var section = new Section
            {
                Title = title,
                IsActive = isActive,
                CreateDate = now,
                ModifyDate = now,
                Deleted = false
            };
          var rowsAffected = await sectionRepository.InsertAsync(section);
            return section;
        }

        public int DeleteSection(Section section)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            // db.Sections.Remove(section);
            section.Deleted = true;
            section.ModifyDate = DateTime.Now;
            return sectionRepository.Update(section);
        }

        public async Task<int> DeleteSectionAsync(Section section, CancellationToken cancellationToken = default)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            // db.Sections.Remove(section);
            section.Deleted = true;
            section.ModifyDate = DateTime.Now;
            return await sectionRepository.UpdateAsync(section);
        }

        public List<Section> GetAllSections()
        {
            // return db.Sections.Where(p => !p.Deleted).ToList();
            return sectionRepository.GetAll()
                .Where(p => !p.Deleted)
                .ToList();
        }

        public async Task<List<Section>> GetAllSectionsAsync(CancellationToken cancellationToken = default)
        {
            return await sectionRepository.GetAll()
               .Where(p => !p.Deleted)
               .ToListAsync();
        }

        public Section GetSectionById(int id)
        {
            //return db.Sections.FirstOrDefault(p => p.Id == id);
            //return db.Sections.Find(id);
            return sectionRepository.GetAll()
                .FirstOrDefault(p => p.Id == id && !p.Deleted);
        }

        public async Task<Section> GetSectionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await sectionRepository.GetAll()
                 .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);
        }

        public int UpdateSection(Section section)
        {
            //Tacking Chaange
            //var result = db.SaveChanges();
            var result = sectionRepository.Update(section);
            if (result > 0)
            {
                logSerivce.LogInfo($"The section {section.Title} was updatd at {DateTime.Now}");
            }
            return result;
        }

        public async Task<int> UpdateSectionAsync(Section section, CancellationToken cancellationToken = default)
        {
            var result =await sectionRepository.UpdateAsync(section);
            if (result > 0)
            {
                logSerivce.LogInfo($"The section {section.Title} was updatd at {DateTime.Now}");
            }
            return result;
        }
    }
}
