using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WEB_SERVICE_CLIENT_MAGATZEM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region properties
        //datagrid  old warehouse
     
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
