using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Diagnostics;

namespace AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting
        {
            get
            {
                return "Hello World!";
            }
        }

        public MainWindowViewModel()
        {
            DoTheThing = ReactiveCommand.Create(RunTheThing);
        }

        public ReactiveCommand<Unit, Unit> DoTheThing { get; }

        void RunTheThing()
        {
            Debug.Print("Hello from run the thing!");
        }
    }
}
