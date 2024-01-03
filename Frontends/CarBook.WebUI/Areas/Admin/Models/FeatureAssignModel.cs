using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Models;

public class FeatureAssignModel
{
        [BindProperty]
        public int FeatureId { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public bool IsAvailable { get; set; }
    
    
}