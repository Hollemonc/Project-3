using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace project_3.Models 
{
    public class Recipe
    {
    [Key]
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Ingredients { get; set; }
    public string CookTime { get; set; }
    public string Instructions { get; set; }


    }
}
