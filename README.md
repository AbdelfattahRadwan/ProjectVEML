# Overview

VEML stands for **V**ery **E**asy **M**arkup **L**anguage which is a new free, open-source and easy to learn data interchange language,
implemented in C# and it parsed and used as a versatile alternative for other data interchange languages like XML, JSON and YAML.

VEML was made with with simplicity in mind, for example: if you want to make a simple webpage that contains one paragraph and one button.

In HTML you write the following...

```html
<html>
    <head>
        <title>My webpage</title>
    </head>
    <body>
        <p>This's a paragraph!</p>
        <button>This's a button!</button>
    </body>
</html>
```

Did you see how many lines did you write?

Now in VEML you write...

```
~@html
~@head
@title->text:: My webpage
~@body
@paragraph->text:: This's a paragraph!
@button->text::This's a button!
```

In VEML you write 3 less lines and the code looks much simpler than that of the HTML!

That's one use of VEML - Writing simple code that converts to HTML directly!

But what if you want to use it let's say for example like a data-interchange language (like JSON, XML or YAML)

Actually you can!

For example: the following XML code..

```xml
<item1>
    <name>Axe</name>
    <damage>50</damage>
    <speed>2</speed>
    <type>Tool</type>
</item1>
```

and the following JSON code..

```json
{
    "item1":{
        "name": "Axe",
        "damage": 50,
        "speed": 2,
        "type": "Tool"
    }
}
```

Can represented in VEML by the following code...

```
@item1
@let :: name :: STRING :: Axe
@let :: damage :: NUMBER :: 50
@let :: speed :: NUMBER :: 2
@let :: type :: STRNG :: Tool
```

Did you see how the elegent is the code and how easy it is to read it?

Now comes the part where we see how we can serialize a simple C# ```Object``` in VEML

```csharp
using System;
using VEML;

public class MyObject
{
    public string Name { get; set; }
    
    public int ID { get; set; }
}

public class Program
{
    public static void Main (string[] args)
    {
        MyObject obj = new MyObject()
        {
            Name = "Object1",
            ID = 0
        };

        // An object that represents a serializable veml contianer.
        V_Node node = new V_Node();

        // Set the node name.
        node.Name = "TestNode1";
        node.AddValue(type: "STRING", key: "Name", value: obj.Name);
        node.AddValue(type: "NUMBER", key: "ID", value: obj.ID);

        Console.WriteLine(node.ToString());

        /*
            The previous code results in the following...

            @TestNode1
            @let :: Name :: STRING :: Object1
            @let :: ID :: NUMBER :: 0
        */

         // To get the values back after they have been serialized...

        V_Node node2 = new V_Node();

        V_Parser.Parse(node.ToString(), out node2);

        Console.WriteLine(node2.GetString("Name"));
        Console.WriteLine(node2.GetNumber("ID"));
    } 
}
```

VEML is very easy to learn, has simple & elegant syntax and open-source!
