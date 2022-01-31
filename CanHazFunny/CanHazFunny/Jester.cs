namespace CanHazFunny;

public class Jester : IJester, IJoke
{
    public string GetJoke()
    {
        JokeService joke = new();
        return joke.GetJoke();
    }

    public string TellJoke()
    {
        return "work in progress";
    }
}
