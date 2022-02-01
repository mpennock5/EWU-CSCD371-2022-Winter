using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
  

    [TestMethod]
    public void Jester_HasJokeOutputDependancy_True()
    {
        JokeService jokeService = new JokeService();
        JokeOutput jokeOutput = new JokeOutput();
        Jester jester = new Jester(jokeOutput, jokeService);

        Assert.AreEqual(jester.JokeOutput, jokeOutput);
    }

    [TestMethod]
    public void Jester_HasJokeServiceDependancy_True()
    {
        JokeService jokeService = new JokeService();
        JokeOutput jokeOutput = new JokeOutput();
        Jester jester = new Jester(jokeOutput, jokeService);

        Assert.AreEqual(jester.JokeService, jokeService);

    }
    [TestMethod]
    public void Jester_JokeDoesNotContainChuckNorris_True()
    {
        JokeService jokeService = new JokeService();
        JokeOutput jokeOutput = new JokeOutput();
        Jester jester = new Jester(jokeOutput, jokeService);

        jester.TellJoke();

        Assert.IsFalse(jester.Joke!.Contains("Chuck Norris"));

    }
}   
     