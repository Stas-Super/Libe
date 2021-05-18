using System;
using System.Collections.Generic;
using System.Text;

namespace Libe.DAL.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
