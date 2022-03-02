# Open / Closed Principle

[Home](README.md)

## Defining

Software entities (classes, modules, functions, etc) should be open for extension, but closed for modification

It should be possible to change the behavior of a method without editing its source code.

| Open to `extension` | Closed to `modification` |
| --- | --- |
| New behavior can be added in the future | Changes to source or binary code are not required |
| Code that is closed to extension has `fixed` behavior | The only way to change the behavior of code that is closed to extension is to change the code itself |

Why Should Code Be Closed to Modification?
- Less likely to introduce bugs in code we don't touch or redeploy
- Less likely to break dependent code when we don't have to deploy updates
- Fewer conditionals in code that is open to extension results in simpler code

We need to balance that abstraction with concreteness. Abstraction adds complexity.

Predict where variation is needed and apply abstraction as needed

## How Can You Predict Future Changes?
- Start concrete
- Modify the code the first time or two
- By the third modification, consider making the code open to extension for that axis of change
 
## Typical Approaches to OCP
### Parameters ()


```C#
public class DoOneThing
{ 
    public void Execute()
    {
        Console.WriteLine("Hello world.");
    }
}
``` 

```C#
public class DoOneThing
{ 
    public void Execute(string message)
    {
        Console.WriteLine(message);
    }
}
```

### Inheritance

```C#
public class DoOneThing
{ 
    public virtual void Execute()
    {
        Console.WriteLine("Hello world.");
    }
}
public class DoAnotherThing
{ 
    public override void Execute()
    {
        Console.WriteLine("Goodbye world.");
    }
}
```  

### Composition / Injection

```C#
public class DoOneThing
{
    private readonly MessageService _messageService;
    
    public DoOneThing(MessageService messageService)
    {
        _messageService = messageService; 
    }

    public virtual void Execute()
    {
        Console.WriteLine(_messageService.GetMessage());
    }
}
```  

### Extension method

### Prefer implementing new features in new classes
Why use a New Class?
- Design class to suit problem at hand
- Nothing in current suystem depends on it
- Can add behavior without touching existing code
- Can follow Single Responsibility Principle
- Can be unit-tested