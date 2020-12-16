import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule,ReactiveFormsModule} from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ThanhphoComponent } from './quanlichung/thanhpho/thanhpho.component';
import { QuanhuyenComponent } from './quanlichung/quanhuyen/quanhuyen.component';
import { XaphuongComponent } from './quanlichung/xaphuong/xaphuong.component';
import { HttpClientModule } from '@angular/common/http';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { BaocaoComponent } from './baocao/baocao/baocao.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { SliderComponent } from './slider/slider.component';
import { ContenComponent } from './conten/conten.component';

@NgModule({
  declarations: [
    AppComponent,
    ThanhphoComponent,
    QuanhuyenComponent,
    XaphuongComponent,
    BaocaoComponent,
    SliderComponent,
    ContenComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NzToolTipModule,
    NzMenuModule,
    NzSkeletonModule,
    NzDatePickerModule,
    NzTableModule,
    NzDropDownModule,
    NzLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
