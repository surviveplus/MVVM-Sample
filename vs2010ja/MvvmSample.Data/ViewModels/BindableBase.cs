using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Data.ViewModels
{
    /// <summary>
    /// Microsoft.Practices.Prism.StoreApps.BindableBase と同じ実装を WPF 用に用意したクラスです。
    /// 将来、WPFに標準実装された場合は、このクラスを破棄して差し替えてください。
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // NOTE: .net Framework 4.0 では　CallerMemberName属性が使えないため、propertyName　は自分で指定する必要があります。
        //　そうすると、このメソッドの効果があまりないのですが、4.5 と実装をそろえてこのまま使う方が良いでしょう。
        protected virtual bool SetProperty<T>(ref T storage, T value,  String propertyName)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
