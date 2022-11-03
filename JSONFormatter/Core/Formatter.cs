using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFormatter.Core;
public class Formatter
{
    public readonly Settings settings;

    public Formatter(Settings settings)
    {
        this.settings = settings;
    }

    public Formatter() : this(new Settings()) { }

    public Output Format(string s)
    {
        StringBuilder b = new();

        char prev = '\0';


        foreach(char c in s)
        {
            if (Char.IsWhiteSpace(c)) continue;
            if (prev == ':')
            {
                b.Append(' ');
            }
            if (prev == ',')
            {
                newIndentedLine(b);
            }
            if (c == '{')
            {
                b.Append(c);
            }
            if (c == '}')
            {
                if (prev != '{')
                {
                    b.Append('\n');
                }
                b.Append(c);
            }
            if (c != '{' && c != '}')
            {
                if (prev == '{')
                {
                    newIndentedLine(b);
                }
                b.Append(c);
            }
            prev = c;
        }

        var result = b.ToString();
        return new Output(result, null);
    }

    private void newIndentedLine(StringBuilder b)
    {
        b.Append('\n');
        for (var i = 0; i < settings.IndentSize; i++)
        {
            b.Append(" ");
        }
    }

    public record Settings(
        ushort IndentSize = 2
    );

    public record Output(
        string result,
        string? error
    )
    {
        public override string ToString() => result;
        public static implicit operator string(Output o) => o.result;
    }
}
