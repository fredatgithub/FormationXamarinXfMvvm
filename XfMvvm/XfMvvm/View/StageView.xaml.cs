using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XfMvvm.ViewModel;

namespace XfMvvm.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class StageView : ContentPage
  {
    public StageView()
    {
      InitializeComponent();
      StageViewModel vm = new StageViewModel();
      BindingContext = vm;
    }
  }
}