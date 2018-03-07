# ProjectVEML
simple &amp; easy HTML alternative
What you see is a new markup langauge called <b>veml</b> or Very Easy Markup Langauge. With <b>veml</b> you can write less code 
and get the same results as you would exepect them, not only <b>veml</b> can be converted to 100% pure html but it can be also used 
separately like JSON and YAML in application. Take a look at the following example...<br>
We have a <b>.veml</b> called items and it's contents is as follows...<br>
<pre>
<code>
@Item1
let::Name::String::Axe
let::Durability::Number::100
let::Speed::Number::0.5
</code>
</pre>
<br>
the code above is the same as the following JSON code...
"Item1" : {
  "Name": "Axe",
  "Durability" 100,
  "Speed": 0.5
}
<br>
Which means that we have an object with 3 properties called Name, Durability and Speed. Did you see how much time does <b>veml</b> save for you? 
Start using veml now and tell me what you think!
