using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueHelperV1d0.Entity
{
    public class CustomerInfoV1d0
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public CustomerInfoV1d0()
        {
            Id = Guid.NewGuid();
            Name = "Empty";
            Telephone = "Empty";
        }
        public CustomerInfoV1d0(string name,string telephone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Telephone = telephone;
        }
    }
}
