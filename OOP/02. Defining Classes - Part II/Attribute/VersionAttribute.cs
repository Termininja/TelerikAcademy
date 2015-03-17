namespace Attribute
{
    using System;

    [AttributeUsage(
        AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Enum |
        AttributeTargets.Method,
        AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(double version)
        {
            this.Version = version;
        }

        public double Version { get; private set; }

        public override string ToString()
        {
            return this.Version.ToString();
        }
    }
}