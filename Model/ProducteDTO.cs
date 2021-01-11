using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_SERVICE_CLIENT_MAGATZEM.Model
{
    public class ProducteDTO
    {
        public int id { get; set; }
        public string nom { get; set; }
        public int Qnt { get; set; }

        public ProducteDTO()
        {

        }

        public ProducteDTO(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public ProducteDTO(int id, string nom, int Qnt)
        {
            this.id = id;
            this.nom = nom;
            this.Qnt = Qnt;
        }

        public bool ShouldSerializeid() { return false; }
    }
}