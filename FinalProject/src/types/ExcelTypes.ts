export type ExportProductsDto = {
    id:string,
   name:string;
   picture:string;
   isOnSale:boolean;
   price:number;
   salePrice:number
}

export type ExportProductsQuery = {
    orderId:string | undefined
}