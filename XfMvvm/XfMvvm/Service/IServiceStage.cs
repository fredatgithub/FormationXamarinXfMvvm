using System.Collections.ObjectModel;

namespace XfMvvm.Service
{
  public class IServiceStage
  {
    ObservableCollection<Model.Stage> RetourStages();
    void ClearStage();
    void AddStage(Model.Stage course = null);
  }
}