
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brands';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productTypes';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm! : ElementRef
  products!: IProduct[];
  brands!: IBrand[];
  types!: IType[];
  shopParams =new ShopParams();
  totalCount!:number;
  sortOptions=[
    {name:"Alphabetical", value:'name'},
    {name:'Price: Low to Hight', value:'priceAsc'},
    {name:'Price: Hight to Low', value:'priceDesc'}
  ];

  constructor(private shopServise: ShopService) { }
  
  ngOnInit(): void {
    this.getProducts();
    this.getTypes();
    this.getBrands();

     }

    getProducts(){
      this.shopServise.getProducts(this.shopParams).subscribe(response=>
        { this.products=response!.data;
        this.shopParams.pageNumber=response!.pageIndex;
        this.shopParams.pageSize=response!.pageSize;
        this.totalCount=response!.count }, error=>{
          console.log(error);
        }    
       )
    }

    getBrands(){
      return this.shopServise.getBrands().subscribe(response=>{
        this.brands=[{id:0,name:'All'}, ...response];}, error=>{
          console.log(error);
        })
    }

    getTypes(){
      return this.shopServise.getTypes().subscribe(response=>
        {this.types=[{id:0,name:'All'}, ...response]}, error=>{
          console.log(error);
        })
    }
      
    onBrandSelected(brandId:number){
      this.shopParams.brandId=brandId;
      this.shopParams.pageNumber=1;
      this.getProducts();
    }

    onTypeselected(typeId:number){
      this.shopParams.typeId=typeId;
      this.shopParams.pageNumber=1;
      this.getProducts();
    }

    onSortSelected(sort:string){
       this.shopParams.sort=sort;
       this.getProducts();
    }

    onPageChanget(event:any){
      this.shopParams.pageNumber=event.page;
      this.getProducts()
    }

    onSearch(){
      this.shopParams.search = this.searchTerm.nativeElement.value;
      this.getProducts();
    }

    onReset(){
      this.searchTerm.nativeElement.value='';
      this.shopParams=new ShopParams();
      this.getProducts();
    }
}
