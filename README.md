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
