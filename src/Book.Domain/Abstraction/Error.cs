namespace Book.Domain.Abstraction
{
    public record Error(string code , string name)
    {
        public static Error None = new(string.Empty, string.Empty);
        public static Error NullValue = new("Error.NullValue", "Null Value was provided");
    }
}
