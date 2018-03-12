# Using TypeScript

We don't currently have a custom package available for TypeScript, however you can use our API at `https://relay.errlog.io/api/v1/log` to provide your own logging mechanism to your ErrLog.IO account.

For a look at the fields you can include with your API calls check out [Payload Variables](/docs/payload-variables.aspx)

## Requirements

There are many different modules and frameworks for TypeScript and each will have their own way of dealing with web requests. This example uses Angular, however the method used will be the same: catch an exception (or create your own data packet) and send it to ErrLog.IO.

The example below uses the following packages: [`HttpClientModule`](https://angular.io/api/common/http/HttpClientModule) module from Angular to make the POST request to ErrLog.IO.

To install and run the project I'll be using the [Angular CLI](https://cli.angular.io/) so it will need to be installed using `npm install -g @angular/cli`

## Usage

In this example we use the `AppModule` constructor to do all the hard work, purely for simplicity. It would be better to isolate the error logging functionality into a separate class.

### Environment Setup

To include the files in the solution I created a generic C++ project in Visual Studio. This was because it was a minimalist project type and it won't be compiled from within Visual Studio.

![Create a VS project](https://errlog.io/images/docs/typescript-create-vs-project.png)

Then from the folder where your newly created project is hosted run `ng new [project_name]` to create the project files. This will take a minute or two.

![Create an angular project](https://errlog.io/images/docs/typescript-create-ng-project.png)

And you'll need to install some `npm` packages

    npm i –D  @angular/core @angular/http @angular/platform-browser @angular/core @angular/common zone.js rxjs

Your project should now look like this:

![Project Created](https://errlog.io/images/docs/typescript-project-created.png)


## tsconfig.json

You'll need to have the following lines in your tsconfig.json

    "lib": [
      "es2017",
      "dom"
    ],
    "types": [ "node" ],

## app.module.ts

Your `app.module.ts` file will need to look like this (for the includes and imports):

    import { BrowserModule } from '@angular/platform-browser';
    import { NgModule } from '@angular/core';
    import { HttpClientModule } from '@angular/common/http';
    import { AppComponent } from './app.component';
    
    
    @NgModule({
      declarations: [
        AppComponent
      ],
      imports: [
        BrowserModule,
        HttpClientModule
      ],
      providers: [],
      bootstrap: [AppComponent]
    })
    export class AppModule { }

## app.component.ts

This is the code that gets run when the homepage is loaded. There are a few parts to it and I'll break them down here.

### Imports

These make sure all the necessary functionality is avaialble.

    import { Component } from '@angular/core';
    import { HttpModule, Http } from '@angular/http';
    import { BrowserModule } from '@angular/platform-browser';
    import { NgModule, ErrorHandler } from '@angular/core';
    import { HttpClientModule, HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
    

### @NgModule

Adding `HttpModule` to the `@NgModule` decorator allows us to use `http` later on. See [@NgModule](https://angular.io/api/core/NgModule) for more information.

    @NgModule({
      imports: [
        BrowserModule,
        HttpModule,
      ],
      declarations: [AppComponent],
      bootstrap: [AppComponent]
    })

### Craft the data packet

Similar to other examples we set up a data packet that contains the data we want to send to ErrLog.IO. As we're not handling a native exception, the data here is arbitrary but it shows the way it can be used. If you have an exception object or other data you want to use, the data here can be easily swapped out for the appropriate variables. For more information about what can be included in the data packet, see [Payload Variables](/docs/payload-variables.aspx).

    const data = {
        apikey: '[YOUR_API_KEY]',
        message: 'This is a test message from TYPESCRIPT!!!',
        applicationname: 'TypeScript  Application',
        type: 'TypeScript Exception',
        errordate: new Date().toISOString(),
        trace: 'ex.StackTrace',
        filename: 'app.component.ts',
        method: 'constructor',
        lineno: 123,
        colno: 456
    };

You can also set the API endpoint and headers here as well if you like:

    const url = 'https://relay.errlog.io/api/v1/log';
    
    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

### Perform the request

This performs the POST request to the API endpoint. You can do what you like with the response. In this example we just `console.log(..)` it for debugging purposes.

     const req = http.post(url, data, { headers })
          .subscribe(
            (res) => {
              console.log('Response: ' + res);
            },
            err => {
              console.log('Error occured');
            },
            () => {
              console.log('The POST observable is now completed.');
            }
          );

## Run the application

From the root of your project, run `ng serve` to start the web application.

![Running ng server](https://errlog.io/images/docs/typescript-ng-serve.png)

From there you just need to browse to the specified URL (in this case `http://localhost:4200/`. This will bring up the default page, the code of which implements the call to the ErrLog.IO log API.

After successfully loggin an error, you will receive an HTTP 200 response from the web request and your exception will have been logged to your ErrLog.IO [dashboard](/dashboard)

## See Also
*   [TypeScript Documentation](https://www.typescriptlang.org/docs/home.html)
*   [Angular Documentation](https://angular.io/docs)
*   [Angular HttpClient class](https://angular.io/api/common/http/HttpClient)
