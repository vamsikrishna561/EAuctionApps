import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../product.service';
import {Buyer, Product, Seller} from '../../shared/interfaces/product';

import {Title} from '@angular/platform-browser';

@Component({
  selector: 'app-product-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  selProductId: number=0;
  lstProducts: Product[] = [];
  products:Product[]=[];
  selProducts: Product = {};
  lstSellers: Seller[] = [];
  bids?: Buyer[] = [];

  isNewAmtShow: boolean = false;
  constructor(private route: ActivatedRoute, private productService: ProductService, private router: Router, private title: Title) {
  }

  ngOnInit(): void {
    this.getAllproducts();
  }

  getAllproducts() {
    this.productService.getAllproducts().subscribe(data => {
      this.products = data;
      let sellers:Seller[]=[];
      data.forEach(function(value){
        if(sellers.findIndex(x=>x.email === value.seller.email) === -1)
        sellers.push(value.seller);

      });
      this.lstSellers = sellers;
    });
  }

  OnSelectedSeller(value:string) {
    this.selProducts ={};
    this.bids = [];
    this.lstProducts = this.products.filter(a => a.seller?.id === +value);
  }

  OnSelectedProduct(value:string) {
    this.selProductId = +value;
    this.selProducts = this.lstProducts.filter(a => a.id == this.selProductId)[0];
    if (this.selProductId != 0) { 
      this.bids = this.selProducts.buyers;
    }
  } 

  getFullAddress(address: string, city: string, state: string, zip: string) { return address + ", " + city + " " + state + " " + zip }
}
