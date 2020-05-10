export interface KeyValuePair {
  id: number;
  name: string;
}

export interface Supplier {
  companyName: string;
  mobileNo: number;
}

export interface Info {

  vendorProductID: number;
  productName: string;
  productDescription: string;
  note: string;


}

export interface Sell {

  quantityPerUnit: number;
  unitPrice: number;
  discount: number;
  unitWeight: number;
  unitInStock: number;
  unitsOnOrder: number;
 



}


export interface Product {
  id: number;
  productAvailable: boolean;
  discountAvailable: boolean;
  productOfSeason: boolean;
  sellUnitPrice: number;
  suppliers: Supplier;
  info: Info;
  sell: Sell;
  lastUpdate: string;

}

export interface SaveProduct {

  suppliers: number[];
  info: Info;
  sell: Sell;

}
