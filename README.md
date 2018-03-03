# ProjectVEML
simple &amp; easy HTML alternative

HTML is boring and don't lie no one likes writing data tables like this...

<pre>
  <code>
  &lt;table&gt;
	&lt;tr&gt;
		&lt;th&gt;Name&lt;/th&gt;
		&lt;th&gt;ID&lt;/th&gt;
		&lt;th&gt;Gender&lt;/th&gt;
	&lt;/tr&gt;
	&lt;tr&gt;
		&lt;td&gt;Jacob&lt;/td&gt;
		&lt;td&gt;0&lt;/td&gt;
		&lt;td&gt;Male&lt;/td&gt;
	&lt;/tr&gt;
		&lt;tr&gt;
		&lt;td&gt;Frank&lt;/td&gt;
		&lt;td&gt;1&lt;/td&gt;
		&lt;td&gt;Male&lt;/td&gt;
	&lt;/tr&gt;
		&lt;tr&gt;
		&lt;td&gt;Maja&lt;/td&gt;
		&lt;td&gt;2&lt;/td&gt;
		&lt;td&gt;Female&lt;/td&gt;
	&lt;/tr&gt;
		&lt;tr&gt;
		&lt;td&gt;Fin&lt;/td&gt;
		&lt;td&gt;3&lt;/td&gt;
		&lt;td&gt;Male&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;
  </code>
</pre>
but what if we can write them like this....
<pre>
<code>
@table
@ths->text:: Name |&| ID |&| Gender
@tds->text:: Jacob |&| 0 |&| Male
@tds->text:: Frank |&| 1 |&| Male
@tds->text:: Maja |&| 2 |&| Female
@tds->text:: Fin |&| 3 |&| Male
@endTable

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
