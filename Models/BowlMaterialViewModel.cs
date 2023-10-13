using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ishu_Bowl.Models
{
    public class BowlMaterialViewModel
    {
        public List<Bowl> Bowls { get; set; }
        public SelectList BowlMaterials { get; set; }
        public string SelectedBowlMaterial { get; set; }
        public string SearchString { get; set; }
    }
}
