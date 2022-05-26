using System;
using System.Collections.Generic;
using System.Text;
using lab_5.Views;
using ReactiveUI;
using lab_5.ViewModels;
using lab_5.Models;

namespace lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _txt = "";

        private string _regex = "";

        private string _result = "";

        public string Text
        {
            get
            {
                return _txt;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _txt, value);
            }
        }

        public string Regular
        {
            get
            {
                return _regex;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _regex, value);
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _result, value);
            }
        }

        public string FindRegex() => RegexLogic.FindRegexInText(_txt, _regex);
    }
}
