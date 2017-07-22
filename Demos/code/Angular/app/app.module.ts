import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { WelcomeComponent } from './home/welcome.component';
import { ProductListComponent } from './products/product-list.component';
import { ProductDetailComponent } from './products/product-detail.component';
import { ProductFilterPipe } from './products/product-filter.pipe';
import { StarComponent } from './shared/star.component';

@NgModule({
  imports: [BrowserModule, FormsModule, HttpModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/welcome',
        pathMatch: 'full'
      },
      {
        path: 'product/:id',
        component: ProductDetailComponent
      },
      {
        path: 'products',
        component: ProductListComponent
      },
      {
        path: 'welcome',
        component: WelcomeComponent
      }
    ])],
  declarations: [AppComponent, WelcomeComponent, ProductListComponent, ProductDetailComponent, ProductFilterPipe, StarComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],             //<---added this line
  bootstrap: [AppComponent]
})
export class AppModule { }
