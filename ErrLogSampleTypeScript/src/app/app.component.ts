import { Component } from '@angular/core';
import { HttpModule, Http } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HttpClientModule, HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
  ],
  declarations: [AppComponent],
  bootstrap: [AppComponent]
})

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ErrLog.IO Is Awesome!';

  constructor(private http: HttpClient) {

    const data = {
      apikey: '484E94EC-6AC7-48DF-A00F-F6B78FDE8014',
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

    const url = 'https://relay.errlog.io/api/v1/log';

    const headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

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

  }
}


