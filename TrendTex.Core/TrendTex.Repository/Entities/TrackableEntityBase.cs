using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendTex.Repository.Entities
{
	public class TrackableEntityBase: EntityBase
	{
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual User CreatedBy { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(ModifiedByUserId))]
        public virtual User ModifiedBy { get; set; }
        public string ModifiedByUserId { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
