using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Abtract
{
    public interface ISeoable
    {
        string MetaKeyWord { get; set; }
        string MetaDescription { get; set; }
    }
}
