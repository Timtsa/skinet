import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../shared/models/basket';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  constructor(private basketServise: BasketService) { }
  basket$: Observable<IBasket>

  ngOnInit() {
    this.basket$=this.basketServise.basket$;
  }

  incrementItemQuantity(item: IBasketItem){
    this.basketServise.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem){
    this.basketServise.decrementItemQuantity(item);
  }

  removeBasketItem(item: IBasketItem){
    this.basketServise.removeItemFromBasket(item);
  }

}
