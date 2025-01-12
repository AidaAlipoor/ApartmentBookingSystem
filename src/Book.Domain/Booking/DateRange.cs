namespace Book.Domain.Booking
{
    public record DateRange
    {
        private DateRange() { }

        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }

        public int DaysLenght => EndDate.DayNumber - StartDate.DayNumber;

        public static DateRange Create(DateOnly StartDate , DateOnly EndDate)
        {
            if(StartDate > EndDate)
            {
                throw new Exception("Start day can not bigger than End Day!");
            }

            return new DateRange()
            {
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
