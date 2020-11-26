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
        private string date;
        
        public SearchEntityDTO() {}
        public SearchEntityDTO(string type, string text, string date)
        {
            this.type = type;
            this.text = text;
            this.date = date;
        }
        public string Type { get => type; }
        public string Text { get => text; }
        public string Date { get => date; }

        public List<SearchEntityDTO> MergeLists(List<SearchEntityDTO> searchEntityDTOPrescriotions, List<SearchEntityDTO> searchEntityDTOReport)
        {
            List<SearchEntityDTO> searchEntityDTOs = searchEntityDTOPrescriotions;
            try
            {
                foreach (SearchEntityDTO searchEntityDTO in searchEntityDTOReport)
                    searchEntityDTOs.Add(searchEntityDTO);
            }
            catch (Exception e) { }
            return searchEntityDTOs;
        }
        public bool IsNotEmptySearches(string prescriptionSearch,string reportSearch)
        {   
            if (prescriptionSearch==null || reportSearch==null || prescriptionSearch.Split(";").Length < 0 || prescriptionSearch.Split(",").Length < 3 || prescriptionSearch.Split(",").Length > 3 || reportSearch.Split(";").Length < 0 || reportSearch.Split(",").Length < 3 || reportSearch.Split(",").Length > 3)
                return true;
            return false;
        }
        public bool IsNotEmptySeacrh(string search)
        {
            if (search == null || search == null || search.Split(";").Length < 0 || search.Split(",").Length < 3 || search.Split(",").Length > 3)
                return true;
            return false;
        }
        public bool IsDateFormatValid(string date)
        {
            return true;
        }
    }
}
