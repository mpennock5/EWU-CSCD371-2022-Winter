using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private IEnumerable<string>? _CsvRows;
        private string peopleCSV = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("Assignment.dll", "People.csv");

        public SampleData()
        {
            IEnumerable<string> CSV = File.ReadAllLines(peopleCSV);
            CsvRows = CSV;
        }
        // 1.
        // Returns each row as a single string. Read up on chapter 13 and 15 for syntax
        public IEnumerable<string> CsvRows 
        { 
            get
            {
                return _CsvRows ?? throw new ArgumentNullException();
            }
            set
            {
                _CsvRows = value.Where(x => x != null).Skip(1).ToList();
            }

        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
