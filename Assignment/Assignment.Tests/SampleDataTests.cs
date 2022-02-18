using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CSVRows()
    {
        SampleData sample = new SampleData();
        List<string> rows = (List<string>)sample.CsvRows;

        Assert.AreEqual<string>("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", rows[0]);
       
    }

    [TestMethod]
    public void UniqueSortedListofStates()
    {
        SampleData sample = new SampleData();
        
        IEnumerable<string> states = sample.GetUniqueSortedListOfStatesGivenCsvRows();

        Assert.AreEqual<string>("AL", states.First());
        Assert.AreEqual<string>("WV", states.Last());   
    }
}
