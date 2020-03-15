using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CVWebsite.Data.Models
{
    public class Badge : IMapToModel<Badge>
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        private CATEGORY Category;

        public Badge() {}

        public List<Badge> GetBadges(CATEGORY category) 
        {
            
            Badge[] badgesArray = JsonConvert.DeserializeObject<Badge[]>(File.ReadAllText("Certificates/MicrosoftBadges.json"));
            List<Badge> badges = badgesArray.ToList<Badge>();
            badges.ForEach(badge => { badge.Category = (badge.Description.Contains("mta")) ? CATEGORY.MTA : CATEGORY.OFFICE; });
            return SortCategory(badges, category);
        }

        private List<Badge> SortCategory(List<Badge> listToSort, CATEGORY category) 
        {
            List<Badge> sortedList = new List<Badge>();
            listToSort.ForEach(el => {
                if (el.Category == category) {
                    sortedList.Add(el);
                }
            });
            return sortedList;
        }

        public enum CATEGORY 
        {
            MTA,
            OFFICE
        }
    }
}
