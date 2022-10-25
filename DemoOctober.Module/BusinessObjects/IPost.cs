using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOctober.Module.BusinessObjects
{
    internal interface IPost
    {
        void Post();
        void Unpost();

        bool IsPosted { get; }
    }
}
