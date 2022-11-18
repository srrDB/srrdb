using System.Collections.Generic;

namespace srrdb.dbo
{
    public class ActivityType
    {
        public int Id { get; set; }

        //user1: register,login,logout,forgot password,
        //user2: download srr (only admin?)
        //user3: add tag to release, remove tag
        //release1: added release, removed release added nuke status
        //srr1: upload srr, add stored file, remove stored file

        public string Title { get; set; }

        public ICollection<Activity> Activity { get; set; }

        //- how to handle different languages?
        //Added release {0}
        //Removed release {0}
        //Added srr {0}
        //Removed srr {0}
        //{0} registered. Welcome to our community!
        //{0} downloaded srr {1}
        //File {0} was added to release {1} by {3}
        //File {0} was added to release {1} by {3}, handled by admin {4}
        public string Text { get; set; }
    }
}
