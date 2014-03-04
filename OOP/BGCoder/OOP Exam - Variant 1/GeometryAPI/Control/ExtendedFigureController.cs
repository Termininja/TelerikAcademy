using System;

namespace GeometryAPI
{
    public class ExtendedFigureController : FigureController
    {
        public override void ExecuteFigureCreationCommand(string[] str)
        {
            switch (str[0])
            {
                case "circle":
                    {
                        currentFigure = new Circle(Vector3D.Parse(str[1]), double.Parse(str[2]));
                        break;
                    }
                case "cylinder":
                    {
                        currentFigure = new Cylinder(Vector3D.Parse(str[1]), Vector3D.Parse(str[2]), double.Parse(str[3]));
                        break;
                    }
            }
            base.ExecuteFigureCreationCommand(str);
        }

        protected override void ExecuteFigureInstanceCommand(string[] str)
        {
            switch (str[0])
            {
                case "area":
                    {
                        var ariaFigure = this.currentFigure as IAreaMeasurable;
                        if (ariaFigure != null) Console.WriteLine("{0:F2}", ariaFigure.GetArea());
                        else Console.WriteLine("undefined");
                        break;
                    }
                case "volume":
                    {
                        var volumeFigure = this.currentFigure as IVolumeMeasurable;
                        if (volumeFigure != null) Console.WriteLine("{0:F2}", volumeFigure.GetVolume());
                        else Console.WriteLine("undefined");
                        break;
                    }
                case "normal":
                    {
                        var ariaFigure = this.currentFigure as IFlat;
                        if (ariaFigure != null) Console.WriteLine(ariaFigure.GetNormal());
                        else Console.WriteLine("undefined");
                        break;
                    }
            }
            base.ExecuteFigureInstanceCommand(str);
        }
    }
}
