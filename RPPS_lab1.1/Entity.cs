using System;
using System.Collections.Generic;

namespace RPPS_lab1._1
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public XmlSerializableDictionary<string, object> Options { get; set; }
        public Entity()
        {
            Options = new XmlSerializableDictionary<string, object>();
        }
    }
}
