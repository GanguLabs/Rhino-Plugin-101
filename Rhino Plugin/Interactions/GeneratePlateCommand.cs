using Rhino.Geometry;
using Rhino.Input.Custom;
using Rhino.Input;
using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhino_Plugin.Interactions
{
    public class GeneratePlateCommand : CommandBase
    {
        private RhinoDoc _doc;
        public GeneratePlateCommand(RhinoDoc doc)
        {
            _doc = doc;
        }

        public override void Execute(object parameter)
        {

            Rhino.RhinoApp.RunScript("_-Line 0,0,0 10,10,10", false);

            // TODO: start here modifying the behaviour of your command.
            // ---
            // RhinoApp.WriteLine("The {0} command will add a line right now.", EnglishName);

            //Point3d pt0;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the start point");
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No start point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt0 = getPointAction.Point();
            //}

            //Point3d pt1;
            //using (GetPoint getPointAction = new GetPoint())
            //{
            //    getPointAction.SetCommandPrompt("Please select the end point");
            //    getPointAction.SetBasePoint(pt0, true);
            //    getPointAction.DynamicDraw +=
            //      (sender, e) => e.Display.DrawLine(pt0, e.CurrentPoint, System.Drawing.Color.DarkRed);
            //    if (getPointAction.Get() != GetResult.Point)
            //    {
            //        RhinoApp.WriteLine("No end point was selected.");
            //        return getPointAction.CommandResult();
            //    }
            //    pt1 = getPointAction.Point();
            //}

            //_doc.Objects.AddLine(pt0, pt1);

            //Point3d p1 = pt0;
            //Point3d p4 = pt1;
            //Point3d p2 = new Point3d(p4.X, p1.Y, p1.Z);
            //Point3d p3 = new Point3d(p1.X, p4.Y, p1.Z);

            //var surface = NurbsSurface.CreateFromCorners(p1, p2, p4, p3);
            //_doc.Objects.AddSurface(surface);

            //_doc.Views.Redraw();
            //// RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName); ;
        }
    }
}
