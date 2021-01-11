﻿using System;
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
        private ObservableCollection<object> _productOriginCollection;
        public ObservableCollection<object> ProductOriginCollection
        {
            get { return _productOriginCollection; }
            set { _productOriginCollection = value; NotifyPropertyChanged(); }
        }

        //Selecting using Id's
        private MagatzemDTO _selectedWarehouseOrigin;
        public MagatzemDTO SelectedWarehouseOrigin
        {
            get { return _selectedWarehouseOrigin; }
            set { _selectedWarehouseOrigin = value; NotifyPropertyChanged(); PopulateOriginProducts(); PopulateWarehouseDestination(); }
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
            var products = Repository.GetProducts(SelectedWarehouseOrigin.id).Select(p => new { Nom = p.nom, Qnt = p.Qnt });

            if (products != null)
                ProductOriginCollection = new ObservableCollection<object>(products);
            else
            {
                Console.WriteLine($"\nNo stock on [{SelectedWarehouseOrigin.nom}] warehouse (No products yet)\n");
                ProductOriginCollection = new ObservableCollection<object>();
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
