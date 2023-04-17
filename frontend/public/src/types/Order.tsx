import { OrderItem } from "./OrderItem";

export interface Order { 
    orderItems: OrderItem[],
    total: number
  };