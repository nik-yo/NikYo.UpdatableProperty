using NikYo.UpdatableProperty.Attributes;
using System.Reflection;

namespace NikYo.UpdatableProperty
{
    public static class UpdatableExtension
    {
        public static void UpdateWith<T>(this T thisObject, T updatedObject)
        {
            if (updatedObject == null)
            {
                return;
            }

            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                var attribute = p.GetCustomAttribute<UpdatableAttribute>();
                if (attribute == null) { continue;  }

                bool updateValue;
                switch (attribute.Condition)
                {
                    case UpdateCondition.NotDefault:
                        updateValue = !Equals(p.GetValue(updatedObject), default);
                        break;
                    case UpdateCondition.StringNotNullOrEmpty:
                        updateValue = !string.IsNullOrEmpty(p.GetValue(updatedObject) as string);
                        break;
                    case UpdateCondition.IntegerZeroOrMore:
                        {
                            var intValue = p.GetValue(updatedObject) as int?;
                            updateValue = intValue != null && intValue.Value >= 0;
                        }                        
                        break;
                    case UpdateCondition.IntegerMoreThanZero:
                        {
                            var intValue = p.GetValue(updatedObject) as int?;
                            updateValue = intValue != null && intValue.Value > 0;
                        }
                        break;
                    case UpdateCondition.Always:
                    default:
                        updateValue = true;
                        break;
                }

                if (updateValue)
                {
                    p.SetValue(thisObject, p.GetValue(updatedObject));
                }
            }
        }
    }
}
