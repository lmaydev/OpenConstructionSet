namespace OpenConstructionSet.Data
{
    public record Reference
    {
        public Reference(Reference reference)
        {
            TargetId = reference.TargetId;
            Value0 = reference.Value0;
            Value1 = reference.Value1;
            Value2 = reference.Value2;
        }

        public Reference(string targetId, int value0 = 0, int value1 = 0, int value2 = 0)
        {
            TargetId = targetId;
            Value0 = value0;
            Value1 = value1;
            Value2 = value2;
        }

        public string TargetId { get; set; }

        public int Value0 { get; set; }

        public int Value1 { get; set; }

        public int Value2 { get; set; }

        public void Delete() => Value0 = Value1 = Value2 = int.MaxValue;

        public bool IsDeleted() => this is { Value0: int.MaxValue, Value1: int.MaxValue, Value2: int.MaxValue };

        public override string ToString() => $"{TargetId} ({Value0}, {Value1}, {Value2})";
    }
}