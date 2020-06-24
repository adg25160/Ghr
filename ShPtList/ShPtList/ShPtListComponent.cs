using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Display;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace ShPtList
{
    public class ShPtListComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public ShPtListComponent()
          : base("ShPtList", "PtListDisplay",
              "Construct an Archimedean, or arithmetic, spiral given its radii and number of turns.",
              "IN.LA", "Primitive")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Log", "S", "Set this boolean to true to display the control window.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //設定log初始值為false
            bool log = false;
            //在GH取得數值時，程式會執行一次
            if (!DA.GetData<bool>("Log", ref log)) return;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Width = 400;
            mainWindow.Height = 500;
            if (log)
            {
                mainWindow.Show();
                mainWindow.btnPick.Click += PickMode;
            }
        }

        ObjRef[] obj_refs;
        Rhino.Geometry.Point point;
        int i;
        public Result RunCommand(RhinoDoc doc)
        {
            //選擇多點
            var rc = RhinoGet.GetMultipleObjects("Select point", false, ObjectType.Point, out obj_refs);
            if (rc != Result.Success)
                return rc;
            foreach (var o_ref in obj_refs)
            {
                point = o_ref.Point();
                RhinoApp.WriteLine("Point: x:{0}, y:{1}, z:{2}",
                  point.Location.X,
                  point.Location.Y,
                  point.Location.Z);

            }
            return Result.Success;
        }
        RhinoDoc doc;
        public void PickMode(object Sender, EventArgs e)
        {
            RunCommand(doc);
        }
        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("b477b04e-caa1-4021-baa7-0edde086120c"); }
        }
    }
}
