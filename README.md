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
All that is required is an _ItemTemplate_, all other template of the_ListView_ is optional. But the real value of the _ListView_ control is in how it templates work together. If you just want a simple list, use easier controls such as the _DataList_ control.  

## PART IV: Using the MVC Framework

### Chapter 22: Putting MVC in context
Story. Can be read any time.

### Chapter 23: A First MVC Application  
The _Global.asax_ and _Web.config_ files pay the same role for Web Form and MVC application, although there may be slightly different content.   

Notice that there are two _Web.config_ files: _~/Web.config_ and _~/Views/Web.config_ . The second one of these configures Razor.  

To Continue from "Creating the controller"...

__Creating the Domain Model__  
There are two kinds of models: _domain model_ and _view model_.  
It is common practice to create a separate class library project for the domain model and add it as a reference to the MVC framework project. The idea is that this helps enforce the separation between the domain model and the rest of the application.


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

__NB:__ When deploying an application that uses _Forms Authentication_ to a farm of servers, we must either ensure that requests always go back to the server that generated the cookie (known as _affinity_) or ensure that all of the server have the same machine keys. Keys can be generated and configured using the Machine Keys option n IIS Manager (the icon is in the ASP.NET section).   

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


## Simple Apps  
### Email App  
Form to mail or app useful as contact form on website contact us page.
