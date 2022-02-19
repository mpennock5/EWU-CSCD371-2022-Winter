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
        SampleData sample = new();
        List<string> rows = (List<string>)sample.CsvRows;

        Assert.AreEqual<string>("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", rows[0]);
       
    }

    [TestMethod]
    public void UniqueSortedListofStates()
    {
        SampleData sample = new();
        
        IEnumerable<string> states = sample.GetUniqueSortedListOfStatesGivenCsvRows();

        Assert.AreEqual<string>("AL", states.First());
        Assert.AreEqual<string>("WV", states.Last());   
    }

    [TestMethod]
    public void UniqueSortedListString()
    {
        SampleData sample = new();

        string states = sample.GetAggregateSortedListOfStatesUsingCsvRows();

        Assert.AreEqual<string>("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, " +
                                "NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", states);
    }
}
