using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_SERVICE_CLIENT_MAGATZEM.Model
{
    public class MagatzemDTO
    {

        public int id { get; set; }
        public string nom { get; set; }

        public MagatzemDTO()
        {

        }
        public MagatzemDTO(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}
