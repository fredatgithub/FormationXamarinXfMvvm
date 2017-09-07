using System;
using System.Windows.Input;

namespace XfMvvm.Command
{
  public class DelegateCommand : ICommand
  {
    private Action _commandMethod;
    private Action<object> _commandMethodP;
    private Func<bool> _canExecute;

    public DelegateCommand(Action command, Func<bool> canExecute)
    {
      _commandMethod = command;
      _canExecute = canExecute;
    }

    public DelegateCommand(Action command)
    {
      _commandMethod = command;
    }

    public DelegateCommand(Action<object> command, Func<bool> canExecute)
    {
      _commandMethodP = command;
      _canExecute = canExecute;
    }

    public DelegateCommand(Action<object> command)
    {
      _commandMethodP = command;
    }

    public bool CanExecute(object parameter)
    {
      //return true;
      return _canExecute == null || _canExecute();
    }

    public void Execute(object parameter)
    {
      if (parameter == null)
      {
        _commandMethod.Invoke();
      }
      else
      {
        _commandMethodP.Invoke(parameter);
      }
    }

    public event EventHandler CanExecuteChanged;

    public void ExecuteChanged()
    {
      CanExecuteChanged?.Invoke(this, new EventArgs());
    }
  }
}