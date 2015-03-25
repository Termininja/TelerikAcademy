namespace School
{
    using System;

    public class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            string result = string.Format("\nGroupNumber: {0}\nDepartment: {1}", this.GroupNumber, this.DepartmentName);

            return result;
        }
    }
}
