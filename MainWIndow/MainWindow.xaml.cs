using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MyShapes;
using System.Windows.Forms;
using DAL;


namespace MainWIndow
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flagFileOpen;
        bool flagFileSaved=false;
        string  windowName = "ManiacDrawer";
        string fileName;
        string filePath;
        //SolidColorBrush fillColor;
        //SolidColorBrush borderColor;
        //int PolyThickness;

        MyPolygon myPol = new MyPolygon();
        

        public MainWindow()
        {
            InitializeComponent();
            FileIsClosed();

            CommandBinding openBinding = new CommandBinding(ApplicationCommands.Open);
            CommandBinding newBinding = new CommandBinding(ApplicationCommands.New);
            CommandBinding saveBinding = new CommandBinding(ApplicationCommands.Save);
            CommandBinding saveAsBinging = new CommandBinding(ApplicationCommands.SaveAs);
            CommandBinding closeBinding = new CommandBinding(ApplicationCommands.Close);

            CommandBinding bordColorBinding = new CommandBinding(MyCommands.LineColor);
            CommandBinding lineThicknessBinding = new CommandBinding(MyCommands.LineThickness);
            CommandBinding figureColorBinding = new CommandBinding(MyCommands.FigureColor);

            openBinding.Executed += OpenBinding_Executed;
            newBinding.Executed += NewBinding_Executed;
            saveBinding.Executed += SaveBinding_Executed;
            saveAsBinging.Executed += SaveAsBinging_Executed;
            closeBinding.Executed += CloseBinding_Executed;


            saveBinding.CanExecute += SaveBinding_CanExecute;
            saveAsBinging.CanExecute += SaveAsBinging_CanExecute;
            closeBinding.CanExecute += CloseBinding_CanExecute;

            bordColorBinding.Executed += BordColorBinding_Executed;
            bordColorBinding.CanExecute += BordColorBinding_CanExecute;

            lineThicknessBinding.CanExecute += LineThicknessBinding_CanExecute;
            lineThicknessBinding.Executed += LineThicknessBinding_Executed;

            figureColorBinding.CanExecute += FigureColorBinding_CanExecute;
            figureColorBinding.Executed += FigureColorBinding_Executed;

            this.CommandBindings.AddRange(new[] { openBinding, newBinding, saveBinding, saveAsBinging, closeBinding, bordColorBinding, lineThicknessBinding, figureColorBinding });

            this.MouseDown += MainWindow_MouseDown;
            this.Title = windowName;
            
        }




        private void FigureColorBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }
        private void LineThicknessBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }
        private void BordColorBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }
        private void SaveBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }
        private void SaveAsBinging_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }
        private void CloseBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = flagFileOpen;
        }

        private void drawningCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            double x = e.GetPosition(drawningCanvas).X;
            double y = e.GetPosition(drawningCanvas).Y;
            sbCoordinate.Content = $"Mouse position x={x:0}, y={y:0}";
        }
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (flagFileOpen)
            {
                double x = e.GetPosition(drawningCanvas).X;
                double y = e.GetPosition(drawningCanvas).Y;
                MyPolygon myPolygon = new MyPolygon();
                //myPolygon=myPol.
                myPolygon.FillColor=  myPol.FillColor;
                myPolygon.BorderColor = myPol.BorderColor;
                myPolygon.PolyThickness = myPol.PolyThickness;
                Canvas.SetLeft(myPolygon, x);
                Canvas.SetTop(myPolygon, y);
                drawningCanvas.Children.Add(myPolygon);
            }
        }
//////////////////////////////////////////////////////////////////////////////////////////////
        private void NewBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileIsClosed();
            drawningCanvas.Children.Clear();
            drawningCanvas.Background = Brushes.White;
            flagFileOpen = true;
            fileName = "New File.mdn";
            SetWindowName();
        }
        private void OpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            OpenFileDialog opfDialog = new OpenFileDialog();
            opfDialog.Filter = "Maniac Drawer (*.mdn)|*.mdn";
            opfDialog.CheckFileExists = true;
            opfDialog.Multiselect = false;
            if (opfDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                drawningCanvas.Children.Clear();
                filePath = opfDialog.FileName;
                FileModel.FileRead(filePath, ref drawningCanvas,ref myPol);
                fileName = opfDialog.SafeFileName;
                SetWindowName();
                drawningCanvas.Background = Brushes.White;
                flagFileOpen = true;
                flagFileSaved = true;
            }
        }
        private void SaveBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (flagFileSaved)
            {
                FileModel.FileWrite(filePath, drawningCanvas, myPol);
            }
            else
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.Filter = "Maniac Drawer (*.mdn)|*.mdn";
                if (svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = svDialog.FileName;
                    FileModel.FileWrite(filePath, drawningCanvas, myPol);
                    fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                    SetWindowName();
                    flagFileSaved = true;
                } 
            }
        }
        private void SaveAsBinging_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog svDialog = new SaveFileDialog();
            svDialog.Filter = "Maniac Drawer (*.mdn)|*.mdn";
            if (svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = svDialog.FileName;
                FileModel.FileWrite(filePath, drawningCanvas, myPol);
                flagFileSaved = true;
                fileName = filePath.Substring(filePath.LastIndexOf(@"\")+1);
                SetWindowName();
            }
        }
        private void CloseBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FileIsClosed();
        }
        private void menuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
/////////////////////////////////////////////////////////////////////////////////////////
//menu options
        private void LineThicknessBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SelectLineThikness slt = new SelectLineThikness();
            if (slt.ShowDialog() == true)
            {
                myPol.PolyThickness = slt.ThicknessLine;
            }
            ChangeLineThickness();
        }
        private void FigureColorBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            myPol.FillColor = ConvertDialogColor(colorDialog.Color);
            ChangeFillColor();
        }
        private void BordColorBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            myPol.BorderColor = ConvertDialogColor(colorDialog.Color);
            ChangeBorderColor();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        //Functions
        private void ChangeFillColor()
        {
            foreach (var item in drawningCanvas.Children)
            {
                if (item is MyPolygon)
                {
                    ((MyPolygon)item).FillColor = myPol.FillColor;
                }
            }
        }
        private void ChangeBorderColor()
        {
            foreach (var item in drawningCanvas.Children)
            {
                if (item is MyPolygon)
                {
                    ((MyPolygon)item).BorderColor = myPol.BorderColor;
                }
            }
        }
        private void ChangeLineThickness()
        {
            foreach (var item in drawningCanvas.Children)
            {
                if (item is MyPolygon)
                {
                    ((MyPolygon)item).PolyThickness = myPol.PolyThickness;
                }
            }
        }



        private SolidColorBrush ConvertDialogColor(System.Drawing.Color dlgColor)
        {
            
            return new SolidColorBrush(Color.FromArgb(dlgColor.A, dlgColor.R, dlgColor.G, dlgColor.B));
        }


        private void FileIsClosed()
        {
            flagFileSaved = false;
            flagFileOpen = false;
            fileName = "";
            filePath="";
            SetWindowName();
            myPol = new MyPolygon();
            drawningCanvas.Background = Brushes.Gray;
            drawningCanvas.Children.Clear();
        }

        private void SetWindowName()
        {
            if (fileName.Equals(""))
            {
                this.Title = windowName;
            }
            else
            {
                this.Title = windowName + " - " + fileName; 
            }
        }


        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            MyDialogAbout dab = new MyDialogAbout(myPol);
            dab.ShowDialog();
        }
    }
}
