using System.Collections.ObjectModel;
using System.Reflection;
using XfMvvm.Model;

namespace XfMvvm.Service
{


  public class ServiceStage : IServiceStage
  {
    private ObservableCollection<Stage> liste;

    public ObservableCollection<Stage> RetourStages()
    {
      liste = new ObservableCollection<Stage>
      {
        new Stage {CourseName = "C#4", Description = "Stage C# 4"},
        new Stage {CourseName = "C#5", Description = "Stage C# 5"},
        new Stage {CourseName = "C#6", Description = "Stage C# 6"}
      };

      return liste;
    }

    public void AddStage(Stage course = null)
    {
      if (course == null)
      {
        liste.Add(new Stage { CourseName = "C#7", Description = "Stage C# 7" });
      }
      else
      {
        liste.Add(new Stage { CourseName = course.CourseName, Description = course.Description });
      }
    }

    public void ClearStage()
    {
      liste.Clear();
    }

  }
}