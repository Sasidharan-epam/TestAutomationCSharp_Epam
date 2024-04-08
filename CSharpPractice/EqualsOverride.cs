using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvancedTasks
{
    /// <summary>
    /// Task 10 - Overriding equals
    /// </summary>
    class ProfileInfo
    {
        string firstName { get;}
        int age { get; }
        int contactNo { get;}


        public ProfileInfo(string name, int age, int contactNo)
        {
            this.firstName = name;
            this.age = age;
            this.contactNo = contactNo;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            else
                return true;
        }
        public bool MatchProfileInfo(ProfileInfo profile)
        {
            var currentProfile = new ProfileInfo("TestName", 25, 055655);
            if (profile.Equals(currentProfile))
                return true;
            else
                return false;
        }
    }
}
