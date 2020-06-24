using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Input;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace MyProject3.View
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public RhinoDoc doc;
        public MainWindow()
        {
            InitializeComponent();
        }
        //Call Rhino Script OpenFile  使用Rhino的開啟匯入功能
        public Result RunOpenFileCommand(RhinoDoc doc)
        {
            RhinoApp.RunScript("_Open", true);
            return Rhino.Commands.Result.Success;
        }
        //PickPoint 選點功能
        public Result RunCommand(RhinoDoc doc)
        {
            ObjRef obj_ref;
            var rc = RhinoGet.GetOneObject("Select point", false, ObjectType.Point, out obj_ref);
            if (rc != Result.Success)
                return rc;
            //選擇單點
            var point = obj_ref.Point();
            RhinoApp.WriteLine("Point: x:{0}, y:{1}, z:{2}",
              point.Location.X,
              point.Location.Y,
              point.Location.Z);

            //選擇多點
            ObjRef[] obj_refs;
            rc = RhinoGet.GetMultipleObjects("Select point", false, ObjectType.Point, out obj_refs);
            if (rc != Result.Success)
                return rc;

            //欄位名稱
            TxtRes.Text = "BC,UR1,UR2,UR3\n";
            int i = 0;
            //清空
            CbPointX.Items.Clear();
            CbPointY.Items.Clear();
            CbPointZ.Items.Clear();

            foreach (var o_ref in obj_refs)
            {
                point = o_ref.Point();
                RhinoApp.WriteLine("Point: x:{0}, y:{1}, z:{2}",
                  point.Location.X,
                  point.Location.Y,
                  point.Location.Z);

                i++;
                //迭代
                TxtRes.Text += TxtInputBC.Text + i + "," +
                       point.Location.X + "," +
                       point.Location.Y + "," +
                       point.Location.Z + ",\n";

                CbPointX.Items.Add(point.Location.X);
                CbPointY.Items.Add(point.Location.Y);
                CbPointZ.Items.Add(point.Location.Z);
            }
            return Result.Success;
        }
        //--------------------------------------
        //↓Button Clik Event 按鈕觸發事件
        //--------------------------------------
        private void S1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //TxtRes.Text = S1.Value.ToString();
        }

        private void BtnImportFile_Click(object sender, RoutedEventArgs e)
        {
            RunOpenFileCommand(doc);
        }

        private void BtnPickMode_Click(object sender, RoutedEventArgs e)
        {
            RunCommand(doc);
        }
        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv file (*.csv)|*.csv|Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TxtRes.Text);
            }
            
        }
    }
}
