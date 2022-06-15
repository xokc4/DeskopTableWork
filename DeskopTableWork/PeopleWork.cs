using System;
using System.Collections.Generic;

#nullable disable

namespace DeskopTableWork
{
    public partial class PeopleWork
    {
        public PeopleWork()
        {
        }

        public PeopleWork(int idwork, string nameWork, string passwordWork, int idaccessRights)
        {
            Idwork = idwork;
            NameWork = nameWork;
            PasswordWork = passwordWork;
            IdaccessRights = idaccessRights;
           
        }

        public int Idwork { get; set; }
        public string NameWork { get; set; }
        public string PasswordWork { get; set; }
        public int IdaccessRights { get; set; }

        public virtual AccessRight IdaccessRightsNavigation { get; set; }
    }
}
