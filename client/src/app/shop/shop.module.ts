import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { PoductItemComponent } from './poduct-item/poduct-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ShopComponent,
    PoductItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports :[ShopComponent]
})
export class ShopModule { }
