using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQAndExtensionMethod
{
    class MyDataRow
    {
        [CsvColumn(Name = "Year", FieldIndex = 1)]
        public int Year { get; set; }
        [CsvColumn(Name = "Number of tropical storms", FieldIndex = 2)]
        public byte TropicalStormCount { get; set; }
        [CsvColumn(Name = "Number of hurricanes", FieldIndex = 3)]
        public byte HurricaneCount { get; set; }
        [CsvColumn(Name = "Number of major hurricanes", FieldIndex = 4)]
        public byte MajorHurricaneCount { get; set; }

        // Accumulated Cyclone Energy
        [CsvColumn(Name = "ACE", FieldIndex = 5)]
        public decimal ACE { get; set; }

        [CsvColumn(Name = "Deaths", FieldIndex = 6)]
        public int Deaths { get; set; }

        [CsvColumn(Name = "Strongest storm", FieldIndex = 7)]
        public string StrongestStorm { get; set; }

        [CsvColumn(Name = "Damage USD", FieldIndex = 8)]
        public string DamageUSD { get; set; }

        [CsvColumn(Name = "Retired names", FieldIndex = 9)]
        public string RetiredNames { get; set; }

        [CsvColumn(Name = "Notes", FieldIndex = 10)]
        public string Notes { get; set; }


    }
}
