import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {DefaultInterceptor} from './default.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: DefaultInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
