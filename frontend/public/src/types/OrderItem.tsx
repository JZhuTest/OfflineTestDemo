import { TopIngredient } from "./TopIngredient";

export interface OrderItem { 
    orderItemId: string,
    locationId: number, 
    pizzaTypeId: number,
    pizzaTypeName: string,
    topIngredients: TopIngredient[],
    basePrice: number,
    subTotal: number
  };