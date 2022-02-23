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
using static Indentional.Text;

public void DoDoingDone()
{
    if (SomethingIsTrue) 
    { 
        if (SomethignIsStillTrue)
        {
            throw new GreatException(Indent(@"
                You tried to do something tricky, but something was not true twice in i row.
                It might be better to do this:
                    
                    DoDoingDone(checkForSomethingTrue: false);
                
                Don't ya think?"))
        }
    }
}
```

This will output the following text: 

```
You tried to do something tricky, but something was not true twice in i row. It might be better to do this:
                    
    DoDoingDone(checkForSomethingTrue: false);
                
Don't ya think?
```

It can also be used as an extension method:

```C#
throw new GreatException(@"
    You tried to do something tricky, but something was not true twice in i row.
    It might be better to do this:
                    
        DoDoingDone(checkForSomethingTrue: false);
                
    Don't ya think?
".Indent());
```

No more bleeding eyes. Except when using preprocessor directives. But that's another story.

## What does it actually do?

- Given a string, it will "measure" the indentation of the first indented line and use this as a baseline 
for the rest of the text. In this way you can use the same indentation for the entire text without
getting your spaces or tabs mixed into the resulting string.

- It also handles newlines in the same way as markdown. One newline will not show up in the resulting 
string, but two will. So in your code, you can break the text wherever you want, but the result message 
will still look great (with no unintended line breaks) in logs, alerts and the like.