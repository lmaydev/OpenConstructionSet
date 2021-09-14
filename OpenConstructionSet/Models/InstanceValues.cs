namespace OpenConstructionSet.Models
{
    public struct InstanceValues
    {
        public string target;
        public Vector3 position;
        public Vector4 rotation;
        public string states;

        public InstanceValues(Instance instance)
        {
            target = instance.target;
            position = instance.position;
            rotation = instance.rotation;
            states = instance.states;
        }

        public InstanceValues(string target, Vector3 position, Vector4 rotation, string states)
        {
            this.target = target;
            this.position = position;
            this.rotation = rotation;
            this.states = states;
        }
    }
}
