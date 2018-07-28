using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using AvaloniaTest.ViewModels;
using ReactiveUI;

namespace AvaloniaTest.Views
{
    public class MainWindow : Window
    {
        List<IBrush> lstColores;
        public MainWindow()
        {
            lstColores = new List<IBrush>();
            
            lstColores.Add(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
            lstColores.Add(new SolidColorBrush(Color.FromRgb(0, 255, 0)));
            lstColores.Add(new SolidColorBrush(Color.FromRgb(0, 0, 255)));
            lstColores.Add(new SolidColorBrush(Color.FromRgb(255, 255, 0)));
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            int maxRow = 3;
            int maxCol = 3;
            AvaloniaXamlLoader.Load(this);
            int i = 0;
            var grdMain = this.FindControl<Grid>("grdMain");
            for (int row = 0; row < maxRow; row++){
                grdMain.RowDefinitions.Add(new RowDefinition{
                    Height = GridLength.Parse("*",CultureInfo.InstalledUICulture)
                });
            }
            for (int col = 0; col < maxCol; col++){
                grdMain.ColumnDefinitions.Add(new ColumnDefinition{
                    Width =  GridLength.Parse("1*",CultureInfo.InstalledUICulture)
                });
            }
            for (int row = 0; row < maxRow; row++)
            {
                for (int col = 0; col < maxCol; col++)
                {
                    var btn = new Avalonia.Controls.Button
                    {
                        [Grid.RowProperty] = row,
                        [Grid.ColumnProperty] = col,
                        //Fill = lstColores[i%lstColores.Count],
                        Command = ReactiveCommand.Create<int>(RunTheThing),
                        CommandParameter = i
                    };
                    i++;
                    grdMain.Children.Add(btn);
                }
            }
        }
        void RunTheThing(int i)
        {
            Debug.Print("Hello from Button Number: " + i + "\n");
        }
    }
}