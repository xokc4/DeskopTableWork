using System;
using System.Collections.Generic;

#nullable disable

namespace DeskopTableWork
{
    public partial class AccessRight
    {
        public AccessRight()
        {
            PeopleWorks = new HashSet<PeopleWork>();
        }

        public int Id { get; set; }
        public string NameAccess { get; set; }

        public virtual ICollection<PeopleWork> PeopleWorks { get; set; }
    }
}
