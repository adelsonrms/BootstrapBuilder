using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBuilder.Components
{
   public interface IBSElement
    {
        string GetHTML();
        void AddElement(IBSElement element);
    }   
}
