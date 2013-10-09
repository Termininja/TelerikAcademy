using System;

namespace Attribute
{
    [AttributeUsage(
       AttributeTargets.Struct |
       AttributeTargets.Class |
       AttributeTargets.Interface |
       AttributeTargets.Enum |
       AttributeTargets.Method,
       AllowMultiple = false)]

    class VersionAttribute : System.Attribute
    {
        // Keep the version in format: major.minor
        public double version;

        // Constructor
        public VersionAttribute(double version)
        {
            this.version = version;
        }

        // Property
        public double Ver { get; private set; }

        // String output for this class
        public override string ToString()
        {
            return this.version.ToString();
        }
    }
}