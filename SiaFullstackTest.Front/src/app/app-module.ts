import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { ProductListComponent } from './products/product-list.component';
import { HomeComponent } from './home.component';
import { ProductCreateComponent } from './products/product-create.component';
import { ProductEditComponent } from './products/product-edit.component';
import { ProductDetailComponent } from './products/product-detail.component';
import { CategoryListComponent } from './categories/category-list.component';
import { CategoryCreateComponent } from './categories/category-create.component';
import { CategoryEditComponent } from './categories/category-edit.component';
import { CategoryDetailComponent } from './categories/category-detail.component';

@NgModule({
  declarations: [
    App
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ProductListComponent,
    HomeComponent,
    ProductCreateComponent,
    ProductEditComponent,
    ProductDetailComponent,
    CategoryListComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    CategoryDetailComponent
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
