using Microsoft.AspNetCore.Mvc;

namespace DAW_Yacht.Models
{
    [BindProperties(SupportsGet = true)]
    public class SearchModel
    {
        public string TitluPozie { get; set; }
        public string TitluVolum { get; set; }
    }
}