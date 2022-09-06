using System.Collections.Generic;

namespace WebApplication1.Models.Interfaces
{
    public interface ICategoryRepostory
    {

        IEnumerable<Category> categories { get; }

    }
}
