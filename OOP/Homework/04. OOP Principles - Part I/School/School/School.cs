using System;
using System.Collections.Generic;

namespace School
{
    class School
    {
        #region Properties
        public string SchoolName { get; private set; }
        public List<SchoolClass> Classes { get; private set; }
        #endregion

        #region Constructor
        public School(string schoolName, List<SchoolClass> classes)
        {
            this.SchoolName = schoolName;
            this.Classes = classes;
        }
        #endregion

        #region Methods
        public void AddClass(SchoolClass theClass)
        {
            Classes.Add(theClass);
        }

        public void RemoveClass(SchoolClass theClass)
        {
            Classes.Remove(theClass);
        }

        public override string ToString()
        {
            string result = "School Name: " + SchoolName + "\n";
            foreach (SchoolClass schoolClass in Classes) result += schoolClass + "\n";
            return result;
        }
        #endregion
    }
}