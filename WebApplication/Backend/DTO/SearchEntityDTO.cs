using System.Collections.Generic;
namespace WebApplication.Backend.DTO
{
    public class SearchEntityDTO
    {
        private string type;
        private string text;
        private string date;

        public SearchEntityDTO()
        {
        }

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
            if (searchEntityDTOReport != null)
            {
                foreach (SearchEntityDTO searchEntityDTO in searchEntityDTOReport)
                    searchEntityDTOs.Add(searchEntityDTO);
            }
            return searchEntityDTOs;
        }

        public bool IsSearchesFormatValid(string prescriptionSearch, string reportSearch)
        {
            return IsSearchFormatValid(prescriptionSearch) && IsSearchFormatValid(reportSearch);
        }

        public bool IsSearchFormatValid(string search)
        {
            if (search == null || search.Split(";").Length < 0 || search.Split(",").Length < 3 || search.Split(";").Length > 4)
                return false;
            foreach (string searchString in search.Split(";"))
            {
                if (searchString.Split(",").Length < 0 || searchString.Split(",").Length > 3)
                    return false;
            }
            return true;
        }

        public bool IsDateFormat(string date)
        {
            if (date != null)
                return date.Split("and")[0].Split("-").Length == 3 || date.Split("and")[1].Split("-").Length == 3;
            return false;
        }

        public bool IsNull(List<SearchEntityDTO> searchEntityDTOs)
        {
            return searchEntityDTOs == null;
        }
    }
}
