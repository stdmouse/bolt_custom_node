using Ludiq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rachlab.Entity
{
    [Inspectable]
    public struct SampleStruct
    {
        public SampleStruct(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        [Inspectable]
        public int Id { get; set; }

        [Inspectable]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"id=[{Id}], name=[{Name}]";
        }
    }
}
