using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

namespace Rachlab.Entity
{
    [Inspectable]
    public class SampleEntity
    {
        public SampleEntity() { }

        public SampleEntity(int id, string name)
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