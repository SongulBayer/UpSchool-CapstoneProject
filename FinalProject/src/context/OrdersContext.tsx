// OrdersContext.tsx
import React, { ReactNode, createContext, useState } from 'react';
import { OrderGetAllDto } from '../types/OrderTypes';


interface OrdersContextType {
  orders: OrderGetAllDto[];
  setOrders: React.Dispatch<React.SetStateAction<OrderGetAllDto[]>>;
}

export const OrdersContext = createContext<OrdersContextType>({
  orders: [],
  setOrders: () => {},
});

export const OrdersProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [orders, setOrders] = useState<OrderGetAllDto[]>([]);
  
    return (
      <OrdersContext.Provider value={{ orders, setOrders }}>
        {children}
      </OrdersContext.Provider>
    );
  };
