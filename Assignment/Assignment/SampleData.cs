using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private List<string>? _CsvRows;
        private string peopleCSV = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("Assignment.dll", "People.csv");

        public SampleData()
        {
            IEnumerable<string> CSV = File.ReadAllLines(peopleCSV);
            CsvRows = CSV;
        }
        //double check that the query is being cached as a list.
        //may need additional property that caches the rows data or query might run for every function (not good).
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
        {
            List<string> split = CsvRows.Select(x => x.Split(',')[6]).Distinct().ToList();
            split.Sort();

            return split;
        }
           

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
