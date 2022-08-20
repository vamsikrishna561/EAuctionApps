import {Creator} from './creator';
import {Bid} from './bid';
import {Comment} from './comment';

export interface Product {
  id?: number;
  productName?: string;
  shortDescription?: string | null;
  detailedDescription?: string;
  categoryId?: number;
  sellerId?: number;
  startingPrice?: string;
  bidEndDate?: string;
  category?: Category;
  seller?: Seller;
  buyers?: Buyer[];
}

export interface Category{
  id?: string;
  categoryName?: string;
}

export interface Seller{
  id?: number;
  firstName?: string;
  lastName?: string;
  address?: string;
  city?: string;
  state?: string;
  pin?: string;
  phone?: string;
  email?: string;
}

export interface Buyer{
  id?: string;
  firstName?: string;
  lastName?: string;
  address?: string;
  city?: string;
  state?: string;
  pin?: string;
  phone?: string;
  email?: string;
  bidAmount?:number;
}
