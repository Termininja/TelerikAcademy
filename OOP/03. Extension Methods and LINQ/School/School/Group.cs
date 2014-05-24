using System;

namespace School
{
    class Group
    {
        #region Properties
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }
        #endregion

        #region Constructor
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
        #endregion

        #region Method
        public override string ToString()
        {
            string result = "\n" + "GroupNumber: " + this.GroupNumber;
            result += "\n" + "Department: " + this.DepartmentName;
            return result;
        }
        #endregion
    }
}
