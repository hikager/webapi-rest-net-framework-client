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

        public static List<object> GetProducts(int warehouseId)
        {
            List<object> products = null;

            //Using 'mag/1' as a default request part
            products = (List<object>)ClientRequest.MakeRequest(string.Concat(endPoint, "mag/1/", warehouseId), null, "GET", "application/json", typeof(List<object>));

            return products;
        }
    }
}
