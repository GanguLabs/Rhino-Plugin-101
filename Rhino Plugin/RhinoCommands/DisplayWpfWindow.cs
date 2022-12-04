using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using Rhino.UI;
using System;
using System.Collections.Generic;

namespace Rhino_Plugin.RhinoCommands
{
    public class DisplayWpfWindow : Command
    {
        public DisplayWpfWindow()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static DisplayWpfWindow Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "GeneratePlate_WPF";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var panel_id = WpfPanelHost.PanelId;
            var panel_visible = Panels.IsPanelVisible(panel_id);

            if (panel_visible)
                Panels.ClosePanel(panel_id);
            else
                Panels.OpenPanel(panel_id);

            return Result.Success;
        }
    }
}
