public class Foo { }
public abstract class Bar
{
    public string Name { get; set; }

    public abstract string TheAnswer();
    public virtual string GetMyQuestion()
    {
        return "The answer to life";
    }


    public void SealedMethod()
    {

    }
}

public class Baz : Bar
{
    public override string TheAnswer()
    {
        return "forty two";
    }
}
public class Aaa : Bar
{
    public override string TheAnswer()
    {
        return "What was the question again?";
    }

    public override string GetMyQuestion()
    {
        return "No, really, what's the question?";
    }
}

public sealed class Josh
{

    public void blah()
    {
        Foo f = new Foo();

        Bar bar = new Baz();
    }

    protected void XXX()
    {

    }

}


interface IStringParser : IParser<IEnumerable<string>>
{
    InputModel Parse(IEnumerable<string> input);
}

interface IXmlParser : IParser<System.Xml.XmlDocument>
{
    InputModel Parse(System.Xml.XmlDocument input);
}

interface IParser<TInput>
{
    InputModel ParseFromInput(TInput input);
}