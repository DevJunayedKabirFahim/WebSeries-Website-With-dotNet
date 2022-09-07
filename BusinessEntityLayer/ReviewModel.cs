using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntityLayer
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public Nullable<int> VideoId { get; set; }
        public string Comment { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Name { get; set; }
        public string VideoTitle { get; set; }
        public virtual UserModel User { get; set; }
        public virtual VideoModel Video { get; set; }
    }
}
