using System;

namespace Management.Common
{
    public abstract class ModifyEntity
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}