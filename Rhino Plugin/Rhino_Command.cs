using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using System;
using System.Collections.Generic;

namespace Rhino_Plugin
{
    public class Generate_Plate : Command
    {
        public Generate_Plate()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static Generate_Plate Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "Generate_Plate";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panel_id = WpfPanelHost.PanelId;
            var panel_visible = Panels.IsPanelVisible(panel_id);

            var prompt = (panel_visible)
              ? "WPF panel is visible. New value"
              : "WPF panel is hidden. New value";

            var go = new GetOption();
            go.SetCommandPrompt(prompt);
            var hide_index = go.AddOption("Hide");
            var show_index = go.AddOption("Show");
            var toggle_index = go.AddOption("Toggle");
            go.Get();

            if (go.CommandResult() != Result.Success)
                return go.CommandResult();

            var option = go.Option();
            if (null == option)
                return Result.Failure;

            var index = option.Index;
            if (index == hide_index)
            {
                if (panel_visible)
                    Panels.ClosePanel(panel_id);
            }
            else if (index == show_index)
            {
                if (!panel_visible)
                    Panels.OpenPanel(panel_id);
            }
            else if (index == toggle_index)
            {
                if (panel_visible)
                    Panels.ClosePanel(panel_id);
                else
                    Panels.OpenPanel(panel_id);
            }


            // TODO: start here modifying the behaviour of your command.
            // ---
            RhinoApp.WriteLine("The {0} command will add a line right now.", EnglishName);

            Point3d pt0;
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select the start point");
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No start point was selected.");
                    return getPointAction.CommandResult();
                }
                pt0 = getPointAction.Point();
            }

            Point3d pt1;
            using (GetPoint getPointAction = new GetPoint())
            {
                getPointAction.SetCommandPrompt("Please select the end point");
                getPointAction.SetBasePoint(pt0, true);
                getPointAction.DynamicDraw +=
                  (sender, e) => e.Display.DrawLine(pt0, e.CurrentPoint, System.Drawing.Color.DarkRed);
                if (getPointAction.Get() != GetResult.Point)
                {
                    RhinoApp.WriteLine("No end point was selected.");
                    return getPointAction.CommandResult();
                }
                pt1 = getPointAction.Point();
            }

            doc.Objects.AddLine(pt0, pt1);

            Point3d p1 = pt0;
            Point3d p4 = pt1;
            Point3d p2 = new Point3d(p4.X, p1.Y, p1.Z);
            Point3d p3 = new Point3d(p1.X, p4.Y, p1.Z);

            var surface = NurbsSurface.CreateFromCorners(p1, p2, p4, p3);
            doc.Objects.AddSurface(surface);

            doc.Views.Redraw();
            RhinoApp.WriteLine("The {0} command added one line to the document.", EnglishName);

            // ---
            return Result.Success;
        }
    }
}
