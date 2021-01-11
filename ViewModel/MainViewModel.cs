using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WEB_SERVICE_SERVIDOR_MAGATZEM.Models;

namespace WEB_SERVICE_CLIENT_MAGATZEM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region properties
        //datagrid  products for products 
        private ObservableCollection<ProducteDTO> _productCollection;
        public ObservableCollection<ProducteDTO> ProductCollection
        {
            get { return _productCollection; }
            set { ProductCollection = value; NotifyPropertyChanged();  }
        }
        #endregion


        #region INotifyPropertyChanged members
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
