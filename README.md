<h1>What is VEML?</h1>
<p>VEML is a free, open-source and easy to learn markup language that was implemented in C# and can be converted to HTML or used as an alternative to other languages like JSON, XML or YAML.</p>
<h2>VEML Variations</h2>
<p>VEML comes in two similar syntaxes, one for the HTML&nbsp;and other for the&nbsp;data-interchange.</p>
<p>Both of the two styles share some similarities and both of them are easy to remember and write.</p>
<h3>&nbsp;1st - The data-interchange syntax</h3>
<p>For example, the following JSON code...</p>
<ol>
<li><span style="background-color: #999999;"><strong>&nbsp;"Item1": {</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; "Name": "Pistol",</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; "Ammo": "9mm",</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; "MagazineSize": 20</strong></span></li>
<li><span style="background-color: #999999;"><strong>}</strong></span></li>
</ol>
<p>and the following XML code...</p>
<ol>
<li><span style="background-color: #999999;"><strong>&lt;Item1&gt;</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; &lt;Name&gt;Pistol&lt;/Name&gt;</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; &lt;Ammo&gt;9mm&lt;/Ammo&gt;</strong></span></li>
<li><span style="background-color: #999999;"><strong>&nbsp; &nbsp; &lt;MagazineSize&gt;20&lt;/MagazineSize&gt;</strong></span></li>
<li><span style="background-color: #999999;"><strong>&lt;/Item1&gt;</strong></span></li>
</ol>
<p>is the same as the following VEML code...</p>
<ol>
<li><span style="background-color: #999999;"><strong>@Item1</strong></span></li>
<li><span style="background-color: #999999;"><strong>let::Name::String::Pistol</strong></span></li>
<li><span style="background-color: #999999;"><strong>let::Ammo::String::9mm</strong></span></li>
<li><span style="background-color: #999999;"><strong>let::MagazineSize::Number::20</strong></span></li>
</ol>
<p>The difference in the line count between to JSON/XML and VEML is small but VEML looks better and it's much more easy to read and understand so, let's break up the previous VEML code and understand it better...</p>
<p>'@' tells the parser that we are defining a new object and the object name is written right after it.</p>
<p>'let' tells the parser that we are defining a new member and '::' is used as a separator for the inputs, the 1st input is the name of the member, the 2nd input is the type of the member, either String, Number, Boolean or Object, the 3rd input is the value of the member.</p>
<h3>&nbsp;2nd - The HTML syntax</h3>
<p>As said before VEML can be converted to HTML but with a slightly&nbsp;different&nbsp;syntax.</p>
<p>let's say you want to create a paragraph...</p>
<p>In HTML...</p>
<ol>
<li><strong><span style="background-color: #999999;">&lt;html&gt;</span></strong></li>
<li><strong><span style="background-color: #999999;">&nbsp; &nbsp; &lt;body&gt;</span></strong></li>
<li><strong><span style="background-color: #999999;">&nbsp; &nbsp; &nbsp; &nbsp; &lt;p&gt;This's HTML paragraph&lt;/p&gt;</span></strong></li>
<li><strong><span style="background-color: #999999;">&nbsp; &nbsp; &lt;/body&gt;</span></strong></li>
<li><strong><span style="background-color: #999999;">&lt;/html&gt;</span></strong></li>
</ol>
<p>In VEML...</p>
<ol>
<li><span style="background-color: #999999;"><strong>~@html</strong></span></li>
<li><span style="background-color: #999999;"><strong>~@body</strong></span></li>
<li><span style="background-color: #999999;"><strong>@paragraph-&gt;text::This's VEML</strong></span></li>
</ol>
<p>did you see how it's how much code you write less in VEML?</p>
<p>That's why VEML was created, to simplify web creation.&nbsp;</p>
<p>this page is still under construction....</p>
