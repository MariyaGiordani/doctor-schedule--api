using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IDaysOfTheWeekRepository
    {
        void Add(DaysOfTheWeek daysOfTheWeek);
        IEnumerable<DaysOfTheWeek> GetAll();
        DaysOfTheWeek Find(int daysId, int timeSheetId);
        void Remove(int daysId, int timeSheetId);
        void Update(DaysOfTheWeek daysOfTheWeek);
        IEnumerable<DaysOfTheWeek> GetDaysOfTheWeek(int timeSheetId);
        //bool AddressExists(DaysOfTheWeek daysOfTheWeek);
        //bool AddressExists(int addressId);
    }
}
