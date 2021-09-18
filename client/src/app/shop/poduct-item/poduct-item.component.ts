import { Component, Input, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';

@Component({
  selector: 'app-poduct-item',
  templateUrl: './poduct-item.component.html',
  styleUrls: ['./poduct-item.component.scss']
})
export class PoductItemComponent implements OnInit {
  @Input() product!:IProduct
  constructor() { }

  ngOnInit(): void {
  }

}
