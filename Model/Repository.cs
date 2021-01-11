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

        //Updates a product -> transfers its qnt from its warehouse to another (changing its quantity from the previous one)
        public static string UpdateProduct(int qProduct, int productId, int oldWarehouseId, int newWarehouseIdd)
        {
            string response = "";
            try
            {
                response = (string)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/", $"{qProduct}/{productId}/{oldWarehouseId}/{newWarehouseIdd}"), null, "Post", "application/json", typeof(List<ProducteDTO>));
            }
            catch (Exception)
            {
                Console.WriteLine($"");
               
            }
            return response;
        }

        public static List<ProducteDTO> GetProducts(int warehouseId)
        {
            List<ProducteDTO> products = null;
            try
            {
                //Using 'mag/1' as a default request part
                products = (List<ProducteDTO>)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/1/", warehouseId), null, "GET", "application/json", typeof(List<ProducteDTO>));

            }
            catch (Exception)
            {
                Console.WriteLine($"\nNo stock on [{warehouseId}] warehouse (No products yet)\n");
            }

            return products;
        }

        //All warehouse
        public static List<MagatzemDTO> GetWarehouse()
        {
            List<MagatzemDTO> warehouses = null;

            try
            {
                //Using 'mag/1' as a default request part
                warehouses = (List<MagatzemDTO>)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/"), null, "GET", "application/json", typeof(List<MagatzemDTO>));
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot acces to the webapi (Server provider ) : \n " + e.Message);
            }
            return warehouses;
        }
    }
}
