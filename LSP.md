# Liskov Substitution Principle

[Home](README.md)

## Defining

Subtypes must be `substitutable` for their base types.

## Violation example of LSP

For instance, we can implement a Rectangle claass in this fashin
```C#
public class Rectangle
{ 
    public virtual int Height { get; set; }
    public virtual int Width { get; set; }
}
``` 

Other classes can operate on instances of this rectangle type

```C#
public class AreaCalculator
{ 
    public static int CalculateArea(Rectangle r)
    {
        return r.Height * r.Width;
    }
}
``` 

Square is a rectangle, we can create a class Squeare that inherits from Rectangle

```C#
public class Square: Rectangle
{ 
    private int _height;

    public override int Height 
    {
        get { return _height; }
        set
        {
            _width = value;
            _height = value;
        }
    }

    // Width implemented similary
}
``` 

The problem with this design occurs when code expects to be able to work a reatangle, 
but an instance of a square is used instead.

```C#
Rectangle myRect = new Square();
myRect.Width = 4;
myRect.Height = 5;

Assert.Equal(20, AreaCalculator.CalculateArea(myRect));

// Actual Result: 25
``` 
We get unexpected behavior. 
The square is not substitutable for the rectangle everywhere a rectangle is used 
and thus vioates LSP.

## Detecting LSP Violations in Your Code

> Type checking with `is` or `as` in polymorphic code that's often a clue that LSP is being violated.
```C#
foreach(var employee in employees)
{
    if(employy is Manager)
    {
        Helpers.PrintManager(employee as Manager);
        break;
    }
    // you migth add additional subtypes like Director or Executive
    Helpers.PrintEmployee(employee);
}
```
Corrected
```C#
foreach(var employee in employees)
{
    employee.Print();
}
```
the Print functionality could be moved from a halper into the type itself.
Be careful not violate the Single Responsibility Principle when following this approach.

Another approach:
```C#
foreach(var employee in employees)
{
    // can work with any kind of employee
    Helpers.PrintEmplyee(employee);
}
```
In this case, we may only moving the problem code, but the code in question, 
the foreach loop now no longer violate LSP.

> Null checks

https://ardalis.com/nulls-break-polymorphism/

> NotImplementedException

```C# 
public interface INotificationService
{
    void SendText(string SmsNumber, string message);
    void SendEmail(string to, string from, string subject, string body);
}

public class SmtpNotificationService : INotificationService
{
    public void SendEmail(string to, string from, string subject, string body)
    {
        // actually send email here
    }

    public void SendText(string SmsNumber, string message)
    {
        throw new NotImplementedException();
    }
}
```

## Fixing LSP Violations

### Follow the "Tell, Don't Ask" principle
Don't ask instances for their type and then conditionally perform different actions, 
but instead, encapsulate that logic in the type itself and tell it to perform an action.

### Minimize null checks with 
- C# features: null conditional operators, and null coalescing operators
- Guard clauses to use exceptions to prevent null values from reaching the primary logic in your methods
- Null Object design pattern

### Follow ISP and be sure to fully implement interfaces