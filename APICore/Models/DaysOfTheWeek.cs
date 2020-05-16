using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Models
{
    public enum Days{
        Domingo,
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado
    }
    public class DaysOfTheWeek
    {
        public int Id { get; set; }
        public Days Name { get; set; }
        [JsonIgnore]
        public TimeSheet TimeSheet { get; set; }
        public int TimeSheetId { get; set; }
    }
}
