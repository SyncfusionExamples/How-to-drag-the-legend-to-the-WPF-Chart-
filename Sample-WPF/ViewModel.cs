using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_WPF
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>();
            Data.Add(new Model() { XValue = 1, YValue1 = 8 });
            Data.Add(new Model() { XValue = 2, YValue1 = 5 });
            Data.Add(new Model() { XValue = 3, YValue1 = 3 });
            Data.Add(new Model() { XValue = 4, YValue1 = 9 });
            Data.Add(new Model() { XValue = 5, YValue1 = 6 });
            Data.Add(new Model() { XValue = 6, YValue1 = 7 });
        }
    }

    public class Model
    {
        public double XValue { get; set; }

        public double YValue1 { get; set; }

        public double YValue2 { get; set; }
    }
}