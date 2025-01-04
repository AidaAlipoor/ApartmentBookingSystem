namespace Book.Domain.Apartment
{
    public record Currency
    {
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency RIL = new Currency("RIL");


        private Currency(string code) => CurrencyCode = code;
        public string CurrencyCode { get; init; }


        public static Currency ValidateCode(string code)
        {
            return CurrenciesType.FirstOrDefault(c => c.CurrencyCode == code)
                ??
                throw new Exception("Currency Code is not valid!");
        }


        public static readonly IReadOnlyCollection<Currency> CurrenciesType = new[]
        {
            USD,
            RIL
        };

    }
}
