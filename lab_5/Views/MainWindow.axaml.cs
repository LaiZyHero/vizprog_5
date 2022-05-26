using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab_5.ViewModels;
using System.IO;
using System;

namespace lab_5.Views
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
#if DEBUG
                this.AttachDevTools();
#endif

                this.FindControl<Button>("OpenFile").Click += async delegate
                {
                    var TaskGetPathToFile = new OpenFileDialog()
                    {
                        Title = "Open File",
                        Filters = null
                    }.ShowAsync((Window)this.VisualRoot);

                    string[]? PathToFile = await TaskGetPathToFile;
                    var Temp = this.DataContext as MainWindowViewModel;
                    if (PathToFile != null)
                    {
                        StreamReader FReader = new StreamReader(string.Join(@"\", PathToFile));
                        Temp.Text = FReader.ReadToEnd();
                    }
                };

                this.FindControl<Button>("SaveFile").Click += async delegate
                {
                    SaveFileDialog SaveFileBox = new SaveFileDialog();
                    SaveFileBox.Title = "Save as...";
                    SaveFileBox.InitialFileName = "Text.txt";

                    var PathToTheFile = await SaveFileBox.ShowAsync((Window)this.VisualRoot);

                    if (PathToTheFile != null)
                    {
                        var Temp = this.DataContext as MainWindowViewModel;
                        File.WriteAllText(PathToTheFile, Temp.Result);
/*                        StreamWriter FWriter = new StreamWriter(string.Join(@"\", PathToTheFile), false);
                        await FWriter.WriteLineAsync(Temp.Result);*/
                    }
                };
                
            }     

            private void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }

            private void MyClickEventHandler(object? Sender, RoutedEventArgs e)
            {
                var Temp = new SetRegexWindow();
                Temp.OkNotification += delegate (string str)
                {
                    var t = this.DataContext as MainWindowViewModel;
                    t.Regular = str;
                    t.Result = t.FindRegex();
                };
                Temp.Show((Window)this.VisualRoot);
            }
    }
}
