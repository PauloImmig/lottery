using System.Collections.Generic;

namespace Lottery.Data.Models
{
    public class LuckNumbers : List<int>
    {
        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}