using System.Collections.Generic;

namespace Powerfront.Models
{
    public class Device
    {
        public string Name { get; set; }
        public IList<int> Ids { get; set; }
    }
}