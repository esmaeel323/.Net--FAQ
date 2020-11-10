import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Home } from './Home';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpClientModule],
    declarations: [Home],
    bootstrap: [Home]
})
export class AppModule { }
