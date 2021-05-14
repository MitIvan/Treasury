import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { DenBlComponent } from './den-bl/den-bl.component';
import { KasaIspComponent } from './den-bl/kasa-isp/kasa-isp.component';
import { DenIzvodComponent } from './den-bl/den-izvod/den-izvod.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {PrintKasaComponent} from './den-bl/print-kasa/print-kasa.component'
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { DenListComponent } from './den-bl/den-list/den-list.component';
import { DenItemComponent } from './den-bl/den-list/den-item/den-item.component';
import { DenBlService } from './den-bl/den-bl.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http'



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DenBlComponent,
    KasaIspComponent,
    DenIzvodComponent,
    PrintKasaComponent,
    HomeComponent,
    DenListComponent,
    DenItemComponent,

  ],
  imports: [
    BrowserModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [DenBlService],
  bootstrap: [AppComponent]
})
export class AppModule { }
