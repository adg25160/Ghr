using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace MyProject3
{
    public class MyProject3Info : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "MyProject3";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("9f8a9d42-278e-4af6-954b-6d676f8199e8");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
