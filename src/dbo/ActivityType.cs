using System.Collections.Generic;

namespace srrdb.dbo
{
    public class ActivityType
    {
        public int Id { get; set; }

        //user1: register,login,logout,forgot password,
        //user2: download srr,
        //user3: add tag to release
        //release1: added release, added nuke status
        //srr1: upload srr, add file to srr,

        public string Title { get; set; }

        public ICollection<Activity> Activity { get; set; }

        public string Text { get; set; }
    }
}
