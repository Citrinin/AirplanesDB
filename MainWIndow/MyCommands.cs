using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainWIndow
{
    static class MyCommands
    {

        public static RoutedUICommand LineThickness;
        public static RoutedUICommand LineColor;
        public static RoutedUICommand FigureColor;

        static MyCommands()
        {
            InputGestureCollection igcLineThickness = new InputGestureCollection();
            igcLineThickness.Add(new KeyGesture(Key.T, ModifierKeys.Alt, "Alt+T"));
            LineThickness = new RoutedUICommand("Line thisckness", "LineThickness", typeof(MyCommands), igcLineThickness);

            InputGestureCollection igcLineColor = new InputGestureCollection();
            igcLineColor.Add(new KeyGesture(Key.L, ModifierKeys.Alt, "Alt+L"));
            LineColor = new RoutedUICommand("Line color", "LineColor", typeof(MyCommands), igcLineColor);

            InputGestureCollection igcFigureColor = new InputGestureCollection();
            igcFigureColor.Add(new KeyGesture(Key.F, ModifierKeys.Alt, "Alt+F"));
            FigureColor = new RoutedUICommand("Figure color", "FigureColor", typeof(MyCommands), igcFigureColor);
        }
    }
}
