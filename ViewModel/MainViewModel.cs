using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WEB_SERVICE_CLIENT_MAGATZEM.Model;

namespace WEB_SERVICE_CLIENT_MAGATZEM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            PopulateWarehouseOrigin();
        }

        #region properties
        //combobox  Warehouse origin (main one)
        private ObservableCollection<MagatzemDTO> _warehouseCollectionOrigin;
        public ObservableCollection<MagatzemDTO> WarehouseCollectionOrigin
        {
            get { return _warehouseCollectionOrigin; }
            set { _warehouseCollectionOrigin = value; NotifyPropertyChanged(); }
        }

        //combobox  Warehouse destination (second one)
        private ObservableCollection<MagatzemDTO> _warehouseCollectionDestination;
        public ObservableCollection<MagatzemDTO> WarehouseCollectionDestination
        {
            get { return _warehouseCollectionDestination; }
            set { _warehouseCollectionDestination = value; NotifyPropertyChanged(); }
        }

        //datagrid  products for products 
        private ObservableCollection<ProducteDTO> _productCollection;
        public ObservableCollection<ProducteDTO> ProductCollection
        {
            get { return _productCollection; }
            set { ProductCollection = value; NotifyPropertyChanged(); }
        }

        //Selecting using Id's
        private int _selectedWarehouseOrigin;
        public int SelectedWarehouseOrigin
        {
            get { return _selectedWarehouseOrigin; }
            set { _selectedWarehouseOrigin = value; NotifyPropertyChanged(); PopulateWarehouseDestination(); }
        }
        #endregion




        #region methods
        private void PopulateWarehouseOrigin()
        {
            WarehouseCollectionOrigin = new ObservableCollection<MagatzemDTO>(Repository.GetWarehouse());
        }
        private void PopulateWarehouseDestination()
        {
            WarehouseCollectionDestination = new ObservableCollection<MagatzemDTO>(Repository.GetWarehouse().Where(w=> (w.id != SelectedWarehouseOrigin)).ToList());
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
