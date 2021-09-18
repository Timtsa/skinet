import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagin-header',
  templateUrl: './pagin-header.component.html',
  styleUrls: ['./pagin-header.component.scss']
})
export class PaginHeaderComponent implements OnInit {

  constructor() { }
  @Input() pageNumber!:number;
  @Input() pageSize!:number;
  @Input() totalCount!:number; 

  ngOnInit(): void {
  }

}
