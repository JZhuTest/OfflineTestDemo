import { useEffect, useState, createContext, useContext } from 'react';
import axios from 'axios';
import {v4 as uuidv4} from 'uuid';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { Location } from './types/Location';
import LocationCombo from './components/locationCombo';
import Menu from './components/menu';
import { MenuItem } from './types/MenuItem';
import { Order } from './types/Order';
import { OrderItem } from './types/OrderItem';
import OrderPanel from './components/orderPanel';
import { TopIngredient } from './types/TopIngredient';
import { TopIngredientContext } from './context';

function App() {
  const [locations, setLocations] = useState<Array<Location>>([]);
  const [topIngredients, setTopIngredients] = useState<TopIngredient[]>([]);
  const [currentLocationId, setCurrentLocationId] = useState<number>();
  const [menuItems, setMenuItems] = useState<Array<MenuItem>>();
  const [order, setOrder] = useState<Order>();
  
  useEffect(() => {
    const fetchLocations = async () => {
        try {
            const response = await axios.get('https://localhost:7166/location');
            const json = response.data as Location[];
            setLocations(json);
            return json;
        } catch (error) {
            console.error(error);
            return [];
        }
    };
    fetchLocations();
  }, []);

  useEffect(() => {
    const fetchTopIngredients = async () => {
        try {
            const response = await axios.get('https://localhost:7166/ingredient/tops');
            const json = response.data as TopIngredient[];
            setTopIngredients(json);
            return json;
        } catch (error) {
            console.error(error);
            return [];
        }
    };
    fetchTopIngredients();
  }, []);

  useEffect(() => {
    const fetchMenuItems = async () => {
        try {
            if (currentLocationId){
                const response = await axios.get(`https://localhost:7166/menu/${currentLocationId}`);
                const items: MenuItem[] = [];
                response.data.map((i: any) => { 
                    items.push({
                        locationId: i.locationId,
                        pizzaTypeId: i.pizzaTypeId,
                        pizzaTypeName: i.pizzaType.name,
                        pizzaTypeDesc: i.pizzaType.ingredientsDescription,
                        price: i.price
                    })
                })
                setMenuItems(items);
                return items;
            }
        } catch (error) {
            console.error(error);
            return [];
        }
    };
    fetchMenuItems();
  }, [currentLocationId]);

  useEffect(() => {
    
  }, [order]);

  const handleLocationChanged = (location: Location) => {
    setCurrentLocationId(location.id);
  };

  // Handle the event when an order item is added
  const handleOrderItemAdded = (item: MenuItem) => {
    const tempOrder: Order = { orderItems: [], total: 0 };
    // Deep copy enable propagate the state change to the child component
    if (order) {
        tempOrder.orderItems = order.orderItems;
        tempOrder.total = order.total;
    }
    
    tempOrder.orderItems.push({
        orderItemId: uuidv4(),
        locationId: item.locationId,
        pizzaTypeId: item.pizzaTypeId,
        pizzaTypeName: item.pizzaTypeName,
        topIngredients: [],
        basePrice: item.price,
        subTotal: item.price
    });
    
    tempOrder.total = tempOrder.orderItems.reduce((total, i) => total + i.subTotal, 0);
    setOrder(tempOrder);
  }

  // Handle the event when a order item is deleted
  const handleOrderItemDeleted = (item: OrderItem) => {
    const tempOrder: Order = { orderItems: [], total: 0 };
    // Deep copy enable propagate the state change to the child component
    if (order) {
        tempOrder.orderItems = order.orderItems;
        tempOrder.total = order.total;
    }
    
    const idx = tempOrder.orderItems.findIndex(o => o.orderItemId == item.orderItemId);
    if (idx > -1){
        tempOrder.orderItems.splice(idx, 1);
    }
    
    tempOrder.total = tempOrder.orderItems.reduce((total, i) => total + i.subTotal, 0);
    setOrder(tempOrder);
  }

  // Handle the event when any order item property is changed (currently only topIngredient can be changed)
  const handleOrderItemChanged = (item: OrderItem) => {
    const tempOrder: Order = { orderItems: [], total: 0 };
    // Deep copy enable propagate the state change to the child component
    if (order) {
        tempOrder.orderItems = order.orderItems;
        tempOrder.total = order.total;
    }
    const tempItem = tempOrder.orderItems.find(i => { return i.orderItemId == item.orderItemId });
    if (tempItem) {
        tempItem.topIngredients = item.topIngredients;
        tempItem.subTotal = tempItem.basePrice + tempItem.topIngredients.length;
    }
    tempOrder.total = tempOrder.orderItems.reduce((total, i) => total + i.subTotal, 0);
    setOrder(tempOrder);
  }

  return (
      <TopIngredientContext.Provider value={topIngredients}>
        <div>
            <div className='App-top-header'>
                <LocationCombo
                    fullLocationList={locations}
                    handleLocationChanged={handleLocationChanged}
                />
            </div>
            <div className='App-top-header'>
                {menuItems &&
                <Menu
                    menuItems={menuItems}
                    handleOrderItemAdded={handleOrderItemAdded}
                />}
            </div>
            <div className='App-top-header'>
                {order && order.total != 0 &&
                <OrderPanel
                    order={order}
                    handleOrderItemDeleted={handleOrderItemDeleted}
                    handleOrderItemChanged={handleOrderItemChanged}
                />}
            </div>
        </div>
    </TopIngredientContext.Provider>
  );
}

export default App;