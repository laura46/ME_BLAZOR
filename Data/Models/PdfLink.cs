
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace CVWebsite.Data.Models
{
    public class PdfLink : IMapToModel<PdfLink>
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public PdfLink() {}
        public List<PdfLink> GetPdfs() 
        {
            return IMapToModel<PdfLink>.MapJsonToList("Certificates/CertifiedSecure.json");
        }
    }
}
