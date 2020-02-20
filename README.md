# Applied ASP.NET 4 in Context (2011)
By Adam Freeman

## PART I: Getting Started

### Chapter 1: Introduction

### Chapter 2: Getting Ready

### Chapter 3: Putting ASP.NET in Context  
__The Structure of ASP.NET__  
ASP.NET has a base called the Core ASP.NET Platform.
On top of the core is the _Web Forms_ and the _MVC framework_ which sits side by side.  
You'll need to master the core ASP.NET features to get the most out of both the Web Forms and the MVC framework.  
The set of features that the core platform supports is extensive and the can be used to create web applications in their own right.  

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

The key difference between session state and view state is that only the session identifier is included
in the response that is sent to the client, while the data stored remains on the server.

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

### Chapter 32: Preparing a Server for Deployment
Visit [iis.net](http://iis.net) for best-practice information about deploying Windows Server and IIS in production environment.

Step 1: Enable the Web Server(IIS) role on Windows Server.
