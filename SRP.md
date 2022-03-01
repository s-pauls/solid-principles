# Single Responsibility Principle

[Home](README.md)

## Defining

Each softwear module should have only one and only one reason to change.

The individual classes and methods in our applications define what the application does, and how it does it.
So, module means as class or method

- Multipurpose tools don't perfome as well as dedicated tools  
- Dedicated tools are easier to use
- A problem with one part of a multipurpose tool can impact all parts

What is **Responsibility**? - Reasons to Change

Responsibilities in your code represent things that may change at different times for different reasons.
Each one is an axis of change.

>The potential source of changes to your application can help you identify when might be violating SRP

 ## Coupling, Cohesion, and Conserns

**Tight Coupling**
Binds two (ore more) details together in a way that's difficult to change.

**Loose Coupling**
Offers a modular way to choose which details are involved in particular operation.

**Separation of Concerns**
Programs should be separated into distint sections, each addressing a separate concern, or set of information that affects the program.

This [example](https://github.com/s-pauls/solid-principles/blob/main/ArdalisRating/RatingEngine.cs) demonstrates violation of SRP:
- Logging (using Console object)
- Persistence (reading data from file)
- Encoding Format (JSON format only)
- Business Rule - Type of Policy
- Validation
- Age Calculation

As result it  difficult to test one responsibility in isolation