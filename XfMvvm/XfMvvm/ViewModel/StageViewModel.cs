using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XfMvvm.Command;
using XfMvvm.Model;
using XfMvvm.Service;

namespace XfMvvm.ViewModel
{
  class StageViewModel : INotifyPropertyChanged
  {
    private IServiceStage _ServiceStage = null;
    private ObservableCollection<Stage> _ListeStages = null;

    public DelegateCommand Load { get; set; }
    public DelegateCommand Clear { get; set; }
    public DelegateCommand Add { get; set; }

    public StageViewModel()
    {
      _ServiceStage = new ServiceStage();
      _ListeStages = _ServiceStage.RetourStages();
      Load = new DelegateCommand(LoadStages);
      Clear = new DelegateCommand(ClearStages);
      Add = new DelegateCommand(AddStages);
    }

    private void ClearStages()
    {
      if (_ListeStages != null)
      {
        _ServiceStage.ClearStage();
        _ListeStages = _ListeStages;
        //Clear.ExecuteChanged();
      }
    }

    private void LoadStages()
    {
      try
      {
        Stages = _ServiceStage.RetourStages();
      }
      catch (Exception e)
      {
        throw;
      }
    }

    public void AddStages()
    {
      _ServiceStage.AddStage();
    }

    public ObservableCollection<Stage> Stages
    {
      get { return _ListeStages; }
      set
      {
        _ListeStages = value;
        OnPropertyChanged(nameof(Stages));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}