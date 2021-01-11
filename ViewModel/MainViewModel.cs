using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private ObservableCollection<object> _productOriginCollection;
        public ObservableCollection<object> ProductOriginCollection
        {
            get { return _productOriginCollection; }
            set { _productOriginCollection = value; NotifyPropertyChanged(); }
        }
        private ObservableCollection<object> _productDestinationCollection;
        public ObservableCollection<object> ProductDestinationCollection
        {
            get { return _productDestinationCollection; }
            set { _productDestinationCollection = value; NotifyPropertyChanged(); }
        }



        //Selecting using Id's  by wharehouse
        private MagatzemDTO _selectedWarehouseOrigin;
        public MagatzemDTO SelectedWarehouseOrigin
        {
            get { return _selectedWarehouseOrigin; }
            set { _selectedWarehouseOrigin = value; NotifyPropertyChanged(); PopulateOriginProducts(); PopulateWarehouseDestination(); }
        }

        private MagatzemDTO _selectedWarehouseDestination;
        public MagatzemDTO SelectedWarehouseDestination
        {
            get { return _selectedWarehouseDestination; }
            set { _selectedWarehouseDestination = value; NotifyPropertyChanged(); PopulateDestinationProducts(); }
        }



        private ProducteDTO _selecteProductOrigin;
        public ProducteDTO SelecteProductOrigin
        {
            get { return _selecteProductOrigin; }
            set { _selecteProductOrigin = value; NotifyPropertyChanged(); }
        }



        //The amount which will be transfer to another warehouse
        private int _productAmount;
        public int ProductAmount
        {
            get { return _productAmount; }
            set { _productAmount = value; NotifyPropertyChanged(); }

        }
        #endregion



        #region commands

        public ICommand BtnTransfer => new RelayCommand(TransferProduct);


        public void TransferProduct()
        {
            if (SelectedWarehouseOrigin != null && SelecteProductOrigin != null && SelectedWarehouseDestination != null)
            {
                Repository.UpdateProduct(ProductAmount, this.SelecteProductOrigin.id, SelectedWarehouseOrigin.id, SelectedWarehouseDestination.id);
                PopulateOriginProducts();
                PopulateDestinationProducts();
                ProductAmount = 0;
            }

        }

        #endregion


        #region methods
        private void PopulateWarehouseOrigin()
        {
            var warehouses = Repository.GetWarehouse();
            if (warehouses != null)
                WarehouseCollectionOrigin = new ObservableCollection<MagatzemDTO>(warehouses);
            else
            {
                Console.WriteLine($"\nNo warehouse were found! (maybe server is not started)");
                WarehouseCollectionOrigin = new ObservableCollection<MagatzemDTO>();
            }
        }
        private void PopulateWarehouseDestination()
        {
            WarehouseCollectionDestination = new ObservableCollection<MagatzemDTO>(Repository.GetWarehouse().Where(w => (w.id != SelectedWarehouseOrigin.id)).ToList());
        }
        private void PopulateOriginProducts()
        {
            if (SelectedWarehouseOrigin != null)
            {
                //Try to Retrieve the products with stock on a warehouse
                var products = Repository.GetProducts(SelectedWarehouseOrigin.id);

                if (products != null)
                    ProductOriginCollection = new ObservableCollection<object>(products);
                else
                {
                    Console.WriteLine($"\nNo stock on [{SelectedWarehouseOrigin.nom}] warehouse (No products yet)\n");
                    ProductOriginCollection = new ObservableCollection<object>();
                }
            }

        }

        private void PopulateDestinationProducts()
        {
            if (SelectedWarehouseDestination != null)
            {
                var products = Repository.GetProducts(SelectedWarehouseDestination.id);

                if (products != null)
                    ProductDestinationCollection = new ObservableCollection<object>(products.Select(p => new { Nom = p.nom, Qnt = p.Qnt }));
                else
                {
                    Console.WriteLine($"\nNo stock on [{SelectedWarehouseDestination.nom}] warehouse (No products yet)\n");
                    ProductDestinationCollection = new ObservableCollection<object>();
                }
            }
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
