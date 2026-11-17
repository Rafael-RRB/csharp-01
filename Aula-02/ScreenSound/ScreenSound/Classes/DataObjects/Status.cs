namespace ScreenSound.Music
{
    public struct Status
    {
        public Availability Value { get; } = Availability.Unavailable;

        public Status(Availability setCode)
        {
            this.Value = setCode;
        }
    }
}
