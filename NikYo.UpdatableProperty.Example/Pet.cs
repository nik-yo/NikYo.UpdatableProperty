using NikYo.UpdatableProperty.Attributes;

namespace NikYo.UpdatableProperty.Example
{
    public class Pet
    {
        public string Type { get; set; } = null!;
        [Updatable]
        public string Name { get; set; } = null!;
        [Updatable(Condition = UpdateCondition.NotDefault)]
        public bool Tagged { get; set; }
        [Updatable(Condition = UpdateCondition.StringNotNullOrEmpty)]
        public string Color { get; set; } = null!;
        [Updatable(Condition = UpdateCondition.IntegerZeroOrMore)]
        public int Friends { get; set; }
        [Updatable(Condition = UpdateCondition.IntegerMoreThanZero)]
        public int Age { get; set; }
    }
}
