export type OrderEventGetAllDto = {
    id: string,
    status:OrderStatus,
    createdOn:string

}

export type OrderEventGetAllQuery = {
    orderId:string | undefined
} 

export enum OrderStatus {

    BotStarted = 1,

    CrawlingStarted = 2,

    CrawlingCompleted = 3,

    CrawlingFailed = 4,

    OrderCompleted = 5,
}