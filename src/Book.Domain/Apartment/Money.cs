namespace Book.Domain.Apartment
{
    public record Money(decimal amount, Currency currency)
    {
        public static Money operator +(Money first, Money Second)
        {
            if (first.currency != Second.currency)
            { throw new Exception("Currencies have to be equal"); }

            return new Money(first.amount + Second.amount, first.currency);
        }
    }
}
