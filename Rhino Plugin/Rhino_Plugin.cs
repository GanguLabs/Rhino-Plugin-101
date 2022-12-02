using Rhino;
using Rhino.PlugIns;
using Rhino.UI;
using Rhino_Plugin.Views;
using System;

namespace Rhino_Plugin
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class Rhino_Plugin : Rhino.PlugIns.PlugIn
    {
        public Rhino_Plugin()
        {
            Instance = this;
        }

        ///<summary>Gets the only instance of the Rhino_Plugin plug-in.</summary>
        public static Rhino_Plugin Instance { get; private set; }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.

        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            System.Type panel_type = typeof(WpfPanelHost);
            Panels.RegisterPanel(this, panel_type, "GeneratePanel", Properties.Resources.WPFIcon);
            return LoadReturnCode.Success;
        }
    }

    [System.Runtime.InteropServices.Guid("AB80CF1B-B499-42EC-B25D-EF1B41220C7D")]
    public class WpfPanelHost : RhinoWindows.Controls.WpfElementHost
    {
        public WpfPanelHost()
          : base(new GeneratePlane(), null) // No view model (for this example)
        {
        }

        /// <summary>
        /// Returns the ID of this panel.
        /// </summary>
        public static System.Guid PanelId
        {
            get
            {
                return typeof(WpfPanelHost).GUID;
            }
        }
    }
}