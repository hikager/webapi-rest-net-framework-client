using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WEB_SERVICE_CLIENT_MAGATZEM.Model
{
    public class Repository
    {
        private static string endPoint = ClientRequest.ws1;

        public static List<ProducteDTO> GetProducts(int warehouseId)
        {
            List<ProducteDTO> products = null;

            //Using 'mag/1' as a default request part
            products = (List<ProducteDTO>)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/1/", warehouseId), null, "GET", "application/json", typeof(List<ProducteDTO>));

            return products;
        }

        //All warehouse
        public static List<MagatzemDTO> GetWarehouse()
        {
            List<MagatzemDTO> warehouses = null;

            //Using 'mag/1' as a default request part
            warehouses = (List<MagatzemDTO>)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/"), null, "GET", "application/json", typeof(List<MagatzemDTO>));

            return warehouses;
        }
    }
}
