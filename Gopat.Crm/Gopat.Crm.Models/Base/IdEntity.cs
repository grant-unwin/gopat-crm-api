using System;
using System.Collections.Generic;
using System.Text;

namespace Gopat.Crm.Models.Base
{
    public class IdEntity
    {
        public IdEntity()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public void Update()
        {
            Modified = DateTime.Now;
        }
    }
}