import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Product } from '../shared/interfaces/product';
import { environment } from '../../environments/environment';
import { catchError, map } from 'rxjs/operators';
import { Bid } from '../shared/interfaces/bid';
import { Observable, throwError } from 'rxjs';
import { Comment } from '../shared/interfaces/comment';
//import { ProductInfo } from '../shared/interfaces/productInfoparam';
//import { error } from '@angular/compiler/src/util';

@Injectable({ providedIn: 'root' })
export class ProductService {
  constructor(private httpClient: HttpClient) {
  }

  //static addImagePath(product: Product): Product {
  //  const { imagePath } = environment;
  //  product.image = `${imagePath}${product._id}.png`;
  //  return product;
  //}

  //getLatestProducts(): Observable<Product[]> {
  //  return this.httpClient.get<Product[]>(`product/latest`).pipe(map((products) => {
  //    return products.map(ProductService.addImagePath);
  //  }));
  //}

  //create(product: FormData): Observable<Product> {
  //  return this.httpClient.post<Product>('product', product);
  //}

  //getById(productId: string): Observable<Product> {
  //  return this.httpClient.get<Product>(`product/${productId}`)
  //    .pipe(map((product) => {
  //      const endDate = new Date(product.endTime);
  //      product.image = `${environment.imagePath}${product._id}.png`;
  //      product.endString = `${endDate.getDate().toString().padStart(2, '0')}.${endDate.getMonth().toString().padStart(2, '0')}.${endDate.getFullYear()}`;
  //      return product;
  //    }));
  //}

  //delete(productId: string): Observable<Product> {
  //  return this.httpClient.delete<Product>(`product/${productId}`);
  //}

  //getAll(skip = 0, take = 0, sort = 0): Observable<Product[]> {
  //  return this.httpClient.get<Product[]>(`product?skip=${skip}&take=${take}&sort=${sort}`).pipe(map((products) => {
  //    return products.map(ProductService.addImagePath);
  //  }));
  //}

  //getProductCount(): Observable<{ count: number }> {
  //  return this.httpClient.get<{ count: number }>(`product/count`);
  //}

  //addBid(productId: string, priceValue): Observable<Bid> {
  //  return this.httpClient.post<Bid>(`product/${productId}/bid`, { priceValue });
  //}

  //edit(productId: string, data): Observable<Product> {
  //  return this.httpClient.patch<Product>(`product/${productId}`, data);
  //}

  comment(productId: string, comment: string): Observable<Comment> {
    return this.httpClient.post<Comment>(`product/${productId}/comment`, { comment });
  }

  like(productId: string) {
    return this.httpClient.post<any>(`product/${productId}/like`, { a: 1 });
  }

  //New Method Added
  getAllSeller(): Observable<Product[]> {
    //console.log(this.httpClient);
    return this.httpClient.get<Product[]>(`getAllSeller`).pipe(map((products) => {
      return products;
    }));
  }

  //addProduct(param: ProductInfo): Observable<any> {
  //  return this.httpClient.post<any>(`add-products`, JSON.stringify(param));
  //}

  getAllproducts(): Observable<any[]> {
    //console.log(this.httpClient);
    return this.httpClient.get<any[]>(`Seller/get-products`).pipe(map((products) => {
      return products;
    }));
  }

  //deleteProduct(productId: number): Observable<any> {
  //  return this.httpClient.delete<Product>(`delete/${productId}`);
  //}

  GetAllBids(productId: number): Observable<any> {
    return this.httpClient.get<any>(`Seller/show-bids/${productId}`).pipe(map((products) => {
      return products;
    }));
  }

  //UpdateBids(productId: number, email: string, newAmt: number): Observable<any> {
  //  var obj: any = {
  //    ProductId: productId,
  //    Email: email,
  //    BidAmount: newAmt, };
  //  return this.httpClient.post<any>(`update-bid`, JSON.stringify(obj)).pipe(
  //    catchError(error => {
        
  //      alert(error.error.title);
  //      let errorMsg: string;
  //      if (error.error instanceof ErrorEvent) {
  //        console.log(`Error: ${error.error.message}`);
  //      } else {
  //        console.log(this.getServerErrorMessage(error));
  //      }

  //      return throwError(errorMsg);
  //    })
  //  );
  //}


  private getServerErrorMessage(error: HttpErrorResponse): string {
    switch (error.status) {
      case 404: {
        return `Not Found: ${error.error.title}`;
      }
      case 403: {
        return `Access Denied: ${error.error.title}`;
      }
      case 500: {
        return `Internal Server Error: ${error.error.title}`;
      }
      default: {
        return `Unknown Server Error: ${error.error.title}`;
      }

    }
  }


  //placedBid(param: any): Observable<any> {
   
  //  return this.httpClient.post<any>(`place-bid`, JSON.stringify(param)).pipe(
  //    catchError(error => {

  //      alert(error.error.title);
  //      let errorMsg: string;
  //      if (error.error instanceof ErrorEvent) {
  //        console.log(`Error: ${error.error.message}`);
  //      } else {
  //        console.log(this.getServerErrorMessage(error));
  //      }

  //      return throwError(errorMsg);
  //    })
  //  );
  //}
}
