namespace Vecc.AutoDocker.Client
{
    public class Filter<T>
    {
        private T _value;
        public bool IsSet { get; set; }

        public T Value
        {
            get
            {
                if (!this.IsSet)
                {
                    return default;
                }
                return this._value;
            }
            set
            {
                this._value = value;
                this.IsSet = true;
            }
        }

        public static implicit operator Filter<T>(T value) => new Filter<T> { Value = value };
        public static implicit operator T(Filter<T> value) => value.Value;
        public static implicit operator string(Filter<T> value) => value.Value?.ToString();
    }
}
