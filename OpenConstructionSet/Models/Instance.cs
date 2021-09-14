using System.Collections.Generic;

namespace OpenConstructionSet.Models
{
    public struct Instance
    {
        public Instance(string id, string target, Vector3 position, Vector4 rotation, string states)
        {
            this.id = id;
            this.target = target;
            this.position = position;
            this.rotation = rotation;
            this.states = states;
        }

        public Instance(KeyValuePair<string, InstanceValues> pair) : this(pair.Key, pair.Value)
        {
        }

        public Instance(string id, InstanceValues values)
        {
            this.id = id;

            target = values.target;
            position = values.position;
            rotation = values.rotation;
            states = values.states;
        }

        public readonly string id;
        public string target;
        public Vector3 position;
        public Vector4 rotation;
        public string states;
    }
}