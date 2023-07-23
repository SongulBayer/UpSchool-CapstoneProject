
export type OrderAddCommand = {
        requestedAmount: number;
        totalFoundedAmount: number;
        productCrowlType: number;
        userId: string;

        
}

export type OrderGetAllDto = {
        id : string
        requestedAmount: number
        totalFoundedAmount :number
        productCrowlType : ProductCrowlType
             
}

export enum ProductCrowlType {
        All = 0,
        OnDiscount = 1,
        NonDiscount = 2,
      }