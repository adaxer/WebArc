using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AspectDemo
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new App().Run();
        }
    }


    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainView { DataContext = new MainViewModel(new Model()) };
            MainWindow.Show();
        }
    }

    public class Model : PropertyChangedBase
    {
        private string m_Name = "Model Name";
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; OnPropertyChanged("Name"); }
        }
    }

    /* This can replace the main Windows main Content
    <StackPanel>
        <Label Content="{Binding DisplayName}" />
        <Label Content="Model:" />
        <TextBox Text="{Binding MyModel.Name}" />
        <TextBlock Text="{Binding MyModel.Name}" />
        <Button Content="Reset" Command="{Binding ResetCommand}"/>
    </StackPanel> */

    public class MainViewModel : PropertyChangedBase
    {
        public MainViewModel(Model model)
        {
            MyModel = model;
        }

        private Model m_MyModel;
        public Model MyModel
        {
            get { return m_MyModel; }
            set { m_MyModel = value; OnPropertyChanged("MyModel"); }
        }

        public string DisplayName { get; set; } = "MainViewModel Title";

        //private string m_DisplayName = "MainViewModel Title";
        //public string DisplayName
        //{
        //    get { return m_DisplayName; }
        //    set { m_DisplayName = value;  OnPropertyChanged("DisplayName"); }
        //}

        public ICommand ResetCommand { get { return new RelayCommand(DoSet, CanDoSet); } }

        private void DoSet(object obj)
        {
            MyModel.Name = "Name reset";
            DisplayName = "Display changed";
        }

        private bool CanDoSet(object parameter)
        {
            return true;
        }
    }

    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, Boolean> canExecuteFunc;

        public RelayCommand(Action<object> exec, Func<object, bool> canExec = null)
        {
            executeAction = exec;
            canExecuteFunc = canExec ?? new Func<object, bool>(o => true);
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public void Execute(object parameter)
        {
            executeAction(parameter);
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }

}
