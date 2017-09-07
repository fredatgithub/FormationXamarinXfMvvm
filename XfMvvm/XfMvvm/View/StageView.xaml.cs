using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XfMvvm.View
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class StageView : ContentPage
  {
    public StageView()
    {
      InitializeComponent();
    }
  }
}