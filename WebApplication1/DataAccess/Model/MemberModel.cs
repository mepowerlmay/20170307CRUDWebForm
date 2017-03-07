using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    public   class MemberModel
    {
        public MemberModel() {
            ID = 0;
        }
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }

    }
}
