using System.Collections.Generic;
using RedPanda.Project.Interfaces;

namespace RedPanda.Project.Utils
{
    public static class PromoSorter
    {
        // Bubble sort algorithm
        public static void SortByRarity(IList<IPromoModel> models)
        {
            var count = models.Count;
            for (var i = 0; i < count-1; i++)
            {
                var swapped = false;
                for (var k = 0; k < count - i - 1; k++)
                {
                    if (models[k].Rarity < models[k+1].Rarity )
                    {
                        (models[k], models[k + 1]) = (models[k + 1], models[k]);
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }   
        }
    }
}