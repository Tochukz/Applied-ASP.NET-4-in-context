# Applied ASP.NET 4 in Context (2011)
__By Adam Freeman__  
[Github Source Code](https://github.com/Apress/applied-asp.net-4-in-context)

## PART I: Getting Started

### Chapter 1: Introduction

### Chapter 2: Getting Ready
__Tools To Install__
* Visual studio
* Microsoft Web Platform Installer
* Microsoft SQL Server
* Internet Information Services (IIS)
* SQL Server Management Studio
* _Ninject_ for Dependency Injection ([Ninject.org.](Ninject.org))

### Chapter 3: Putting ASP.NET in Context  
__The Structure of ASP.NET__  
ASP.NET has a base called the _Core ASP.NET Platform_.
On top of the core is the _Web Forms_ and the _MVC framework_ which sits side by side.  
You'll need to master the core ASP.NET features to get the most out of both the Web Forms and the MVC framework.  
The set of features that the core platform supports is extensive and they can be used to create web applications in their own right.  

__Web Webforms__  
There are three major drawbacks of Webforms:
1. The embedded data to maintain state may impact performance for large application.  
2. Unit testing is impossible though integration testing can be done.
3. They become difficult to maintain over time.

__jQuery and ASP.NET Ajax__  
ASP.NET 4 and MVC framework version 3 includes jQuery. jQuery replaces the ASP.NET Ajax library. You can still elect to use ASP.NET Ajax but jQuery is easier to use, is more flexible, and produces cleaner web pages.  

## PART II: Getting to Know ASP.NET  

### Chapter 4: Working with Pages  
The empty ASP.NET Web application template contains three files:
1. __Properties:__ It contains the settings for the project - build options, deployment configuration, and so on.  
2.  __Web.config:__ It contains the configuration information for the ASP.NET application. It is similar to _App.config_ in other types of .NET application.  
3. __References:__ It contains references to the .NET assemblies that the project needs to run.  

ASP.NET support two different, but related, models for combining program logic and HTML:
1. Using code blocks (aka Code Fragment)
2. Using code-behind files  

__Temporary Class Files__  
When the ASP.NET server receives a request for a dynamic page, it creates the temporary class from the `.aspx` file, compiles it, and then calls the method in the compiled code to create the HTML page that will be sent back to the browser.  
The temporary class for a dynamic web page is created and compiled only when there is a change in the `.aspx` file. Otherwise, once a class has been created and compiled, it will be used for subsequent requests for the same page.

__Using Manual Event Wire-up__  
Auto event wire-up looks for methods names that match the pattern _Page_EventName_ and registers those methods as handlers for the appropriate event. Auto event wire-up is generally useful and enabled by default. You can disable this feature through the Page directive, like this:  
```
<%@ Page CodeFile="Default.aspx.cs" Inherits="SimplePages.Default" AutoEventWireup="false" %>
```  
When auto event wire-up is disabled, the _Page_Load_ method won't be called unless you wire the method to the _Load_ event.

### Chapter 5: Working with Context and Events
__Page Events__   
Some useful page events are as follows:  
* _PreInit_, _Init_ and _InitComplete_, are invoked as the ASP.NET server processes the request from the client browser and populates the context for the request.
* _Load_, the most important event. The code to configure the page control is typically place in the Page Load handler.
* _PreRender_, called before the page is rendered.  
* _Unload_, called after the response has been sent back to the server. Often used to release resources such as database connections or opened files.

The _PreInit_ method can be used to specify a master page programmatically, rather than in a Page directive.  
The _Init_ event is a good place to create resources that you will need for your page, such as database connections.  
If you want to modify view state data, you must wait until the _InitComplete_ method is invoked.

The _PreRender_ event is invoked just before ASP.NET renders the HTML for the page. The common action performed in response to the _PreRender_ method is to make last-minute changes that reply on the final state of all the controls on the page.

__Application Events__  
Application events are handled using a global application class. You can add a `Global Application Class` template(`Global.asax`) to you project.
Useful Application Events:
* _Start_, _End_: Invoked when  the application starts and just before it is destroyed, respectively.  
* _Session.Start_, _Session.End_: Called sessiona are created and destroyed, respectively.  
* _AuthenticateRequest_: Invoked when ASP.NET has established the identity of a user.
* _Error_: Invoked when a page encounters an error that cannot be handled elsewhere.  
* _BeginRequest_, _EndRequest_: Invoked as the first and last action respectively when the ASP.NET server received a request from a client and processes the request respectively.  

The _Start_ event is a good place to create resources that will be used throughout your application, and the _End_ event is a good place to ensure that they are released.

### Chapter 6: Working with Forms and State  
ASP.NET provides a range of different state mechanisms. The four most important and widely used state are: form, view, session and application.  
Data that span multiple pages is called state. ASP.NET provided 4 forms of state:  
1. Form input State
2. View state
3. Session state
4. Application state

Caution: Do not rely on the view state data for any critical application data, including anything to do with security.  

To disable view state entirely for the a page we can set the _EnableViewState_ attribute of the Page directive to false, like this:  
```
<%@ Page Language="C#" CodeBehind="Default.aspx.cd" Inherits="SwinCalculator.Default" EnableViewState="false" %>
```
You can get and set data normally in your code, but the data will be quietly discarded.  

You can apply the _enableviewstate_ attribute for individual controls instead of the whole page.  
```
<div id="results" runat="server" enableviewstate="false" />
```
You can disable view state for a parent control and all the children of the control will automatically have their view state disabled.   

The key difference between session state and view state is that only the session identifier is included in the response that is sent to the client, while the data stored remains on the server.

__Configure Session State__    
Data associated with active sessions are stores in the ASP.NET server process by default. ASP.NET includes support for storing this information and data in a SQL server database. This is useful if you expect a lot of state data or you need to share the same data among multiple servers that are delivering the same application.  You can find details for setting up the database and configuring the ASP.NET framework on MSDN site.

__Using Application State__  
Application state is better suited for storing data items that don't change and that will be used throughout the life of the web application. Database connections are a prime example.  

### Chapter 7: Handling Errors
__Handling Errors with the Application__   
Any errors that are not handled by a page becomes application errors. There types of errors is handled _Application_Error()_ method of the Global application class.

__Configure Custom Errors__  
The _customErrors_ setting only controls what happens if an error is not handled by the Page and the Global class.  

__Using ASP.NET Tracing__  
For _hard failure_ something goes wrong and is expressed using an exception. For _soft failure_, there is no exception but the web application doesn't behave as it should.  
__Enabling Tracing__  
To enable tracing on individual ASP.NET pages, add the _Trace="true"_ attribute to the _Page_ directive.  
To enable tracing on all the pages in the application, add the _trace_ element to the _system.web_ element of _Web.config_ file:  
```
<system.web>
  <trace enabled="true" pageOutput="true" requestLimit="50" localOnly="false" />
</system.web>
```

__Adding Custom Trace Messages__  
The _Page.Trace_ property returns a _System.Web.TraceContext_ object, which you can use to add statements to your code. The tow key methods from th _TraceContext_ class are _Write_ and _Warn_.  

__Viewing a Trace in the Trace Viewer__
First you must enable Trace Viewer by setting the _pageOutput_ attribute to false in the _trace_ element of the _web.config_ file:
```
<system.web>
  <trace enabled="true" pageOutput="false" requestLimit="50" localOnly="false" />
</system.web>
```
After interacting with the page, you can see the Trace Viewer at _http://localhost:1234/Trace.axd_  

The downside of the trace viewer is that it captures every request to the ASP.NET server, and that
can make it hard to figure out what is going on.  
The trace viewer is at its most useful when you can minimize the number of requests that are not
directly related to your bug hunt.

__Setting a Programmatic breakpoint__  
The ability to break the debugger comes with the _System.Diagnostics.Debugger_ class which includes the _Break_ method.

### Chapter 8: Working with Data   
__Creating an Entity Framework Data Model__
1. Right click on your project > `Add` > `New Item`
2. Select _Data_ category on the left and select the _ADO.NET
Entity Data Model_ template on the right.
3. By Convention, the file name should be _YourAppNameModel.edmx_  
4. Select `EF Designer From Database` option from the _Entity Data Model Wizard_. (It is assumed that you already have an existing database or _.mfd_ file if you select this option)
5. Click `Next` > `New Connection...`
6. Make sure you have _Microsoft SQL Server Database File (SqlClient)_ unuder `Data Source` because we are using a `.mdf` data file in this case.
7. Click the `Browse...` and select your existing `.mdf` file.
8. Select _Use Windows Authentication_ if the SQL Server Instance is on the same machine or _Use SQL Server Authntication_ if otherwise. Click `Ok`
9.  Make sure the  _Save connection settings in Web.config as:_ checkbox is checked so that the connection string is preserved in your _Web.config_ file. Click `Next`
10. A prompt may pop up asking you if you want to included the `.mdf` file to your project (if it is not already in your project). You may click `Yes` or `No`. I click `Yes` and the `.mdf` file was added to my project's `App_Data` folder.
11. Select your desired version of Entity Framework and click `Next`  
12. Select the database objects(table, store procedures, views, etc) that you want to include in your model.
13. Make sure the following checkboxes are checked:
  * _Pluralize or singularize generate object namespace_
  * _Include foreign key columns in the model_  
  * _Include selected Stored Procedure in the model_  
Click `Finish`
14. Click `Ok` on all the prompt asking if you want to run the database file.
15. At the end you should find _YourAppName.edmx_ item in you project. And under it is you  should find the following items:
  * `YourAppName.Context.tt`
  * `YourAppName.Designer.cs`,
  * `YourAppName.edmx.diagram`
  * `YourAppName.tt`
16. The _EntityFramework_ and it'd dependencies will be added to you list of _References_

__Viewing the Entity Data Model__  
Double click the `YourAppname.edmx` file to view your data model diagram. Each rectangular box in the diagram represents a generated _entity class_ which maps to a database table of the same name.

__Importing the Stored Procedures__
To make the imported stored procedures available for use in the application, we create a new entity type that will represent the result of calling the stored procedure. To do this:
1. Double click on the `ModelName.edmx` file to expose the Diagram
2. On the canvas of the diagram, right click > `Add New` > `Function Import..`
3. On the _Add Function Import_ window, enter a name for the function and select a stored procedure.
4. Click on the _Get Column Information_ button
5. Select a Complex type and click okay.
6. Save all the changes

__Managing Concurrency__  
The Entity Framework uses an _optimistic concurrency_ model by default. In this case _optimistic_ means that we cross our finger and hope that we don't get overlapping page requests that leads to conflicting data changes.
Database locks should never be used in a web application without a lot of careful thought and testing.  

To enable concurrency checking, follow these steps:  
1. Open the data model file i.e `.edmx` file
2. Right-click the property that you want to modify and select Properties from the pop-up menu.  
3. Change the value of the Concurrency Mode property to Fixed.
Once you have enabled concurrency checking, the _SaveChanges_ method of the context object will throw a _System.Data.OptimisticConcurrencyException_ if the data you are attempting to modify has been changed since you queried the data model to obtain the entity object.  

### Chapter 9: Styling Content  
You can change the master page that a web page uses by setting a value for the _Page.MasterPageFile_ property in the handler for the _Page.PreInit_ event.

__Managing a Master Page from a Web Page__    
You can access the master page from a web page by using the _Master_ property which returns an instance of the _System.Web.UI.MasterPage_ class. You can then call the _FindControl_ method on the _MasterPage_ to locate an HTML control by name and work with it as you would any other HTML control.

### Chapter 10: Adding Interactivity
__Using jQuery UI__  
Maybe continued later...

### Chapter 12: Working with Routes
Done... Review some parts later

## PART III: Using Web Forms  

### Chapter 13: Putting Web Forms in Context  
Web Forms is essentially a set of user interface controls that build on the core ASP.NET framework state and event features to simulate the stateful and event-driven Windows Forms equivalents.    
Web Forms is ideal for developing applications that are delivered over the Web, but that are not
deeply connected to the underlying web technologies.

__Web Form Weaknesses__
* Poor Maintainability  
* Poor Unit Testability  
* Bandwidth-Heavy View State  
* Inflexibility  
* Low Developer Mindshare  

__Deciding When to Use Web Forms__  
Web Forms can be extremely useful if you have a project with the following requirements:   
* Speed of development  
* Intranet development  
* Short life or low expectations of change  

### Chapter 14: Working with the Web Forms Designer  
__Creating UI Control Event Handlers__  
The Web Forms UI controls implement events that are focused on individual controls. The core events that are common to all Web Forms UI controls are:  
* Init  
* Load  
* PreRender
* Unload
* Disposed
* DataBinding  
These events corresponds to the page-level events introduced in Chapter 5 but apply to a specific control. The additional events available differ from control to control.  

Both the _Click_ and the _Command_ events are invoked when the Button control is clicked. The difference us that the _Command_ event makes it easier to implement a single handler method that can process events from multiple controls, potentially of different types.  

### Chapter 15: Working With Forms controls
You could work directly with the HTML elements, but the value of the Web Forms controls is that you can benefit from the Web Forms property and event support. You can easily configure the controls using property sheets, and also create and register event-handling methods. Another benefit is that you can work with these controls programmatically.  

__Working with Controls Programmatically__  
When working with a Web Forms control, you have programmatic access to all of the properties Visual Studio shows in the properties window when you use the design surface.    

__Using the TreeView Control__  
You can use the _TreeView_ web controller or
_jQuery Tree View Plugin_.   
_TreeView_ control is perfectly usable if you don’t need events, but I would suggest using the jQuery alternative if events are important.

__Using the SiteMapPath Control__  
The SiteMapPath control seems to only work when used in the default page.  

The _jQuery UI_ calendar is recommended over the _Calendar_ Web Control.  

The _[jQuery FormToWizard]()_ plug-in is recommended over the _Wizard_ Web Control.  

__Cool Stuff__  
You can easily create  finite an infinity cyclic iteration using the modulus operator.  
Say I want to output the numbers 0, 1, 2, 0, 1, 2, 0, 1 etc:
```
for(x=0; x<1000; x++){
  console.log(x % 3)
}
```
To get cyclic number of 0, 1, 2, 3, 0, 1, 2, 3 etc just change the denominator to 4 like this `console.log(x % 4)`

### Chapter 16: Customizing Web Form Controls
There are four ways to customize the Web Form controls system:  
1. User Controls
2. Control Templates  
3. Control Adapters
4. Custom Controls  
You can use these features to get fins-grained control over the HTMLL that is emitted and the properties and events that are defined - all while still getting the benefits of the Web Forms design tools.

__Creating a User Control__  
_User Controls_ can be helpful when you have a block of markup that you want to use throughout your application.
_User Controls_ are `.ascx class` files.   

__Using Control Templates__  
Some Web Controls that support templates includes _Menu_, _SiteMapPath_, and _Wizard controls_.   
Many of the other template-enabled controls, such as _GridView_ and _ListView_ are rich data controls.

__Using Control Adapters__  
A _control adapter_ is a mechanism designed to deal with differences between browsers, but we can co-opt it to gain wider influence over a control.  
To create a _control adapter_, we must override three methids from the _WebControlAdapter_ class: _RenderBeginTag_, _RenderEndTag_, and _RenderContents_.

__Creating Custom Controls__  
You can group and extend existing web controls using _user control_ and you can take responsibility for the HTML that a control renders using an _adapter_. But if you want to create an entirely new kin of element, then you need to create a _custom server control_.  

### Chapter 17: Validating Form Data
__Using Server-Side Validation__  
You don't need to take additional steps to enable server-side validation. It is done automatically; once you use the validation controls the validation applied to client side using JavaScript is also applied on the server-side. You can see this by turning off JavaScript on your browser.

__Creating a Custom Validation Function__
For custom validation, you need to implement your validation login twice: one in C# so that it can be applied at the server, and once in JavaScript so that it can be applied in the client.  

### Chapter 18: Using Web Forms Data Sources  
To work with Webform data control you need:
* some data,
* a data source control, and
* a data-bound UI control.

There are different kind of data sources available to deal with different kind of data.
The _LinqDataSource_ control works with an array of objects.
The _LinqDataSource_ control applies a LINQ query to an enumeration of C# objects.  

The most commonly used data sources includes:  
1. _LinqDataSource_ for any LINQ compatible collection such as an `IEnumerable` sequence.
2. _SqlDataSource_ for data access using SQL directly.
3. _EntityDataSource_ for working with Entity Framework.

To enable sorting on an _EntityDataSource_ control, set the _AutoGeneratedWhereClause_ property to true.

__Using LINQ Query Result As Data Source__
Web Forms data sources are initialized before any of the page events are invoked. For this reason, we can not assign value to a field for _LinqDataSource_ in the _Page_PreInit_ or _Page_Init_ page event methods as it will be too late.
Because of this, we can not change the nature of the LINQ query in response to the state of the page, which we would ideally do in the _Page_Load_ method.  

There are two approaches to make data accessible to webform UI control:  
1. Using data source controls  
2. Using Code Behind class to perform LINQ Query

### Chapter 19: Using Web Forms Data Binding  
There are three categories of data-bound controls:
1. Basic
2. Navigation
3. Rich data controls

### Chapter 20: Using the Rich Data Controls  

__Using the ListView Control__  
All that is required is an _ItemTemplate_, all other template of the _ListView_ is optional. But the real value of the _ListView_ control is in how it templates work together. If you just want a simple list, use easier controls such as the _DataList_ control.  

## PART IV: Using the MVC Framework

### Chapter 22: Putting MVC in context
Stories. Can be read anytime.

### Chapter 23: A First MVC Application  
The _Global.asax_ and _Web.config_ files pay the same role for Web Form and MVC application, although there may be slightly different content.   

Notice that there are two _Web.config_ files: _~/Web.config_ and _~/Views/Web.config_ . The second one of these configures Razor.  

__Creating the Domain Model__  
There are two kinds of models: _domain model_ and _view model_.  
It is common practice to create a separate class library project for the domain model and add it as a reference to the MVC framework project.  
The idea is that this helps enforce the separation between the domain model and the rest of the application. This may be a good idea for a real project but for a simple project it is okay to define the domain model within the MVC project.  

__Creating the Repository__    
We don't want to include the code that retrieves and modify data in the controller class because we don't want to create a dependency between the controller and the domain model. To ensure the separation of concern, we use a _repository_, which is an abstract class or an interface that provides the means to work with the persistent data but doesn't say anything about how the data is operated on.  

__Using the Repository__  
The _ViewBag_ is a feature that allows us to pass data from the controller to the view. The _ViewBag_ property returns a _dynamic_ object.   

__Handling the Form POST__  
The convention is to use a _view model_ to pass the main data item that the view s responsible for displaying and use _ViewBag_ to pass supporting data. Using a _view model_ alows us to take advantage of the convenience that _strongly types views_ can offer.   

__Adding Dependency Injection__  
The MVC framework has extensive support for DI, most usefully through the _IDependencyResolver_ interface.    
We create a _dependency resolver_ by implementing the _IDependencyResolver_ interface and then register it with the MVC framework.  The MVC framework will call one of the methods in our dependency resolver every time that it needs to create a new object.  
The MVC framework differentiates between _single registered services_ and _multiple registered services_.  _Single registered service_ have a single class responsible for performing an action, while _multiple registered services_ can have multiple classes , each of which will perform the same action in turn. Controllers are examples of singly registered services. This is because there is only one type that can be used to service a request. Multiple registered services are typically used when there are multiple implementations of the same interface or abstract class.

When the MVC framework wants to create a new instance of a singly registered service, it calls the _GetService_ method, passing in the type that it want to instantiate.   

After creating an implementation for the _IDependencyResolver_ interface which will act as the dependency resolver, you must register is at the _Applcation_Start_ method of the _Global_ application class.

__Using Dependency Injection Container__  
We need a _dependency injection controller_ to make a more flexible and general solution. You are may DI containers available, including, _Ninject_ and _Unity_.   
The first step is to add a reference to the _Ninject_ assembly.  
See [Ninject.org](ninject.org) to learn more.   

### Chapter 24: Implementing a Persistent Repository  

### Chapter 25: Working with Views  
Views that use the ASPX view engine are not Web Forms pages. They are MVC views that use the `<%` and `%>` tags.  For example, calling an HTML helper with traditional tags (`<% Html.DisplayFor(e => e.Name) %>`) is similar to performing the same task using Razor (`@Html.DisplayFor(e => e.Name)`).

__Working with the Model Object__
We can tell _Razor_ to look for classes in additional namespaces by editing the _~/Views/Web.config_ file. The _Web.config_ file configures Razor, and we can extend the set of places it looks for classes by adding items to the _namespaces_ element. For example, adding the namespace for the Model `EventRegistration.Models.Domain.Registration`:
```
<namespaces>
  ...
  <add namespace="EventRegistration.Models.Domain.Registration" />
</namespaces>
```
This allows us to use the model in a view directly:
```
@model IEnumerbable<Registration>
```
Instead of using the fully qualified name:
```
@model IEnumerbable<EventRegistration.Models.Domain.Registration>
```   

__Using Dynamically Types Views__  
With the `@model` directie in place, our view is said to be _strongly typed_. If we omit the `@model` directive, we create a _dynamically types_ view, also referred to as _weakly typed_. Omitting the `@model` directive is equivalent to using `@model dynamic`.  

__Inserting Other Values__  
We can't call methods that return `void` in view because the view inserts what the method returns into the HTML response.  

__Using Razor Conditional Tags__  
How does Razor handle content block of conditional statement?  
```
@if (Model.Count() == 0) {
    <h4>There are no registrations</h4>
}  else {
    <h4>There are @Model.Count() registrations </h4>
    DateTime nextMonth = DateTime.Now.AddMonths(1);
    string nextMonthName = string.Format("{0:MMMM", nextMonth);
    <span>Next Month will be: @nextMonthName</span>
}
```
Razor processes each line in turn. If a line starts with the `<` character, Razor interprets this as a block of HTML that should be written to the output. If the line contains Razor `@` tags, then they are evaluated, and their results are inserted into the HTML as normal.
If the line doesn’t begin with an HTML tag, then Razor assumes that it is dealing with a C# statement and tries to execute the statement. This allows us to mix and match code and HTML in a single block.  

Use the `@:` tag when a line doesn't start with an HTML tag and isn't a C# statement.
```
@: Just a stand alone text string  
```
Use the `<text>` element for multiple lines that is not wrapped in an html tag and is not a C# statement.
```
<text>
  Stand alone text string  
  His name is @Model.Name
</text>
```
__Lazy Loading Iteration Problem__  
When you try to access the properties of a navigation property of an Entity framework model while iterating though a DataSet you my counter the error say 'There is already an open DataReader associated with this Command which must be closed.'  
This problem can be solved in two ways:
1. call the `ToArray()` method of the Data model  
2. Add the following setting to the entity framework data base connection string:  
```
<add name="EFRepository" connectionString="...;MultipleActiveResultSets=true"  />
```
Entity framework is setup to make only one database connection at a time by default.
`MultipleActiveResultSets=true` tell entity framework that is can make multiple connection if needed.
Another solution could be to use `eager loading` in the EF repository implementation.  

__Razor Sections__  
A layout must render each and every section defined in a view, and each section can be rendered only once. Razor will throw an exception if you do not follow these rules.  

__Razor Comments__
If your view requires comments you may want to check if the separation of concern which the MVC design dictates is being followed properly. If you view contents so much login as to require a comment to explain it's complexity, then you should consider moving some of the logic from the view to the controller.   

__Using JQuery Intellisense__  
To enable JQuery Intellisense your view, add the `jquery-validate.vsdoc.js` script to your view  

```
 <script src="@Url.Content("~/Scripts/jquery-validate.vsdoc.js")" type="text/javascript"></script>
```

__Enabling Compile-Time Error Checking__  
Razor views are not compiled, by default, until during run time.  To make your Razor views to be compiled with the rest of the C# code during compile time, you must update the `.csproj` file and change the inner text of the `MvcBuildViews` element from `false` to `true`.
```
<MvcBuildViews>true</MvcBuildViews>
```
Now, all views will be compiled when you build the project and any error from the view will be reported in the Error List just like errors in regular classes are.

### Chapter 26: Using HTML Helpers and Templates
__Creating an External Helper Method__  
An external helper takes the form of a C# extension method that operates on the _Sysyte.Web.Mvc.HtmlHelper_ class.
The MVC framework encodes the values it gets from helper methods to make them safe to display.   
Be careful when rendering unencoded content. Even though it might come from a trusted source today, future changes to your application can create an XSS(cross=site scripting) vulnerability.  

To return an unencoded HTML from your custom helper method, you must return a type of _MvcHtmlString_  

__Creating Form__  
The _Html.BeginForm_ tag will post the form back to the action method where it came from by default. Another overload method accepts parameter for a target action method and controller.  
```
@using(Html.BeginForm("MyAction", "MyController")) {
  ...
}
```  

__Using the Input Helper Methods__    
List of input helpers:
```
@Html.CheckBox("idAndName", boolValue);
@Html.Hidden("idAndName", "value")
@Html.RadioButton("idAndName", "value", checkedBoolValue)
@Html.Password("idAndName", "value")
@Html.TextArea("idAndName", "value", nRows, nCols, null)
@Html.TextBox("idAndName", "value")
```  
The _@Html.CheckBox()_ helper generates two _input_ elements using the same name, one of type `checkbox` and the second of type `hidden`. This is because browsers don't submit a value for checkbox when they are not selected. The additional `hidden` input element ensures that the MVC framework gets a value from the hidden field when this happens.

__Defining HTML Attributes__  
Most input helper method have an overload that takes an object as a parameter. This can be used to define attributes for the input element.   
```
@Html.TextBox("username", "John", new {
  @class = "form-control"  ,
  placeholder = "Enter your name"
})
```
__Inserting Data Values__  
If you use only the first argument for an input helper method for example  
```
@Html.TextBox("Name")
```
The helper will look for a value for `Name` property, to use as the second argument, in the following places:
* ViewBag.Name  
* ViewData["Name"]
* @Model.Name

__Using the Strongly Types Input Helper Methods__   
Strongly typed helpers can only be used in strongly typed views. They use the lambda expression and the value passed is the view model object. Each of the basic helper have a corresponding strongly typed helper as shown below.
```
@Html.CheckBoxFor(model => model.IsApproved)
@Html.HiddenFor(model => model.UserID)
@Html.RadioButtonFor(model => model.IaApproved, "value")
@Html.PasswordFor(model => model.Password)
@Html.TextAreaFor(model => model.Message, nCols, nRows, new {})
@Html.TextBox(model => model.Name)
```  
Strongly types input helper will take care of the name, id and value attribute of the input element generated.  

__Creating select Elements__   
Basic select helpers  
```
@Html.DropDownList("gender", new SelectList(new [] {"Male", "Female"}), "Empty")
@Html.ListBox("language", new MultiSelectList(new [] {"English", "French", "German"}))
```
Strongly types select helpers  
```
@Html.DropDownListFor(model => model.Gender, new SelectList(new [] {"Male", "Female"}))
@Html.ListBoxFor(model => model.Language, new MultiSelectList(new [] {"English", "French", "German"}))
```  
You can use either the _SelectList_ or _MultiSelectList_ constructor to select properties from a model   
```
@model IEnumerable<Category>

@Html.DropDownList("Category", new SelectList(Model, "ID", "Name"))
```  
This will product a list of `<option>`s whose value and label are the `ID` and `Name` properties respectively from the objects of the model collection.  

__Using the Templated Helper Methods__   
Templated helpers determine what HTML element it should use based on the item passed to it.
```
@Html.Display("Name")
@Html.DisplayFor(model => model.Name)

@Html.Editor("Name")
@Html.EditorFor(model => model.Name)

@Html.Label("Name")
@Html.LabelFor(model => model.Name)  
```
You can also hint on what HTML element it should use by annotating the property of the relevant view model using the `UIHint` attribute. Alternately, you can pass the name of a custom partial view defined in the _EditorTemplates_ or _DisplayTemplate_ folder inside the _Shared_ folder.

__Using Metadata Formatting__    
The `DataType` attribute is used to format the displayed property of a View Model. It takes a value of the `DataType` enumeration as parameter.

```
using System.ComponentNodel.DataAnnnotation;
...
  [DataType(DataType.Date)]
  public DateTime Date { get; set}
```
The annotated property of the View Model is usually used in conjunction with the templated helper e.g `@Html.Display()`.

The `DataType` enumeration contains a wide range of formatting options.  
```
DataType.Date
DataType.DateTime
DataType.Time  
DataType.Text  
DataType.MultilineText
DataType.Password
DataType.Url
DataType.EmailAddress
```
Note that applying the `DataType` attribute only formats the data. No checks are made to ensure that the value is of an appropriate type.

__Using Metadata to select a Template__  
The `UIHint` attribute is used to hint which HTML element a template helper should used to display a view model's property.
```
using System.ComponentModel;
using System.ComponentModel.DataAnnotation;
...
  [DisplayName("Profile Message")]
  [UIHint("MultilineText")]
  public string ProfileMessage { get; set;}
```  
Here is a list of valid argument to generate templates for the `UIHint` attribute:  
```
Boolean
Collection
Decimal
EmailAddress
Html
MultilineText
Password
String
Text
Url
```
These are the built-in helper templates.   

__Using Metadata to Control Visibility and Editing__    
Use the `HiddenInput` attribute to hide properties:   
```
using System.Web.Mvc;
...
  [HiddenInput(DisplayValue=false)]
  public bool Approved { get; set;}
```
You can use `DisplayValue=true` or `DisplayValue=false` as argument to the `HiddenInput` attribute.  

__Creating a Custom Editor Template__  
You must create a folder called _EditorTemplates_ in the _~/Views/Shared_ folder. This is where the `EditorFor` helper looks for templates. Assuming the custom template was defined in _~/Views/Shared/EditorTEmplates/Categories.cshtml_, then we can use the `UIHint` attribute tp specify the custom template as our required UI for a specific property in a view model.   
```
using System.ComponentModel.DataAnnotation;
...  
  [UIHint("Categories")]
  public string Category {get; set;}
```
Alternately, we can specify the template to use directly in a template helper method like this:  
```
@Html.DisplayFor(model => model.Category, "Categories")
```
Here the second argument represents the name of the template to use.

__Creating a Custom Display Template__
Custom display templates a created in a similar way to custom editor template. They must be defined as partial view in the `~/Views/Shared/DisplayTemplates` folder.   
They can have the same name as a corresponding editor template which takes advantage of the `UIHint` attribute.  

__Creating a Type-Specific Template__  
If we create a custom template that has the name of a .NET type, then the templated helpers will use that template to render any property of that type they encounter. We can use this strategy to even override built-in template, although not recommended.

__Using the Whole-Model Templated Helper Methods__  
They operate on the whole view model and there a three of them:
```
@Html.DisplayForModel()
@Html.EditorForModel()
@Html.LabelForModel()
```
Rather than having to invoke helpers on each individual member, we can just work with the entire model. These helpers becomes more useful when we define custom templates for the view model property or the view model type itself.  


### Chapter 27: Using Routing and Areas
Routing is optional in _WebForm_ application but it is not for _MVC Framework_ applications.  MVC Framework routes are defined in the _Global.asax_ file but they use a slightly different format from the ones for _WebForm_.

__Generating Outgoing URLs__  
You can use the ActionLink helper to generate URL that points to an action method.
```
@Html.ActionLink("Link Label", "ActionMethod")
```
To reference an action method in a different controller:   
```
@Html.ActionLink("Link Label", "ActionMethod", "ControllerName")
```
To pass route parameter to the generated link:  
```
@Html.ActionLink("Link Label", "ActionMethod", new { id = 1})
```

__Avoiding the Routing Variable Reuse Trap__  
The MVC framework will take values for routing variables from incoming URL in order to generate an outgoing URL, even if the routing variable is optional and even if a perfectly valid URL could be created without reusing variables.   
To prevent this, we simple provide an empty string for the route variable.    
```
@Html.ActionLink("Show All", "List", new { id = string.Empty })
```  

__Specifying HTML Attributes__  
We can set attributes for the `a` element generated by the `ActionLink` helper by using an anonymous type.  
```
@Html.ActionLink("Show All", "List", new { id = string.Empty}, new { title = "All products", @class="btn-primary"})
```

__Generating Fully Qualifies URLs in Links__  
To generate a fully qualified URL which is useful for generating a link that points to a different website:
```
@Html.ActionLink("Link Label", "SecondSegment", "FirstSegment", "https", "externalsite.com", "fragment", new { id = string.Empty}, new {@class = "btn-primary"})
```
This will generate the following `a` element  
```
<a href="https://externalsite.com/FirstSegment/SecondSegment#fragment" class="btn-primary">Link Label</a>
```

__Generating URLs (and Not Links)__
Use the `Url.Action` helper to generate URL without the `a` element.  
```
@Url.Action("ActionMethod" new { id = string.Empty})
```
Here we pass and empty string for the route's _id_ parameter.    
The `Url.Action` helper works in the same way as `Html.ActionLink` except that it generates just the URL.  
The overloaded versions are the same for both methods.

The `Url.Content` helper generates a URL that target a static file.   

__Resolving the Ambiguous Controller Error__  
If the controller mapped to handle a given route in an _Area_ is the same name as the controller to handler a route in the main application, the MVC framework will through an error saying : "Multiple types were found that match the controller named...".    
To resolve this error, you assign a fourth argument to the _MapRoute_ method in for the route in the _GLobal.asax_ file   
```
routes.MapRoute(
    "Default",
    "{controller}/{action}/{id}",
    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    new { controller = "Home|Registration" },
    new string[] {"AppNameSpace.Controllers"}
);
```  
The fifth argument tells the router that priority should be given to controllers defined in the _AppNameSpace.Controllers_ namespace.  

__Using Areas__   
The MVC framework supports organizing a web application into areas, where each area represents a functional segment of the application, such as administration, billing, customer support, and so on.

__Generating Links to Actions in Areas__   
We don’t need to take any special steps to create links that refer to actions in the same MVC area that the
user is already on.   
To create a link to an action in a different area, or no area at all, we must create a variable called _area_ and use it to specify the name of the area we want, like this:
```
@Html.ActionLink("Click me to go to another area", "Index", new { area = "Support" })
```  
It is for this reason that area is reserved from use as a routing variable name.  
The HTML generated
by this call is as follows
```
<a href="/Support/Home">Click me to go to another area</a>  
```
If we want to link to an action on one of the top-level controllers (a controller in the _/Controllers_ folder), then you should specify the area as an empty string, like this:
```
@Html.ActionLink("Click me to go to main app", "Index", new { area = string.Empty })
```

### Chapter 28: Working with Action Methods  
__Rendering a View__  
We can specify the layout that should be used with the view, overriding the value of the _Layout_ property in the view of the *_ViewStart.cshtml* file.   
```
return View("MyView", "MyLayout", DataObject);
return View("MyView", "MyLayout");  
```

__Performing a Redirection__  
Redirection are commonly performed to follow a pattern called _post/redirect/get_. This is done to prevent the user from mistakenly resubmit a form by reloading the page.
There are tow kinds if redirect:  
1. _Temporary redirect_, send HTTP status code of 302
2. _Permanent redirect_, send HTTP status code of 301
Permanent redirect tells recipient not request the original URL ever again. It should be used with caution. For most situations, a temporary redirect is more suitable.

__Using Child Actions__  
Child actions are action methods that we invoke from within a view. A child action usually returns a partial view and is suitable for displaying dynamic widgets. Example
```
using System.Web.Mvc;
...
[ChildActionOnly]
public PartialViewResult Footer(DateTime dateTime) {
  ...
  return PartialView(modelObject)
}
```
The `ChildActionOnly` attribute is optional and serves only to prevent the child action from being invoked like a regular action as a result of user request.    
The view associated with a child action is usually a partial view but not compulsorily so.  
To invoke the child action in a view you use the `Action` helper  
```
@Html.Action("ChildActionName")
@Html.Action("ChildActionName", "ControllerName")
@Html.Action("Footer", new { time = DateTime.Now})
```
The view or partial view associated with the child action will be returned where the `Action` helper method was called.


### Chapter 29: Working with Model Binding and Validation  
__Handle Form POST with Basic Binding__  
When a form in posted with an input element of `<input name="Profile" />`, the MVC framework will automatically pass it to you action method:   
```
[HttpPost]
public ActionResult Register(string profile)
{
  User user = new User { Profile = profile};
  return View();
}
```
The MVC framework will look for the _profile_ value in the following places:  
```
Request.Form["profile"]
RouteData.Values["profile"]
Request.QueryString["profile"]
Request.Files["profile"]
```
Note that the parameter of the action method is case-insensitive, so _profile_ and _Profile_ will give you the same result.

__Using Validation Helpers__
You can have this at the top of before the form.  
```
@ValidationSummary("Please fix the following errors");
```
And then right below each form field:
```
@Html.ValidationMessageFor(x => x.FieldName)
```
Or you can use the weakly typed equaivalent
```
@Html.ValidationMessage("Fields is required and must be n length")
```  

__Defining Validation Rules Using Metadata__  
Useful attributes for model property validation  
```
[Compare("SecondPassword")]
[Range(10,  20)]
[Range(int.MinValue, 50)]
[RegularExpression("pattern")]
[Required]
[Required(AllowEmptyString = true)]
[StringLength(10)]
[StringLength(10, MinimumLength=2)]
```  
Not that for `[RegularExpression]`, the pattern must match the entire user-supplied value, not just a substring wihtin it.   
For `[StringLength(10)]`, the string must not be longer than 10 characters.  
To override the default error message for a given validation attribute  
```
[Required(ErrorMessage="Please enter a name")]
```

__Using Client-Side Validation__  
The clide-side validation is controlled by two settings in the `Web.config` file
```
<configuration>
  <appSettings>
    <add key="ClientValidationEnabled" value="true"/>
    <add key="UnobtrusiveJavaScriptEnabled" value="true"/>
  </appSettings
 ...
```  
In addition to the configuration settings, the following Javascript library must be included on the page that requires validation or better still in the *_Layout.cshtml* file
```
<script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>
```  
Remember that the order of these files is significant. If the order is changed the client validation may not work.

The _unobstrusive_ validation support works on the HTML that is emitted as a consequence of applying validation attribute to the view model properties. The _data-attribute_ that is appended to the generated input element are used for the validation by the Javascript libraries.  


### Chapter 30: Using Unobtrusive Ajax
To enable _Unobstrusive Ajax_ first, set the value of __UnobstrusiveJavaScriptEnabled__ to ture in _Web.config_  
```
<configuration>
  <appSettings>
    <add key="ClientValidationEnabled" value="true"/>
    <add key="UnobtrusiveJavaScriptEnabled" value="true"/>
  </appSettings>
...
```
next, place the script references in the views where we need to use _Ajax_ preferable in *_Layout.cshtml*.   
```
<script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" ></script>
<script src="@Url.Content("~/Scripts/jquery.unobtrusive-ajax.js")"></script>
```  
_jquery.unobtrusive-ajax.js_ is the MVC-specific wrapper around jQuery that provides the
unobtrusive Ajax support.  
If you project template does not have _jquery.unobtrusive-ajax.js_, you can install it using the _Nuget package manager_.  


To continue from: Page 733: Performing Graceful Degradation



## PART V: Wrapping Up

### Chapter 32: Preparing a Server for Deployment
Visit [iis.net](http://iis.net) for best-practice information about deploying Windows Server and IIS in production environment.

Step 1: Enable the Web Server(IIS) role on Windows Server.
Ensure that the following services are checked:  
* ASP.NET (in the Application Development category)  
* Management Service (in the Management Tools category)  

Step 2: Use WebPI on the server to obtain and install additional software components:
* .NET Framework version 4
* Web Deploy Tool 2.0  

__Understanding Virtual Directories__    
Each virtual directory can be marked as an independent application, in which case it gets its own separate application configuration and state. It can even run a different version of ASP.NET than its parent web site.

__Understanding Application Pools__   
Each pool runs a separate worker process which can run under a different identity (affecting it level of permission to access the underlying OS) and defined rules for maximum memory usage, maximum COU usage, process-recycling schedules and so on.  
If one application crashes, then the web server itself and application in other app pools won't be affected.   

### Chapter 33: Deploying an ASP.NET Application  
If you want to learn more about IIS, then I recommend
looking at the extensive documentation available at [www.iis.net](http://iis.net).  

__Preparing for Deployment__  
Deployment is the same for all types of ASP.NET application, with a couple of exceptions.  

__Preparing the Web.config File for Transformation__  
The _Web.config_ transformations are applied only when deploying the application using certain techniques. The transformations are not applied when doing a regular build in Visual Studio.  

__Preparing for Bin Deployment (MVC Framework Only)__  
We do this by performing what is called a _bin deployment_, so-called because the libraries are included in the _bin_ directory of the project.  This is to ensure that our application can run successfully whether or not the ASP.NET assembles have been installed by the server's administrators.  

__Deploying an Application by Copying Files__  
This is the most basic way to deploy an application.  
We need to copy the following files from the project on our development machine.   
* The compile .NET assemblies (which are in the _/bin_ folder)
* Configuration files(_Web.config_ and _Global.asax_)
* Static files (including images, CSS files and JS files)
We need to maintain the structure of the project.    
For security reason, DO NOT copy  
* C# code files (_*.cs_, _Global.asax_ and other code-behind files)  
* Project and solution files (_*.sln_, _*.suo_, _*.csproj_ or _*.csproj.user_)
* The _\obj_ folder
* source control directories (_.svn_, _.hg_ or _.git_)  
The first request to the server can take a while to complete.  

__Using a Deployment Package__  
A _deployment package_ is a zip file containing the application files.  Visual studio generates the package for us.   
Deplyment packages support _Web.config_ transformation and database deployment.  


### Chapter 34: Authentication and Authorization  
__Using Windows Authentication__  
With Windows Authentication, we essentially inherit whatever authentication system our Windows server is configured to use, including complex Active Directory deployment. We enable Windows Authentication in our application's _Web.config_ as shown:
```
<configuration>
  <system.web>
    <authentication mode="Windows" />
  </system.web>
</configuration>
```
When we use Windows Authentication, ASP.NET relies on IIS to authenticate requests from users. IIS in turn uses one of the modes:  
* Anonymous Authentication  (Allows access to all users)
* Basic Authentication  (Credentials are sent as plain text. Should be only used over an SSL connection )
* Digest Authentication  (Uses a cryptographic secure hash code. Only works when the server is a domain controller)
* Windows Authentication  (Identity of the user is established through the Windows domain. The server and client must be in the same domain or in domains that have a trust relationship)  

_Windows Authentication_ is suited for application deployed on a corporate intranet within an organization's established domain infrastructure.  
_Form Authentication_ is ideally suited for internet-facing applications.  

__Using Form Authentication__   
The security of Forms Authentication relies on an encrypted browser cookie called _.ASPXAUTH__.  
Using _FormsAuthentication.Decrypt_ to decrypt the cookie returns a _FormAuthenticationTicket_ object.    

The key property encoded in the cookie is _Name_. This is the identity that will be associated with the requests that the user makes. The security of this system comes from the fact that the cookie data is encrypted and signed using our server’s `machine keys`. These are generated automatically by IIS, and without these keys, the authentication information contained in the cookie cannot be read or modified.

__NB:__ When deploying an application that uses _Forms Authentication_ to a farm of servers, we must either ensure that requests always go back to the server that generated the cookie (known as _affinity_) or ensure that all of the server have the same machine keys. Keys can be generated and configured using the Machine Keys option in IIS Manager (the icon is in the ASP.NET section).   

Enabling Forms Authentication in _Web.Config_  
```
<configuration>
  <system.web>
    <authentication mode="Forms">
      <forms loginUrl="~/Account/LogOn" timeout="2880" />
    </authentication>
  </system.web>
</configuration>
```  
Alternatively, you can configure _Forms Authentication_ using the Authentication option in the IIS Manager tool.  

__Using Membership, Roles and Profiles__  
There are three key functional areas:  
* _Membership_, which is about registration  
* _Roles_, which groups uses for authorization purposes.  
* _Profiles_, for storage of users' preferences.   

__Managing Membership__
You may implement tour own web-vased administrative UI, which internally calls methods of the _Memebership_ API to let site administrators manage the user account database or use one of the platform's two built-in administration UIs:  
* _Website Administration Tool_ (WAT)
* _IIS .NET Users_ tool

__Setting Up and Using Roles__  
Just as with membership, the ASP.NET platform expects us to work with roles through its provider model offering a common API, the _RoleProvider_ base class and a set o built-in providers you can choose from. And of course, we can implement out own custom provider.  

For custom Authentication take a look at the articles:  
* [Article 1](https://www.c-sharpcorner.com/UploadFile/fa9d0d/forms-authentication-in-Asp-Net/)
* [Article 2](http://rahulrajatsingh.com/2014/06/understanding-and-implementing-asp-net-custom-forms-authentication/)
* [Article 3](http://rahulrajatsingh.com/2014/11/a-beginners-tutorial-on-custom-forms-authentication-in-asp-net-mvc-application/)  

#### JWT Authentication
__Steps to implement JWT Authentication is ASP.NET MVC 4__  
1. Install `System.IdentityModel.Tokens.Jwt` package. The package will be used to sign tokens and verify tokens.
2. Create a custom authorization attribute, I called mine `AppAuthorization`. Your attribute should extends `System.Web.Mvc.AuthorizeAttribute` and override it's `AuthorizeCore` and `HandleUnauthorizedRequest` methods.  
 The `AuthorizeCore` method does the check while the `HandleUnauthorizedRequest` method handles failure that may result from the check. See [system.web.mvc.authorizeattribute](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.authorizeattribute?view=aspnet-mvc-5.2)
3. Decorate the class or method that need to be protected using your custom attribute
```
[AppAuthorization]
public class PatientController : Controller
{
    ...
}
```
4. Implement a method that will Authenticate a user, when given their credentials, and issue a token if they pass. I usually do this in an `AuthService` class.   
You will use classes in the `System.IdentityModel.Tokens.Jwt` namespace to generate the token.  
5. Implement the `Application_AuthenticateRequest` event method in `Global.aspx`. In this method, you will check all incoming request for Authorization token.   
If they have a token you will validate the token using classes in the `System.IdentityModel.Tokens.Jwt`.    
If their token is valid then you add an object to the `Items` collection of the `HttpContext.Current` object. The object added will be used to identify the user inside of the `AuthorizeCore` method of your authorization attribute. You can also use the object inside of any controller action.     

## Simple Apps  
### Email App  
Form to mail or app useful as contact form on website contact us page.
