using System.Collections.Generic;

namespace ProjectName.Models
{
    public class Item
    {
        public Item()
        {
            this.JoinEntities = new HashSet<CategoryItem>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CategoryItem> JoinEntities { get;}
    }
}