namespace Neuca.TestFlight.Domain.Enums;

[Flags]
public enum DaysOfWeek
{
    None = 0,
    Monday = 1 << 0,  // 1
    Tuesday = 1 << 1, // 2
    Wednesday = 1 << 2, // 4
    Thursday = 1 << 3, // 8
    Friday = 1 << 4, // 16
    Saturday = 1 << 5, // 32
    Sunday = 1 << 6 // 64
}

public static class DaysParser
{
    public static DaysOfWeek Convert(string[] days)
    {
        DaysOfWeek result = DaysOfWeek.None;

        foreach (var dayName in days)
        {
            var trimmed = dayName.Trim(' ');   
            if (Enum.TryParse(trimmed, out DaysOfWeek day))
            {
                result |= day;
            }
            else
            {
                throw new DomainExceptions.DomainException()
                {
                    Message = "Invalid day name"
                };
            }
        }

        return result;
    }
}

