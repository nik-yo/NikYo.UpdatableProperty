namespace NikYo.UpdatableProperty.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UpdatableAttribute : Attribute
    {
        public UpdateCondition Condition { get; set; } = UpdateCondition.Always;
    }

    public enum UpdateCondition
    {
        Always,
        NotDefault,
        StringNotNullOrEmpty,
        IntegerZeroOrMore,
        IntegerMoreThanZero
    }
}
