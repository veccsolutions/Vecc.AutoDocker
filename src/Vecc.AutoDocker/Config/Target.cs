namespace Vecc.AutoDocker.Config
{
    public class Target
    {
        private string[] _emptyStringArray = new string[0];
        private ExecuteOnChange[] _emptyExecuteOnChangeArray = new ExecuteOnChange[0];

        public ExecuteOnChange[] ExecuteOnChange { get; set; }
        public string Destination { get; set; }
        public string TemplateSource { get; set; }
        public string[] WatchEvents { get; set; }
        public string WatchType { get; set; }

        public bool Equals(Target target)
        {
            if (ReferenceEquals(target, null))
            {
                return false;
            }

            if (ReferenceEquals(this, target))
            {
                return true;
            }

            if (this.GetType() != target.GetType())
            {
                return false;
            }

            return this.Destination == target.Destination &&
                this.TemplateSource == target.TemplateSource &&
                this.WatchEvents == target.WatchEvents &&
                this.WatchType == target.WatchType;
        }

        public override bool Equals(object obj) => this.Equals(obj as Target);

        public override int GetHashCode()
            => (this.Destination ?? string.Empty).GetHashCode() |
               (this.ExecuteOnChange ?? _emptyExecuteOnChangeArray).GetHashCode() ^
               (this.TemplateSource ?? string.Empty).GetHashCode() |
               (this.WatchEvents ?? _emptyStringArray).GetHashCode() ^
               (this.WatchType ?? string.Empty).GetHashCode();

        public static bool operator ==(Target left, Target right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Target left, Target right) => !(left == right);
    }
}
