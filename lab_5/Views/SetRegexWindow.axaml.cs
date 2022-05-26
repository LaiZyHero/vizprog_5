using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using ReactiveUI;

namespace lab_5.Views
{
    public partial class SetRegexWindow : Window
    {

        public delegate void OkHandler(string msg);
        public event OkHandler? OkNotification;
        public SetRegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("Okbtn").Click += async delegate
            {
                OkNotification(this.Find<TextBox>("RegularStringBox").Text);
                Close();
            };
            this.FindControl<Button>("Cancel").Click += delegate
            {
                Close();
            };
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
