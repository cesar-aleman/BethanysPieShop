using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface ICategoryRepository
    {
        //properties
        IEnumerable<Category> AllCategories { get; }
    }
}
