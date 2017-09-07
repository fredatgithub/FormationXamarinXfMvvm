using System.Collections.ObjectModel;
using System.ComponentModel;
using XfMvvm.Command;
using XfMvvm.Model;
using XfMvvm.Service;

namespace XfMvvm.ViewModel
{
  internal class StageViewModel : INotifyPropertyChanged
  {
    private IServiceStage _ServiceStage = null;
    private ObservableCollection<Stage> _listeStages = null;

    public DelegateCommand Load { get; set; }
    public DelegateCommand Clear { get; set; }
    public DelegateCommand Add { get; set; }

    public StageViewModel()
    {
      _ServiceStage = new ServiceStage();
      _listeStages = _ServiceStage.RetourStages();
      Load = new DelegateCommand(LoadStages, null);
      Clear = new DelegateCommand(ClearStages, () => _listeStages.Count > 0);
      Add = new DelegateCommand(AddStages, null);
    }

    private void ClearStages()
    {
      if (_listeStages != null)
      {
        _ServiceStage.ClearStage();
        _listeStages = _listeStages;
        //Clear.ExecuteChanged();
      }
    }

    private void LoadStages()
    {
      Stages = _ServiceStage.RetourStages();
    }

    public void AddStages()
    {
      _ServiceStage.AddStage();
      Clear.ExecuteChanged();
    }

    public ObservableCollection<Stage> Stages
    {
      get { return _listeStages; }
      set
      {
        _listeStages = value;
        OnPropertyChanged(nameof(Stages));
        Clear.ExecuteChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}