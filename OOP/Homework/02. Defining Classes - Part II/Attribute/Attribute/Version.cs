using System;

[System.AttributeUsage(
   System.AttributeTargets.Struct |
   System.AttributeTargets.Class |
   System.AttributeTargets.Interface |
   System.AttributeTargets.Enum |
   System.AttributeTargets.Method
)]

class Version : System.Attribute
{
    // Keep the version in format: major.minor
    public double version;

    // Constructor
    public Version(double version)
    {
        this.version = version;
    }

    // Property
    public double Ver
    {
        get
        {
            return this.version;
        }
    }

    // String output for this class
    public override string ToString()
    {
        return this.version.ToString();
    }
}