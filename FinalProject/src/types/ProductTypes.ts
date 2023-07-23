export type ProductGetAllDto = {
    id:string,
   name:string;
   picture:string;
   isOnSale:boolean;
   price:number;
   salePrice:number
}

export type ProductGetAllQuery = {
    orderId:string | undefined
} 

export type ProductRemoveCommand = {
    id:string | undefined,
}





    