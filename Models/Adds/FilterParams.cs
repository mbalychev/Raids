using Microsoft.EntityFrameworkCore;
using Raids.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raids.Models.Adds
{
    public class FilterParams
    {
        private DateTime start;
        private DateTime stop;

        public string Search { get; set; }
        public string SortNumber { get; set; }
        public string SortDate { get; set; }
        public int FilterTerr { get; set; }
        public DateTime Start
        {
            get => start;
            set
            {
                if (value == Convert.ToDateTime("01.01.0001"))
                    start = Convert.ToDateTime("01.01." + DateTime.Today.Year);
                else
                    start = value;
            }
        }
        public DateTime Stop
        {
            get => stop;
            set
            {
                if (value == Convert.ToDateTime("01.01.0001"))
                    stop = Convert.ToDateTime("31.12." + DateTime.Today.Year);
                else
                    stop = value;
            }
        }
        public string Filter { get; set; }

        public FilterParams (string search, string sortNumber, string sortDate, int filterTerr, DateTime start, DateTime stop, string filter)
        {
            Search = search; 
            SortNumber = sortNumber;
            SortDate = sortDate;
            FilterTerr = filterTerr;
            Start = start;
            Stop = stop;
            Filter = filter;
        }


        public static async Task<List<Raid>> GetRaidsAsync(ApplicationDbContext context, FilterParams filterParams)
        {
            List<Raid> Raids = await context.Raids.Include(w => w.Terr).AsNoTracking().ToListAsync();

            //поиск
            Raids = GetSearch(Raids, filterParams.Search);

            //сортировка
            Raids = GetSorting(Raids, filterParams.SortNumber, filterParams.SortDate);

            //фильтр по времени
            Raids = GetFilterDate(Raids, filterParams.Start, filterParams.Stop);

            //фильтр по территории
            Raids = GetFilterTerr(Raids, filterParams.FilterTerr);

            return Raids;
        }

        private static List<Raid> GetFilterTerr(List<Raid> raids, int filterTerr)
        {
            if (filterTerr != 0)
                raids = raids.Where(t => t.TerrId == filterTerr).ToList();
            return raids;
        }

        private static List<Raid> GetFilterDate(List<Raid> raids, DateTime start, DateTime stop)
        {
            return raids.Where(w => w.Start >= start && w.Stop <= stop).ToList();
        }

        private static List<Raid> GetSearch(List<Raid> raids, string search)
        {
            if (!string.IsNullOrEmpty(search))
                raids = raids.Where(r => r.Nomer.Contains(search)).ToList();
            return raids;
        }

        private static List<Raid> GetSorting(List<Raid> raids, string sortNumber, string sortDate)
        {
            switch (sortNumber)
            {
                case "asc":
                    raids = raids.OrderBy(o => o.NumberInt).ToList(); break;
                case "desc":
                    raids = raids.OrderByDescending(o => o.NumberInt).ToList(); break;
            }

            switch (sortDate)
            {
                case "asc":
                    raids = raids.OrderBy(o => o.Stop).ToList(); break;
                case "desc":
                    raids = raids.OrderByDescending(o => o.Stop).ToList(); break;
            }
            return raids;
        }

    }
}
