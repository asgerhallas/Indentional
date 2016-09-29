# Indentional

Have you ever written a great error message for your library...

```C#
public void DoDoingDone()
{
    if (SomethingIsTrue) 
    { 
        if (SomethignIsStillTrue)
        {
            throw new GreatException(@"You tried to do something tricky, but something was not true twice in i row.
It might be better to do this:

    DoDoingDone(checkForSomethingTrue: false);
    
Don't ya think?")
        }
    }
}
```

... only to get sore eyes from the outdented multiline string?

I know I have. But now I use Indentional just like this:

```C#
using static Indentional.Indent;

public void DoDoingDone()
{
    if (SomethingIsTrue) 
    { 
        if (SomethignIsStillTrue)
        {
            throw new GreatException(_(@"
                You tried to do something tricky, but something was not true twice in i row.
                It might be better to do this:
                    
                    DoDoingDone(checkForSomethingTrue: false);
                
                Don't ya think?"))
        }
    }
}
```

No more bleeding eyes. Except when using preprocessor directives. But that's another story.