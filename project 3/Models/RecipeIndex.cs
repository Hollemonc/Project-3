using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project_3.Models
{
    public class RecipeIndex
    {
    [Key]
    public int ID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
