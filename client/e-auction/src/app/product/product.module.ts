import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';



import {DetailsComponent} from './details/details.component';
import {ProductRoutingModule} from './product-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [DetailsComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    SharedModule,
    ProductRoutingModule    
  ],
  exports: []
})
export class ProductModule {
}
