using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows;


// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace MyProject3
{
    public class MyProject3Component : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        /// 
        //public MainWindow MyMainWindow { get; set; }
        public MyProject3Component()
          : base("WinForm", "Form",
              "Construct an Archimedean, or arithmetic, spiral given its radii and number of turns.",
              "IN.LA", "UI")
        {
            
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Log", "S", "Set this boolean to true to display the control window.", GH_ParamAccess.item);
            //pManager.AddIntegerParameter("Slider","F", "Slider TickFrequency",GH_ParamAccess.item,1);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //pManager.AddIntegerParameter("Slider","T","Slider is return",GH_ParamAccess.item);
            pManager.AddTextParameter("Slider", "T", "Slider is return", GH_ParamAccess.item);
        }
        

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //設定log初始值為false
            bool log = false;

            //int min = 0;
            //int indexMove = 1;
            //int max = 200;
            
            //在GH取得數值時，程式會執行一次
            if (!DA.GetData<bool>("Log", ref log)) return;
            //DA.GetData("Width", ref width);
            //DA.GetData("Height", ref height);
            //DA.GetData("Slider", ref indexMove);

            View.MainWindow ws = new View.MainWindow();

            ws.Width = 300;
            ws.Height = 600;
            //ws.S1.Minimum = min;
            //ws.S1.Value = indexMove;
            //ws.S1.Maximum = max;

            //執行一次
            if (log)
            {
                ws.Show();
            }
            //DA.SetData(0,indexMove);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                Bitmap image1;
                image1 = new Bitmap("C:\\Users\\Jeff\\source\\repos\\MyProject3\\MyProject3\\Resources\\Panel.ico", true);
                return image1;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("616d9867-f0b5-4344-94ee-893738270b75"); }
        }
    }
}
