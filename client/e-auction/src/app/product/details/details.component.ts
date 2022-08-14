import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ProductService} from '../product.service';
import {Product} from '../../shared/interfaces/product';

import {switchMap, tap} from 'rxjs/operators';
import {Title} from '@angular/platform-browser';
//import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-product-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  selProductId: number=0;
  lstProducts: any[] = [];
  selProducts: any;
  bidData: any;

  isNewAmtShow: boolean = false;
  constructor(private route: ActivatedRoute, private productService: ProductService, private router: Router, private title: Title) {
  }

  ngOnInit(): void {
    this.getAllproducts();
  }

  getAllproducts() {
    this.productService.getAllproducts().subscribe(data => {
      this.lstProducts = data;
    });
  }

  OnSelectedProduct() {
    this.selProducts = this.lstProducts.filter(a => a.productId == this.selProductId)[0];
    if (this.selProductId != 0) { this.showAllBids(); }
  }

  showAllBids() {
    this.productService.GetAllBids(this.selProductId).subscribe(data => {
      this.bidData = data;
      console.log(this.bidData);
    });
  }

  bidProductId: number = 0;
  bidEmail: string = "";
  //newBidAmt: number;
  errorMessage: string = "";
  updateBid(productId: number, email: string) {
    this.bidEmail = email;
    this.bidProductId = productId;
    this.openUpdateBidPopup();
  }

  displayStyle = "none";

  openUpdateBidPopup() {
    this.displayStyle = "block";
    
  }
  closeUpdateBidPopup() {
    this.displayStyle = "none";
  }
  // UpdateBid() {
  //  // alert(this.newBidAmt);
  //   if (this.newBidAmt == undefined) {
  //     this.errorMessage = "Bid price should not be 0 or empty.";
  //     return;
  //   }
  //   else if (this.newBidAmt < this.selProducts.startingPrice) {
  //     this.errorMessage = "Bid price should always be greator then product price.";
  //     return;}
   
  //   this.productService.UpdateBids(this.bidProductId, this.bidEmail, this.newBidAmt).subscribe(data => {
  //     console.log(data);
  //     this.showAllBids();
  //     this.closeUpdateBidPopup();
  //   },
  //     error => {
  //       //console.log(error.message);
  //       //alert(error.message);
  //       this.closeUpdateBidPopup();
  //     }
  //   );
  // }


  displayStyleAdd = "none";
  eMsg = "";
  fname: string = "";
  lname: string = "";
  address: string = "";
  city: string = "";
  state: string = "";
  zip: string = "";
  phone: string = "";
  email: string = "";
  //Amt: number;
  openAddBidPopup() {
    this.displayStyleAdd = "block";

  }

  closeAddBidPopup() {
    this.displayStyleAdd = "none";
  }

  // AddBid() {
   
  //   if (this.fname == null || this.fname == "") {
  //     this.eMsg = "First name is required.";
  //     return;
  //   }
  //   else if (this.lname == null || this.lname == "") {
  //     this.eMsg = "Last name is required.";
  //     return;
  //   }
  //   else if (this.address == null || this.address == "") {
  //     this.eMsg = "Address is required.";
  //     return;
  //   }
  //   else if (this.city == null || this.city == "") {
  //     this.eMsg = "City is required.";
  //     return;
  //   }
  //   else if (this.state == null || this.state == "") {
  //     this.eMsg = "State is required.";
  //     return;
  //   }
  //   else if (this.zip == null || this.zip == "") {
  //     this.eMsg = "PinCode is required.";
  //     return;
  //   }
  //   else if (this.phone == null || this.phone == "") {
  //     this.eMsg = "Phone is required.";
  //     return;
  //   }
  //   else if (this.email  == null || this.email == "") {
  //     this.eMsg = "Email is required.";
  //     return;
  //   }
  //   else if (this.Amt == null || this.Amt == 0) {
  //     this.eMsg = "Amount is required.";
  //     return;
  //   }
  //   else if (this.Amt < this.selProducts.startingPrice) {
  //     this.eMsg = "Amount is always equal or greator then the product price.";
  //     return;
  //   }
    
  //   //else if (now.toLocaleDateString() < this.selProducts.bidEndDate.toLocaleDateString()) {
  //   //  this.eMsg = "Bid end date is passed.";
  //   //  return;
  //   //}
  //   var obj: any = {
  //     firstName: this.fname,
  //     lastName: this.lname,
  //     address: this.address,
  //     city: this.city,
  //     state: this.state,
  //     pinCode: this.zip,
  //     phone: this.phone,
  //     email: this.email,
  //     productId: this.selProductId,
  //     bidAmount: this.Amt,
  //   };
  //   this.productService.placedBid(obj).subscribe(data => {
  //     console.log(data);
  //     this.showAllBids();
  //     this.closeAddBidPopup();
  //   },
  //     error => {
  //       //console.log(error.message);
  //       //alert(error.message);
  //       this.closeAddBidPopup();
  //     }
  //   );
  // }

  getFullAddress(address: string, city: string, state: string, zip: string) { return address + ", " + city + " " + state + " " + zip }
}
