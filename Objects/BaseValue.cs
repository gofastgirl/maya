public abstract class BaseValue<T>
{
    private T _value;

    // Constructor to initialize the value
    public BaseValue(T newValue)
    {
        Merge(newValue); // Use Merge logic for initialization
    }

    public T Value
    {
        get { return _value; }
        set { Merge(value); }
    }

    public void Merge(T newValue)
    {
        Logger.ShowFunction();

        // Do nothing if the new value is the same or default (e.g., null or 0)
        if (EqualityComparer<T>.Default.Equals(newValue, default(T)) || newValue == null)
        {
            return;
        }

        // Handle special cases for string
        if (typeof(T) == typeof(string))
        {
            string newStringValue = newValue as string;

            // If it's null, empty, or whitespace, skip the merge
            if (string.IsNullOrWhiteSpace(newStringValue))
            {
                return;
            }

            if (EqualityComparer<T>.Default.Equals(_value, default(T)))
            {
                _value = newValue;
            }
            else if (!_value.Equals(newValue))
            {
                _value = newValue;
            }
        }
        // Handle special cases for enums
        else if (typeof(T).IsEnum)
        {
            // Skip if the new value is the default enum value (e.g., UNDEFINED)
            if (newValue.Equals(Enum.GetValues(typeof(T)).GetValue(0)))
            {
                return; // Don't merge default value
            }

            if (EqualityComparer<T>.Default.Equals(_value, default(T)))
            {
                _value = newValue;
            }
            else if (!_value.Equals(newValue))
            {
                _value = newValue;
            }
        }
        // Handle numeric types like int and long
        else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
        {
            // For numeric types, check if the value is 0 or the default value
            if (EqualityComparer<T>.Default.Equals(_value, default(T)))
            {
                _value = newValue;
            }
            else if (!EqualityComparer<T>.Default.Equals(_value, newValue))
            {
                _value = newValue;
            }
        }
        else
        {
            // Handle other types (e.g., float, double, etc.)
            if (EqualityComparer<T>.Default.Equals(_value, default(T)))
            {
                _value = newValue;
            }
            else if (!_value.Equals(newValue))
            {
                _value = newValue;
            }
        }
    }

    // Override ToString for consistency in output
    public override string ToString()
    {
        return _value?.ToString() ?? string.Empty;
    }
}
