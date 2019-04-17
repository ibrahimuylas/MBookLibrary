using MBookLibrary.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBookLibrary.Data.Entities
{
    public abstract class EntityBase 
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifierUserId { get; set; }
        public Nullable<System.DateTime> CanceledDate { get; set; }
        public Nullable<int> CancelUserId { get; set; }
        public EntityStatus State { get; set; }
    }
}
