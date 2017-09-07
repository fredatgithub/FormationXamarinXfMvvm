using System.Collections.ObjectModel;

namespace XfMvvm.Service
{
  public interface IServiceStage
  {
    ObservableCollection<Model.Stage> RetourStages();
    void ClearStage();
    void AddStage(Model.Stage course = null);
  }
}