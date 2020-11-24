using Model.MedicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class SearchEntityDTO
    {
        private string type;
        private string text;
        private DateTime date;
        
        public SearchEntityDTO() {}
        public SearchEntityDTO(string type, string text, DateTime date)
        {
            this.type = type;
            this.text = text;
            this.date = date;
        }
        public string Type { get => type; }
        public string Text { get => text; }
        public DateTime Date { get => date; }

        public List<SearchEntityDTO> MergeLists(List<SearchEntityDTO> searchEntityDTOPrescriotions, List<SearchEntityDTO> searchEntityDTOReports)
        {
            List<SearchEntityDTO> searchEntityDTOs = searchEntityDTOPrescriotions;
            foreach (SearchEntityDTO searchEntityDTO in searchEntityDTOReports)
                searchEntityDTOs.Add(searchEntityDTO);
            return searchEntityDTOs;
        }
    }
}
