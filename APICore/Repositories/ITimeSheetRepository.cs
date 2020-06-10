﻿using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface ITimeSheetRepository
    {
        void Add(TimeSheet timeSheet);
        TimeSheet GetTimeSheet(int addressId, string cpf);
        TimeSheet Find(int timeSheetId, string cpf, int addressId);
        TimeSheet Find(string cpf, int addressId);
        void Remove(int timeSheetId, int addressId, string cpf);
        void Update(TimeSheet timeSheet);
        IEnumerable<TimeSheet> GetTimeSheets(string cpf);
        bool TimeSheetExists(TimeSheet timeSheet);
    }
}
