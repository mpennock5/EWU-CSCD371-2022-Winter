using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FunStuff.Tests;
[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void SimpleStringReflection()
    {
        StringBuilder text = new ("Hello! My name is Inigo Montoya");
        Type type = text.GetType();
        MethodInfo[]? methods = type.GetMethods();
        Assert.AreEqual<int>(87, methods.Length);
    }

    [TestMethod]
    public void StringBuilderAppendLine()
    {
        StringBuilder text = new("Hello! My name is Inigo Montoya");
        Type type = text.GetType();
        MethodInfo[]? methods = type.GetMethods();
        Assert.AreEqual<int>(87, methods.Length);
    }

    [TestMethod]
    public void GetMember()
    {
        const string secondLine = "You killed my father!";
        const string firstLine = "Hello! My name is Inigo Montoya";
        StringBuilder text = new(firstLine);
        Type type = text.GetType();
        MethodInfo[]? methods = type.GetMethods();
        Assert.AreEqual<int>(87, methods.Length);
        IEnumerable<MethodInfo>? appendMethods = type.GetMethods().Where(item =>
           item.Name == "AppendLine");
        MethodInfo? stringAppendMethod = appendMethods.First(method =>
        {
            var parameters = method.GetParameters();
            return parameters.Length == 1 &&
               method.GetParameters().Any(param =>
                   param.ParameterType == typeof(string));
        });
        Assert.AreEqual<string>(
            nameof(StringBuilder.AppendLine), stringAppendMethod.Name);

        StringBuilder? actual = (StringBuilder?)stringAppendMethod?.Invoke(
            text, new string[] { secondLine });

        Assert.AreEqual<string?>(
            new StringBuilder(firstLine).AppendLine(secondLine).ToString(),
            actual?.ToString());

        Console.WriteLine(actual?.ToString());

        Assert.AreEqual<string?>(
            $"{firstLine+ Environment.NewLine+secondLine}", actual?.ToString());
    }

    [TestMethod]
    public void LoadThing1Assembly()
    {
        

        Assembly assembly = Assembly.LoadFile(
            @"C:\Git\EWU\EWU-CSCD371-2022-Winter\Lecture\FunStuff\bin\Debug\net6.0\FunStuff.dll");
        Assert.AreEqual<int>(5, assembly.GetTypes().Count());
        foreach (string item in assembly.GetTypes().Select(item => item.Name))
        {
            Console.WriteLine(item);
        }
        Type thing1Type = assembly.GetType("FunStuff.Thing1")??throw new InvalidOperationException("Oh?  What happened?");
        dynamic? thing1 = Activator.CreateInstance(thing1Type);
        thing1!.Name = "Inigo Montoya";
        try
        { thing1.ThisMethodDoesNotExist(); }
        catch (Exception ex) { }
        Assert.AreEqual<string>(
            $"Princess Buttercup known as {thing1!.Name}",
            thing1?.ConcatName("Princess", "Buttercup"));
        
    }


    [TestMethod]
    public void LoadCsv()
    {
        string csv = @"Name,Age,Address
Inigo,42,1st Main
Buttercup,40,2nd Main";

        var list = FunStuff.CsvLoader.Load<Thing1>(csv);

        Assert.AreEqual(2, list.Count());
        Assert.AreEqual("Buttercup", list.Last().Name);
        Assert.AreEqual("42", list.First().Age);
    }
}