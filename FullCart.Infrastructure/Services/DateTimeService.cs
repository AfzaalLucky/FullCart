using FullCart.Application.Interfaces;
using System;
using System.Linq;

namespace FullCart.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
