    import React, {createContext} from "react";
    import {LocalUser} from "../types/AuthTypes.ts";
    import { OrderGetAllDto } from "../types/OrderTypes.ts";



    export type AppUserContextType = {
        appUser:LocalUser | undefined,
        setAppUser:React.Dispatch<React.SetStateAction<LocalUser | undefined>>,
    }

    export const AppUserContext = createContext<AppUserContextType>({
        appUser:undefined,
        // eslint-disable-next-line @typescript-eslint/no-empty-function
        setAppUser: () => {},
    });

    export type OrdersContextType = {
        orders:OrderGetAllDto[],
        setOrders:React.Dispatch<React.SetStateAction<OrderGetAllDto[]>>
    }

    export const OrdersContext = createContext<OrdersContextType>({
        orders:[],
        // eslint-disable-next-line @typescript-eslint/no-empty-function
        setOrders:() => {},
    })